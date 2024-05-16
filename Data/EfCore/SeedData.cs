using BlogApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concrete;

public static class SeedData
{
    public static void TestVerileriniDoldur(IApplicationBuilder app)
    {
        var context= app.ApplicationServices.CreateAsyncScope().ServiceProvider.GetService<BlogContext>();
        if (context != null)
        {
            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if(!context.Tags.Any())
            {
                context.Tags.AddRange(
                    new Entity.Tag {Text="Web Programlama"},
                    new Entity.Tag {Text="Backed"},
                    new Entity.Tag {Text="Frontend"},
                    new Entity.Tag {Text="Fullstack"},
                    new Entity.Tag {Text="Php"}
                );
                context.SaveChanges();
            }
            if(!context.Users.Any())
            {
                context.Users.AddRange(
                    new User {UserName="Koray Semiz"},
                    new User{UserName="Hüseyin Çam"}
                 );
                context.SaveChanges();
            }
            if(!context.Posts.Any())
            {
                context.Posts.AddRange(
                    new Post{
                        Title="Asp net core",
                        Content="Asp net core dersleri",
                        IsActive= true,
                        PublishedOn=DateTime.Now.AddDays(-10),
                        Tags=context.Tags.Take(3).ToList(),
                        Image="1.jpg",
                        UserId=1
                    },
                    new Post{
                        Title="Php net core",
                        Content="Php net core dersleri",
                        IsActive= true,
                        PublishedOn=DateTime.Now.AddDays(-20),
                        Tags=context.Tags.Take(2).ToList(),
                        Image="2.jpg",
                        UserId=1
                    },
                    new Post{
                        Title="Djangoe",
                        Content="Django dersleri",
                        IsActive= true,
                        PublishedOn=DateTime.Now.AddDays(-5),
                        Tags=context.Tags.Take(4).ToList(),
                        Image="3.jpg",
                        UserId=2
                    }
                );
                context.SaveChanges();

            }

        }
    }
}
