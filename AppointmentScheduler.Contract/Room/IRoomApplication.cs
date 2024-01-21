using Framework.Application;

namespace AppointmentScheduler.Contract.Room;

public interface IRoomApplication
{
    OperationResult Create(CreateRoom command);
    OperationResult Edit(EditRoom command);
    OperationResult Remove(long id);
    OperationResult Restore(long id);
    EditRoom GetDetail(long id);
    List<RoomViewModel> Search(RoomSearchModel roomSearchModel);
    List<RoomViewModel> GetAvailableRooms();
    
}