using Microsoft.AspNetCore.Mvc;

namespace DotNetNote.Controllers
{
    public class ViewComponentDemoController : Controller
    {
        /// <summary>
        ///  SitelistViewComponent 사용 데모
        /// </summary>
        /// 
        public IActionResult SiteListDemo()
        {
            return View();
        }

        /// <summary>
        /// TechListViewComponent 사용 데모
        /// </summary>
        /// <returns></returns>
        /// 
        public IActionResult TechListDemo()
        {
            return View();
        }

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
