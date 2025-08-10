using System;
using System.Reflection.Metadata;

namespace BlogApp.Entity;

public class Post
{
    public int PostId { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public bool IsActive { get; set; }
    public int UserId { get; set; }
    // ilişkiler

    public User user { get; set; } = null!;
    public List<Tag> Tags { get; set; } = new List<Tag>();
    public List<Comment> Comments { get; set; } = new List<Comment>();
    
}
