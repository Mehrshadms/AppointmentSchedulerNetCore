using AccountManagement.Configuration;
using AppointmentScheduler.Configuration;
using AppointmentScheduler.InfraStructure.EFCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var appointmentDb= builder.Configuration.GetConnectionString("AppointmentDB");

// Add services to the container.
AppointmentSchedulerBootstrapper.Configure(builder.Services, appointmentDb);
AccountManagementBootstrapper.Configure(builder.Services, appointmentDb);

builder.Services.AddDbContext<AppointmentContext>(x => x.UseSqlServer(appointmentDb));


builder.Services.AddRazorPages();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.UseEndpoints(endpoint =>
    {
        endpoint.MapRazorPages();
        endpoint.MapDefaultControllerRoute();
        endpoint.MapControllers();
    }
);
app.Run();



