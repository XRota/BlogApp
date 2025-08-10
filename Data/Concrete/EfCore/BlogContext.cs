using System;
using BlogApp.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

namespace BlogApp.Data.Concrete.EfCore;

public class BlogContext : DbContext
{
    public BlogContext(DbContextOptions<BlogContext> options) : base(options)
    {
        
    }
    public DbSet<BlogApp.Entity.Post> Posts => Set<BlogApp.Entity.Post>();
    public DbSet<BlogApp.Entity.User> Users => Set<BlogApp.Entity.User>();
    public DbSet<BlogApp.Entity.Comment> Comments => Set<BlogApp.Entity.Comment>();
    public DbSet<BlogApp.Entity.Tag> Tags => Set<BlogApp.Entity.Tag>();
  
}
