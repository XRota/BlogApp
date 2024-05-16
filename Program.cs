
using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BlogContext>(Options => {

    //appsettings.json dosyasından oluşturmul olduğumuz "sql_connection":"Data Source=blog.db" verisini çeker.
    Options.UseSqlite(builder.Configuration["ConnectionStrings:Sql_connection"]);
});
builder.Services.AddScoped<IPostRepository,EfPostRepository>();

var app = builder.Build();

app.UseStaticFiles();

SeedData.TestVerileriniDoldur(app);

app.MapDefaultControllerRoute();

app.Run();
