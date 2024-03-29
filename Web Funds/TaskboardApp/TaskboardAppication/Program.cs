using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TaskboardAppication.Services;
using TaskboardAppication.Services.Interfaces;
using TaskboardApplication.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TaskBoardAppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = builder.Configuration
            .GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");
        options.Password.RequireDigit = builder.Configuration
            .GetValue<bool>("Identity:Password:RequiredDigit");
        options.Password.RequireLowercase = builder.Configuration
            .GetValue<bool>("Identity:Password:RequireLowercase");
        options.Password.RequireNonAlphanumeric = builder.Configuration
            .GetValue<bool>("Identity:Password:RequireNonAlphanumeric");
        options.Password.RequireUppercase = builder.Configuration
            .GetValue<bool>("Identity:Password:RequireUppercase");
        options.Password.RequiredLength = builder.Configuration
            .GetValue<int>("Identity:Password:RequiredLength");
    })
    .AddEntityFrameworkStores<TaskBoardAppDbContext>();

builder.Services.AddScoped<IBoardService, BoardService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
