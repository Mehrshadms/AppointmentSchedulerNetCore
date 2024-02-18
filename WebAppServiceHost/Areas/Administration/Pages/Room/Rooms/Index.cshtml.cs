using AppointmentScheduler.Contract.Option;
using AppointmentScheduler.Contract.Room;
using AppointmentScheduler.Contract.RoomOption;
using Framework.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAppServiceHost.Areas.Administration.Pages.Room.Rooms;

public class Index : PageModel
{
    [TempData] public string ErrorMessage { get; set; }
    private readonly IRoomApplication _roomApplication;
    private readonly IOptionApplication _optionApplication;
    public RoomSearchModel RoomSearchModel { get; set; }
    public List<RoomViewModel> Rooms { get; set; }

    public Index( IRoomApplication roomApplication, IOptionApplication optionApplication)
    {
        _roomApplication = roomApplication;
        _optionApplication = optionApplication;
    }

    public void OnGet(RoomSearchModel searchModel)
    {
        Rooms = _roomApplication.Search(searchModel);
    }
    
    public IActionResult OnGetCreate()
    {
        CreateRoom command = new CreateRoom
        {
            AddRoomOptions = _optionApplication.GetOptionsForCreate()
        };
        return Partial("./Create", command);
    }
    public IActionResult OnPostCreate(CreateRoom command)
    {
        OperationResult result = _roomApplication.Create(command);
        return new JsonResult(result);
    }
    
    public IActionResult OnGetEdit(long id)
    {
        EditRoom command = _roomApplication.GetDetail(id);
        command.EditRoomOptions = _optionApplication.GetOptionsByRoom(id);
        return Partial("./Edit", command);
    }
    
    public IActionResult OnPostEdit(EditRoom command)
    {
        OperationResult result = _roomApplication.Edit(command);
        return new JsonResult(result);
    }
    
    public IActionResult OnGetRemove(long id)
    {
        OperationResult operationResult = _roomApplication.Remove(id);
        if(operationResult.IsSucceeded)
            return RedirectToPage("./Index");
        ErrorMessage = operationResult.Message;
        return RedirectToPage("./Index");
    }
    
    public IActionResult OnGetRestore(long id)
    {
        OperationResult operationResult = _roomApplication.Restore(id);
        if(operationResult.IsSucceeded)
            return RedirectToPage("./Index");
        ErrorMessage = operationResult.Message;
        return RedirectToPage("./Index");
    }
    
}