using Microsoft.AspNetCore.Mvc;

namespace DotNetNote.Controllers
{
    public class ViewBagDemoController : Controller
    {
        ///<summary>
        /// View 개체로 컨트롤러에서 뷰로 데이터 전달
        /// </summary>
        /// 
        public IActionResult Index()
        {
            ViewBag.Name = "박용준";
            ViewBag.Age = 21;
            ViewBag.Height = 160;

            //ViewBag.Address와 ViewData["Address"]는 동일 표현
            //ViewBag.Address = "세종시...";
            ViewData["Address"] = "세종시...";

            return View();
        }
    }
}
