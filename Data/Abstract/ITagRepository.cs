using BlogApp.Entity;

namespace BlogApp.Data.Abstract;
public interface ITagRepository
{
    //IQueryable Filtreleme yöntemi Yalnızca filtrelemek istediğiniz bilgiyi çeker.
    IQueryable<Tag> Tags {get;} 
    void CreateTag(Tag tag);
}