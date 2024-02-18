using AppointmentScheduler.Contract.Option;
using AppointmentScheduler.Contract.RoomOption;
using AppointmentScheduler.Domain.Room;
using Framework.Application;

namespace AppointmentScheduler.Application;

public class OptionApplication : IOptionApplication
{
    private readonly IOptionRepository _optionRepository;

    public OptionApplication(IOptionRepository optionRepository)
    {
        _optionRepository = optionRepository;
    }

    public OperationResult Create(CreateOption command)
    {
        OperationResult operationResult = new();

        if (_optionRepository.Exists(x => x.StringOption == command.StringOption))
            return operationResult.Failed();
        Option option = new Option(command.StringOption);
        
        _optionRepository.Create(option);
        _optionRepository.SaveChanges();
        return operationResult.Succeeded();
    }

    public OperationResult Edit(EditOption command)
    {
        OperationResult operationResult = new();
        Option option = _optionRepository.Get(command.Id);
        
        if (option == null)
            return operationResult.Failed();

        if (_optionRepository.Exists(x => x.StringOption == command.StringOption && x.Id != command.Id))
            return operationResult.Failed();
        
        option.Edit(command.StringOption);
        
        _optionRepository.SaveChanges();
        return operationResult.Succeeded();
    }

    public EditOption GetDetail(long id)
    {
        return _optionRepository.GetDetail(id);
    }

    public List<OptionViewModel> Search(OptionSearchModel searchModel)
    {
        return _optionRepository.Search(searchModel);
    }

    public List<AddRoomOption> GetOptionsForCreate()
    {
        return _optionRepository.GetOptions();
    }

    public List<EditRoomOption> GetOptionsByRoom(long id)
    {
        return _optionRepository.GetOptionsByRoom(id);
    }
}