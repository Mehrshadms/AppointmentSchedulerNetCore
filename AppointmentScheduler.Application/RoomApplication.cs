using System.Xml.Linq;
using AppointmentScheduler.Contract.Room;
using AppointmentScheduler.Contract.RoomOption;
using AppointmentScheduler.Domain.Room;
using Framework.Application;

namespace AppointmentScheduler.Application;

public class RoomApplication : IRoomApplication
{
    private readonly IRoomRepository _roomRepository;
    private readonly IRoomOptionRepository _roomOptionRepository;
    private readonly IOptionRepository _optionRepository;

    public RoomApplication(IRoomRepository roomRepository, IRoomOptionRepository roomOptionRepository, IOptionRepository optionRepository)
    {
        _roomRepository = roomRepository;
        _roomOptionRepository = roomOptionRepository;
        _optionRepository = optionRepository;
    }

    public OperationResult Create(CreateRoom command)
    {
        OperationResult operationResult = new();
        if (_roomRepository.Exists(x => x.Name == command.Name))
            return operationResult.Failed();

        Room room = new Room(command.Name, command.Description, command.Capacity,
            command.LinkToVirtualRoom, command.IsVirtual);
        
        _roomRepository.Create(room);
        _roomRepository.SaveChanges();
        return operationResult.Succeeded();
    }

    public OperationResult Edit(EditRoom command)
    {
        OperationResult operationResult = new();
        Room room = _roomRepository.Get(command.Id);
        if (room == null)
            return operationResult.Failed();
        
        if (_roomRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
            return operationResult.Failed();
        
        EditMultiple(command.SelectedOptions,room.Id);
        room.Edit(command.Name, command.Description, command.Capacity,
            command.LinkToVirtualRoom, command.IsVirtual);
        
        _roomRepository.SaveChanges();
        return operationResult.Succeeded();
    }

    public OperationResult Remove(long id)
    {
        OperationResult operationResult = new();
        Room room = _roomRepository.Get(id);
        if (room == null)
            operationResult.Failed(ApplicationMessages.RecordNotFound);
        room.Remove();
        _roomOptionRepository.SaveChanges();
        return operationResult.Succeeded();
    }

    public OperationResult Restore(long id)
    {
        OperationResult operationResult = new();
        Room room = _roomRepository.Get(id);
        if (room == null)
            operationResult.Failed(ApplicationMessages.RecordNotFound);
        room.Restore();
        _roomOptionRepository.SaveChanges();
        return operationResult.Succeeded();
    }

    public EditRoom GetDetail(long id)
    {
        return _roomRepository.GetDetail(id);
    }

    public List<RoomViewModel> Search(RoomSearchModel roomSearchModel)
    {
        return _roomRepository.Search(roomSearchModel);
    }

    public List<RoomViewModel> GetAvailableRooms()
    {
        return _roomRepository.GetAvailableRooms();
    }

    private OperationResult EditMultiple(List<long> commands,long roomId)
    {
        OperationResult operationResult = new();
        List<Option> options = _optionRepository.List();
        List<RoomOption> EditroomOptions = _roomOptionRepository.GetListBy(roomId);
        List<RoomOption> CreateroomOptions = new List<RoomOption>();
        
        foreach (var option in options)
        {
            //RoomOption item = new RoomOption(option.Id,roomId);
            RoomOption item = EditroomOptions.FirstOrDefault(x => x.OptionId == option.Id);

            if (item == null)
            {
                item = new RoomOption(option.Id,roomId);
                if (commands.Contains(option.Id))
                {
                    item.MakeTrue();
                }
                CreateroomOptions.Add(item);
            }
            else
            {
                if (commands.Contains(option.Id))
                {
                    item.MakeTrue();
                }
                else
                {
                    item.MakeFalse();
                }
            }
        }
        _roomOptionRepository.CreateMultiple(CreateroomOptions);
        _roomRepository.SaveChanges();
        return operationResult.Succeeded();
    }
}