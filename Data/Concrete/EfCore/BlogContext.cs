﻿using BlogApp.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

namespace BlogApp.Data.Concrete;

public class BlogContext:DbContext
{
    public BlogContext (DbContextOptions<BlogContext> options): base(options)
    {

    }
    public DbSet<Post> Posts => Set<Post>();
    public DbSet<Tag> Tags => Set<Tag>();
    public DbSet<Comment> Comments => Set<Comment>();
    public DbSet<User> Users => Set<User>();


}