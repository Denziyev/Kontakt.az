using Kontakt.Core.Models;
using Kontakt.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kontakt.App.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<IActionResult> AddComment(Comment comment)
        {
            await _commentService.CreateAsync(comment);
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
