using System;

namespace BlogApp.Entity;

public class Comment
{
    public int CommentId { get; set; }
    public string? Text { get; set; }
    public DateTime CreatedAt { get; set; }

    // ilişkiler
    public Post Post { get; set; } = null!;
    public int PostId { get; set; }

    public User user { get; set; }= null!;
    public int UserId { get; set; }
}
