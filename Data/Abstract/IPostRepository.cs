using BlogApp.Entity;

namespace BlogApp.Data.Abstract;
public interface IPostRepository
{
    //IQueryable Filtreleme yöntemi Yalnızca filtrelemek istediğiniz bilgiyi çeker.
    IQueryable<Post> Posts {get;} 
    void CreatePost(Post post);
}