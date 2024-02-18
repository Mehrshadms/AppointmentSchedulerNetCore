using AppointmentScheduler.Contract.Option;
using AppointmentScheduler.Contract.RoomOption;
using AppointmentScheduler.Domain.Room;
using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace AppointmentScheduler.InfraStructure.EFCore.Repositories;

public class OptionRepository : RepositoryBase<long,Option> , IOptionRepository
{
    private readonly AppointmentContext _context;
    public OptionRepository(AppointmentContext context) : base(context)
    {
        _context = context;
    }

    public EditOption GetDetail(long id)
    {
        return _context.Options.Select(x => new EditOption
        {
            Id = x.Id,
            StringOption = x.StringOption
        }).FirstOrDefault(x => x.Id == id);
    }

    public List<OptionViewModel> Search(OptionSearchModel searchModel)
    {
        var query = _context.Options.Select(x => new OptionViewModel
        {
            Id = x.Id,
            StringOption = x.StringOption
        });

        if (!string.IsNullOrWhiteSpace(searchModel.StringOption))
            query = query.Where(x => x.StringOption.Contains(searchModel.StringOption));

        return query.OrderByDescending(x => x.Id).ToList();
    }

    public List<AddRoomOption> GetOptions()
    {
        return _context.Options.Select(x => new AddRoomOption
        {
            OptionId = x.Id,
            StringOption = x.StringOption
        }).ToList();
    }

    public List<EditRoomOption> GetOptionsByRoom(long id)
    {
        var options = _context.Options.Select(x => new EditRoomOption()
        {
            OptionId = x.Id,
            StringOption = x.StringOption,
            RoomId = id
        }).ToList();
        
        var roomOptions = _context.RoomOptions.Where(x => x.RoomId == id)
            .Include(x => x.Option)
            .Select(x => new EditRoomOption
            {
                Id = x.Id,
                OptionId = x.OptionId,
                RoomId = x.RoomId,
                StringOption = x.Option.StringOption,
                HaveOption = x.HaveOption
            }).ToList();

        for (int i = 0; i < options.Count; i++)
        {
            if(roomOptions.Any(x=>x.OptionId == options[i].OptionId))
                options[i] = roomOptions.SingleOrDefault(ae => ae.OptionId == options[i].OptionId);
        }
        
        return options;
    }
}