using EmployeesLeaveApplication.Data;
using EmployeesLeaveApplication.Interface;
using EmployeesLeaveApplication.Repositories;
using EmployeesLeaveApplication.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var provider = builder.Services.BuildServiceProvider();
var config = provider.GetRequiredService<IConfiguration>();
builder.Services.AddDbContext<ApplicationDbContext>(item => item.UseSqlServer(config.GetConnectionString("Conn")));

// 3️⃣ Register Repositories (DI)
// ----------------------------------------------------
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<ILeaveRepository, LeaveRepository>();
builder.Services.AddScoped<IHolidayRepository, HolidayRepository>();


//// 4️⃣ Register Services (DI)
//// ----------------------------------------------------
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<ILeaveService, LeaveService>();
builder.Services.AddScoped<IHolidayService, HolidayService>();

builder.Services.AddScoped<IHolidayService, HolidayService>();
builder.Services.AddScoped<IHolidayRepository, HolidayRepository>();


//builder.Services.AddScoped<ILeaveRepository, LeaveRepository>();
//builder.Services.AddScoped<IHolidayRepository, HolidayRepository>();
//builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
//builder.Services.AddScoped<ILeaveService, LeaveService>();



//builder.Services.AddAuthentication("MyCookieAuth")
//    .AddCookie("MyCookieAuth", options =>
//    {
//        options.LoginPath = "/Account/Login";
//        options.AccessDeniedPath = "/Account/AccessDenied";
//    });

//builder.Services.AddAuthorization();


builder.Services.AddAuthentication("FakeCookie")
    .AddCookie("FakeCookie", options =>
    {
        options.LoginPath = "/fake-login"; // no actual login page
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ManagerOnly", policy => policy.RequireRole("Manager"));
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
});

builder.Configuration.AddJsonFile("users.json", optional: false, reloadOnChange: true);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.Use(async (context, next) =>
{
    // If user not authenticated, fake login
    if (!context.User.Identity.IsAuthenticated)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, "Test Admin"),
            new Claim("UserId", "1"),
            new Claim(ClaimTypes.Role, "Admin")   // or Manager
        };

        var identity = new ClaimsIdentity(claims, "FakeCookie");
        await context.SignInAsync("FakeCookie", new ClaimsPrincipal(identity));
    }

    await next();
});


app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
