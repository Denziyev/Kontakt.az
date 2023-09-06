using Kontakt.App.Models;
using Kontakt.Core.Models;
using Kontakt.Service.Responses;
using Kontakt.Service.Services.Implementations;
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
            return View(comments);
        }

        [HttpGet]
        public async Task<IActionResult> Visible(int id)
        {
            await _commentService.VisibleAsync(id);
            return Redirect(Request.Headers["Referer"].ToString());
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _commentService.DeleteAsync(id);
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
