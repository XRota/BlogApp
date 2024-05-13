
using BlogApp.Data.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BlogApp.Controllers{

    public class PostsController : Controller
        {
            private IPostRepository _repository;
            public PostsController(IPostRepository repository)
            {
                _repository= repository;
            }
            public ActionResult Index()
            {
                return View(_repository.Posts.ToList());
            }
        }
}

