using AppointmentScheduler.Contract.Room;
using Framework.Application;
using Framework.Domain;

namespace AppointmentScheduler.Domain.Room;

public interface IRoomRepository : IRepository<long,Room>
{
    EditRoom GetDetail(long id);
    List<RoomViewModel> Search(RoomSearchModel roomSearchModel);
    List<RoomViewModel> GetAvailableRooms();
}