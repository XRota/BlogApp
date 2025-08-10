using System;

namespace BlogApp.Entity;

public class User
{
    public int UserId { get; set; }
    public string? UserName { get; set; }

    // ilişkiler

    public List<Post> posts { get; set; } = new List<Post>();
    public List<Comment> Comments { get; set; }=new List<Comment>();
}
