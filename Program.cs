
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
builder.Services.AddScoped<ITagRepository,EfTagRepository>();
builder.Services.AddScoped<ICommentRepository,EfCommentRepository>();



var app = builder.Build();

app.UseStaticFiles();

SeedData.TestVerileriniDoldur(app);


//localhost://posts/react-dersleri
//localhost://posts/tag/web-programlama

app.MapControllerRoute(
    name: "post_details",
    pattern: "posts/details/{url}",
    defaults: new {controller = "Posts", Action="Details"}
    );

    app.MapControllerRoute(
    name: "post_by_tag",
    pattern: "posts/tag/{tag}",
    defaults: new {controller = "Posts", Action="Index"}
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Posts}/{action=Index}/{id?}");

app.Run();
