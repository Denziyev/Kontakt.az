using Kontakt.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kontakt.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        public async Task<IActionResult> Index()
        {
           var comments= await _commentService.GetAllAsync();
            return View(comments.Data);
        }
    }
}
