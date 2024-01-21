using AppointmentScheduler.Contract.Option;
using Framework.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAppServiceHost.Areas.Administration.Pages.Room.Options;

public class Index : PageModel
{
    private readonly IOptionApplication _optionApplication;
    public OptionSearchModel OptionSearchModel;
    public List<OptionViewModel> Options;
    
    public Index( IOptionApplication optionApplication)
    {
        _optionApplication = optionApplication;
    }

    public void OnGet(OptionSearchModel searchModel)
    {
        Options = _optionApplication.Search(searchModel);
    }
    
    public IActionResult OnGetCreate()
    {
        CreateOption command = new CreateOption();
        return Partial("./Create", command);
    }
    public IActionResult OnPostCreate(CreateOption command)
    {
        OperationResult result = _optionApplication.Create(command);
        return new JsonResult(result);
    }
    
    public IActionResult OnGetEdit()
    {
        EditOption command = new EditOption();
        return Partial("./Edit", command);
    }
    
    public IActionResult OnPostEdit(EditOption command)
    {
        OperationResult result = _optionApplication.Edit(command);
        return new JsonResult(result);
    }
}