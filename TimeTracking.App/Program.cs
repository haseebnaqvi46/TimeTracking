using TimeTracking.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using TimeTracking.Infrastructure.Data;
using TimeTracking.App.Services;

var builder = WebApplication.CreateBuilder(args);

// Add MVC
builder.Services.AddControllersWithViews();

builder.Services.Configure<OvertimeSettings>(
    builder.Configuration.GetSection("OvertimeSettings"));

builder.Services.AddDbContext<TimeTrackingDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ITimeEntryAppService, TimeEntryAppService>();
builder.Services.AddScoped<ISummaryService, SummaryService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();