using AppointmentScheduler.Contract.Option;
using AppointmentScheduler.Contract.RoomOption;
using AppointmentScheduler.Domain.Room;
using Framework.Infrastructure;

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
            StringOption = x.StringOption,
        }).ToList();
    }
}