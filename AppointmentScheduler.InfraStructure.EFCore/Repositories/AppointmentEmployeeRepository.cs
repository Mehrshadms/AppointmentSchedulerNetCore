using AppointmentScheduler.Domain.Appointment;
using Framework.Domain;
using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace AppointmentScheduler.InfraStructure.EFCore.Repositories;

public class AppointmentEmployeeRepository : RepositoryBase<long,AppointmentEmployee>, IAppointmentEmployeeRepository
{
    private readonly AppointmentContext _context;
    public AppointmentEmployeeRepository(AppointmentContext context) : base(context)
    {
        _context = context;
    }

    public async Task CreateMultiple(List<AppointmentEmployee> commands)
    {
        await _context.AddRangeAsync(commands);
    }

    public List<AppointmentEmployee> GetListBy(long roomId)
    {
        throw new NotImplementedException();
        //var query = _context.AppointmentEmployees.Select(x=>new a)
    }
}