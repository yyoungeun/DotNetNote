using Microsoft.AspNetCore.Mvc;

namespace DotNetNote.Controllers
{
    public class ViewComponentDemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        ///<summary>
        /// CopyrightViewComponent 출력 데모
        /// </summary>
        /// 
        public IActionResult CopyrightDemo()
        {
            return View();
        }
    }
}
