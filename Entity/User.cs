namespace BlogApp.Entity;


public class User
{
    public int UserId { get; set; }
    public string? UserName { get; set; }
    public string? Image { get; set; }


    //-----İlişkiler
    public List<Post> Posts { get; set; }=new List<Post>(); //-Post
    public List<Comment> Comments { get; set; }=new List<Comment>(); //-Comment
}
