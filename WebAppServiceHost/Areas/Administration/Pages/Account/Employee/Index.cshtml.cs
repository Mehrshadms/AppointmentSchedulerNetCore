using AccountManagement.Contract.Employee;
using AppointmentScheduler.Contract.Appointment;
using Framework.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAppServiceHost.Areas.Administration.Pages.Account.Employee;

public class Index : PageModel
{
    [TempData] public string ErrorMessage { get; set; }
    private readonly IEmployeeApplication _employeeApplication;
    public EmployeeSearchModel EmployeeSearchModel { get; set; }
    public List<EmployeeViewModel> Employees { get; set; }

    public Index(IEmployeeApplication employeeApplication)
    {
        _employeeApplication = employeeApplication;
    }

    public void OnGet(EmployeeSearchModel searchModel)
    {
        Employees = _employeeApplication.Search(searchModel);
    }
    
    public IActionResult OnGetCreate()
    {
        CreateEmployee command = new CreateEmployee();
        return Partial("./Create", command);
    }
    public IActionResult OnPostCreate(CreateEmployee command)
    {
        OperationResult result = _employeeApplication.Create(command);
        return new JsonResult(result);
    }
    
    public IActionResult OnGetEdit(long id)
    {
        EditEmployee command = _employeeApplication.GetDetail(id);
        return Partial("./Edit", command);
    }
    
    public IActionResult OnPostEdit(EditEmployee command)
    {
        OperationResult result = _employeeApplication.Edit(command);
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
    
    public IActionResult OnGetRemove(long id)
    {
        OperationResult operationResult = _employeeApplication.Remove(id);
        if(operationResult.IsSucceeded)
            return RedirectToPage("./Index");
        ErrorMessage = operationResult.Message;
        return RedirectToPage("./Index");
    }
    
    public IActionResult OnGetRestore(long id)
    {
        OperationResult operationResult = _employeeApplication.Restore(id);
        if(operationResult.IsSucceeded)
            return RedirectToPage("./Index");
        ErrorMessage = operationResult.Message;
        return RedirectToPage("./Index");
    }
}