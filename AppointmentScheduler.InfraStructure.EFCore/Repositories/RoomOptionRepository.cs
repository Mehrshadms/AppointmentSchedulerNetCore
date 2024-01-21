using AppointmentScheduler.Contract.RoomOption;
using AppointmentScheduler.Domain.Room;
using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace AppointmentScheduler.InfraStructure.EFCore.Repositories;

public class RoomOptionRepository : RepositoryBase<long,RoomOption> , IRoomOptionRepository
{
    private readonly AppointmentContext _context;
    public RoomOptionRepository(AppointmentContext context) : base(context)
    {
        _context = context;
    }

    public void CreateMultiple(List<RoomOption> commands)
    {
        _context.RoomOptions.AddRange(commands);
    }

    public EditRoomOption GetDetail(long id)
    {
        return _context.RoomOptions.AsNoTracking().Select(x => new EditRoomOption
        {
            Id = x.Id,
            OptionId = x.OptionId,
            HaveOption = x.HaveOption
        }).FirstOrDefault(x => x.Id == id);
    }

    public List<RoomOption> GetListBy(long roomId)
    {
        return _context.RoomOptions.Where(x => x.RoomId == roomId).ToList();
    }
}