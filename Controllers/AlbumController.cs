using Microsoft.AspNetCore.Mvc;

namespace DotNetNote.Controllers
{
    public class AlbumController : Controller
    {
        public IActionResult Index()
        {
            return View("Default"); //Default.cshtml 호출(없음)
        }
    }
}
