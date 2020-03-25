using System;
using Microsoft.AspNetCore.Mvc;

namespace DotNetNote.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ContentResultDemo()
        {
            return Content("ContentResult 반환값"); //문자열 반환
        }
    }
}
