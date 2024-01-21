using AppointmentScheduler.Contract.RoomOption;
using Framework.Domain;

namespace AppointmentScheduler.Domain.Room;

public interface IRoomOptionRepository : IRepository<long,RoomOption>
{
    void CreateMultiple(List<RoomOption> commands);
    EditRoomOption GetDetail(long id);
    List<RoomOption> GetListBy(long roomId);
}