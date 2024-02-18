using AppointmentScheduler.Contract.Appointment;
using AppointmentScheduler.Contract.Room;
using Framework.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAppServiceHost.Areas.Administration.Pages.Appointments.Appointment;

public class Index : PageModel
{
    private readonly IAppointmentApplication _appointmentApplication;
    private readonly IRoomApplication _roomApplication;
    public RoomSearchModel RoomSearchModel { get; set; }
    public List<AppointmentViewModel> Appointments { get; set; }

    public Index( IRoomApplication roomApplication,IAppointmentApplication appointmentApplication)
    {
        _roomApplication = roomApplication;
        _appointmentApplication = appointmentApplication;
    }

    public void OnGet(AppointmentSearchModel searchModel)
    {
        Appointments = _appointmentApplication.Search(searchModel);
    }
    
    public IActionResult OnGetCreate()
    {
        DefineAppointment command = new DefineAppointment
        {
            AvailableRooms = _roomApplication.GetAvailableRooms()
        };
        return Partial("./Create", command);
    }
    public IActionResult OnPostCreate(DefineAppointment command)
    {
        OperationResult result = _appointmentApplication.Define(command);
        return new JsonResult(result);
    }
    
    public IActionResult OnGetEdit(long id)
    {
        EditAppointment command = _appointmentApplication.GetDetail(id);
        command.AvailableRooms = _roomApplication.GetAvailableRooms();
        return Partial("./Edit", command);
    }
    
    public IActionResult OnPostEdit(EditAppointment command)
    {
        OperationResult result = _appointmentApplication.Edit(command);
        return new JsonResult(result);
    }
    
    public IActionResult OnGetCancel(long id)
    {
        CancelAppointment command = new CancelAppointment
        {
            Id = id
        };
        return Partial("./Cancel", command);
    }
    
    public IActionResult OnPostCancel(CancelAppointment command)
    {
        OperationResult result = _appointmentApplication.Cancel(command);
        return new JsonResult(result);
    }
    
    public IActionResult OnGetPostPone(long id)
    {
        PostPoneAppointment command = new PostPoneAppointment
        {
            Id = id
        };
        return Partial("./PostPone", command);
    }
    
    public IActionResult OnPostPostpone(PostPoneAppointment command)
    {
        OperationResult result = _appointmentApplication.PostPone(command);
        return new JsonResult(result);
    }
    
    public IActionResult OnGetReSchedule(long id)
    {
        RescheduleAppointment command = new RescheduleAppointment
        {
            Id = id
        };
        return Partial("./Reschedule", command);
    }
    public IActionResult OnPostReSchedule(RescheduleAppointment command)
    {
        OperationResult result = _appointmentApplication.Reschedule(command);
        return new JsonResult(result);
    }
}