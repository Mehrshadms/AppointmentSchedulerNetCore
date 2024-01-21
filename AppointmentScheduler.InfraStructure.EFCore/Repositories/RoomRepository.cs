using AppointmentScheduler.Contract.Option;
using AppointmentScheduler.Contract.Room;
using AppointmentScheduler.Contract.RoomOption;
using AppointmentScheduler.Domain.Room;
using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace AppointmentScheduler.InfraStructure.EFCore.Repositories;

public class RoomRepository : RepositoryBase<long,Room> , IRoomRepository
{
    private readonly AppointmentContext _Context;
    public RoomRepository(AppointmentContext context) : base(context)
    {
        _Context = context;
    }

    public EditRoom GetDetail(long id)
    {
        return _Context.Rooms
            .Include(x => x.RoomOptionsList)
            .ThenInclude(x => x.Option)
            .Select(x => new EditRoom
            {
                Id = x.Id,
                Name = x.Name,
                Capacity = x.Capacity,
                EditRoomOptions = MapEditRoomOption(x.RoomOptionsList),
                IsVirtual = x.IsVirtual,
                Description = x.Description,
                LinkToVirtualRoom = x.LinkToVirtualRoom
            }).FirstOrDefault(x => x.Id == id);
    }

    private static List<EditRoomOption> MapEditRoomOption(List<RoomOption> xRoomOptionsList)
    {
        return xRoomOptionsList.Select(x => new EditRoomOption
        {
            Id = x.Id,
            HaveOption = x.HaveOption,
            OptionId = x.OptionId,
            StringOption = x.Option.StringOption
        }).ToList();
    }
    private static List<RoomOptionViewModel> MapRoomOption(List<RoomOption> xRoomOptionsList)
    {
        return xRoomOptionsList.Select(x => new RoomOptionViewModel
        {
            Id = x.Id,
            HaveOption = x.HaveOption,
            OptionId = x.OptionId,
            RoomId = x.RoomId
        }).ToList();
    }

    public List<RoomViewModel> Search(RoomSearchModel roomSearchModel)
    {
        var query = _Context.Rooms
            .Include(x => x.RoomOptionsList)
            .ThenInclude(x=>x.Option)
            .Select(x => new RoomViewModel
        {
            Id = x.Id,
            Name = x.Name,
            Capacity = x.Capacity,
            IsRemoved = x.IsRemoved,
            IsVirtual = x.IsVirtual,
            RoomOptions = MapRoomOption(x.RoomOptionsList)
        });
        
        if (!string.IsNullOrWhiteSpace(roomSearchModel.Name))
            query = query.Where(x => x.Name.Contains(roomSearchModel.Name));
        
        if (roomSearchModel.LeastCapacity != 0)
            query = query.Where(x => x.Capacity > roomSearchModel.LeastCapacity);
        if (roomSearchModel.IsVirtual)
        {
            query = query.Where(x => x.IsVirtual == roomSearchModel.IsVirtual);
        }
        
        return query.OrderByDescending(x => x.Id).ToList();

    }

    public List<RoomViewModel> GetAvailableRooms()
    {
        return _Context.Rooms.Where(x => x.IsRemoved == false).Select(x => new RoomViewModel
        {
            Id = x.Id,
            Name = x.Name,
            Capacity = x.Capacity,
            IsRemoved = x.IsRemoved,
            IsVirtual = x.IsVirtual
        }).ToList();
    }
}