using DockerComposeDemo.DBModels;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

/*Database Context Dependency Injection*/
var dbHost = Environment.GetEnvironmentVariable("DBServer") ?? "localhost";
var port = Environment.GetEnvironmentVariable("DBPort") ?? "1433";
var dbName = Environment.GetEnvironmentVariable("DBDatabase") ?? "dbProduct";
var user = Environment.GetEnvironmentVariable("DBUser") ?? "sa";
var dbPassword = Environment.GetEnvironmentVariable("DBPassword") ?? "1Secure*Password1";
var dbConnectionStrig = $"Server={dbHost},{port};Database={dbName};User={user};Password={dbPassword}";
builder.Services.AddDbContext<dbProductContext>(opt => opt.UseSqlServer(dbConnectionStrig));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
