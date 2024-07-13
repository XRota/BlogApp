
using BlogApp.Data.Abstract;
using BlogApp.Entity;
using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BlogApp.Controllers{

    public class PostsController : Controller
        {
            private IPostRepository _postrepository;
            private ICommentRepository _commentRepository;

           
            
            public PostsController(IPostRepository postRepository, ICommentRepository commentRepository)
            {
                _postrepository= postRepository; 
                _commentRepository=commentRepository;               

            }
            public async Task<ActionResult> Index(string tag)
            {
                var posts =_postrepository.Posts;

                if(!string.IsNullOrEmpty(tag))
                {
                    posts = posts.Where(x=>x.Tags.Any(t=> t.Url==tag));
                }
                return View(new PostViewModel{Posts =await posts.ToListAsync()});
            }
            public async Task<IActionResult> Details(string url )
            {
                return View(await _postrepository
                                    .Posts
                                    .Include(x => x.Tags)
                                    .Include(x=> x.Comments)
                                    .ThenInclude(x=> x.User)
                                    .FirstOrDefaultAsync(p => p.Url == url));    
            }
            public IActionResult AddComment(int PostId, string UserName, string Text, string Url)
            {
                Random rnd = new Random();
                int rimg = rnd.Next(1,5);

                var entity = new Comment{
                Text = Text,
                PublishedOn = DateTime.Now ,
                PostId= PostId,
                User = new User {UserName=UserName,Image="p"+rimg+".jpg"}   
                
                };
            _commentRepository.CreateComment(entity);

            // return Redirect("/post/details/" + Url);
            return RedirectToRoute("post_details", new {url = Url}); //alternatif
            
            }
        }
}

