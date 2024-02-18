using AppointmentScheduler.Contract.RoomOption;
using Framework.Application;

namespace AppointmentScheduler.Contract.Option;

public interface IOptionApplication
{
    OperationResult Create(CreateOption command);
    OperationResult Edit(EditOption command);
    EditOption GetDetail(long id);
    List<OptionViewModel> Search(OptionSearchModel searchModel);
    List<AddRoomOption> GetOptionsForCreate();
    List<EditRoomOption> GetOptionsByRoom(long id);
}