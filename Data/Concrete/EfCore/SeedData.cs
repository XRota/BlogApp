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
                    new Entity.Tag {Text="Web Programlama", Url ="web-programlama", Color = TagColors.warning },
                    new Entity.Tag {Text="Backed" , Url ="Backed", Color = TagColors.info },
                    new Entity.Tag {Text="Frontend" , Url ="Frontend", Color = TagColors.success },
                    new Entity.Tag {Text="Fullstack" , Url ="Fullstack", Color = TagColors.secondary },
                    new Entity.Tag {Text="Php" , Url ="Php", Color = TagColors.primary }
                );
                context.SaveChanges();
            }


            if(!context.Users.Any())
            {
                context.Users.AddRange(
                    new User {UserName="Hülya Deniz", Image="p1.jpg"},
                    new User{UserName="Hüseyin Çam", Image="p2.jpg"},
                    new User{UserName="Ayşe Yılmaz", Image="p3.jpg"},
                    new User{UserName="Süleyman Balıkcı", Image="p4.jpg"}

                 );
                context.SaveChanges();
            }


            if(!context.Posts.Any())
            {
                context.Posts.AddRange(
                    new Post{
                        Title="Asp net core",
                        Content="Asp net core dersleri",
                        Url = "aspnet-core",
                        IsActive= true,
                        PublishedOn=DateTime.Now.AddDays(-10),
                        Tags=context.Tags.Take(3).ToList(),
                        Image="1.jpg",
                        UserId=1,
                        Comments=new List<Comment> 
                        {
                            new Comment {
                                Text ="iyi bir kurs", 
                                PublishedOn=DateTime.Now.AddDays(-1),
                                UserId=1
                                },

                            new Comment {
                                Text ="Çok faydalandığım bir kurs", 
                                PublishedOn=DateTime.Now.AddDays(-13),
                                UserId=2
                                }
                        }
                    },
                    new Post{
                        Title="Php net core",
                        Content="Php net core dersleri",
                        Url = "php",
                        IsActive= true,
                        PublishedOn=DateTime.Now.AddDays(-20),
                        Tags=context.Tags.Take(2).ToList(),
                        Image="2.jpg",
                        UserId=1
                    },
                    new Post{
                        Title="Djangoe",
                        Content="Django dersleri",
                        Url = "Django",
                        IsActive= true,
                        PublishedOn=DateTime.Now.AddDays(-7),
                        Tags=context.Tags.Take(4).ToList(),
                        Image="3.jpg",
                        UserId=2
                    },
                    new Post{
                        Title="React",
                        Content="React dersleri",
                        Url = "React",
                        IsActive= true,
                        PublishedOn=DateTime.Now.AddDays(-30),
                        Tags=context.Tags.Take(4).ToList(),
                        Image="3.jpg",
                        UserId=2
                    },
                    new Post{
                        Title="Angular",
                        Content="Angular dersleri",
                        Url = "Angular",
                        IsActive= true,
                        PublishedOn=DateTime.Now.AddDays(-40),
                        Tags=context.Tags.Take(4).ToList(),
                        Image="3.jpg",
                        UserId=2
                    },
                    new Post{
                        Title="Web tasarım",
                        Content="Web Tasarım dersleri",
                        Url = "web-tasarım",
                        IsActive= true,
                        PublishedOn=DateTime.Now.AddDays(-50),
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
