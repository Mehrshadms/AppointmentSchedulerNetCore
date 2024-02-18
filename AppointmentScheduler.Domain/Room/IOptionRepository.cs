using AppointmentScheduler.Contract.Option;
using AppointmentScheduler.Contract.RoomOption;
using Framework.Domain;

namespace AppointmentScheduler.Domain.Room;

public interface IOptionRepository : IRepository<long,Option>
{
    EditOption GetDetail(long id);
    List<OptionViewModel> Search(OptionSearchModel searchModel);
    List<AddRoomOption> GetOptions();
    List<EditRoomOption> GetOptionsByRoom(long id);
}