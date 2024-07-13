using BlogApp.Entity;

namespace BlogApp.Data.Abstract;
public interface ICommentRepository
{
    //IQueryable Filtreleme yöntemi Yalnızca filtrelemek istediğiniz bilgiyi çeker.
    IQueryable<Comment> Comments {get;} 
    void CreateComment(Comment comment);
}