using Microsoft.AspNetCore.Mvc;
using DotNetNote.Services;

namespace DotNetNote.Controllers
{
    public class DependencyInjectionDemoController : Controller
    {
        //private CopyrightService _svc;
        //public DependencyInjectionDemoController()
        //{
        //    _svc = new CopyrightService();  //인스턴스 생성
        //}

        private ICopyrightService _service;
        private ICopyrightService _service2;

        public DependencyInjectionDemoController(ICopyrightService service, ICopyrightService service2)
        {
            _service = service;
            _service2 = service2;
        }

        public IActionResult Index()
        {
            //ViewBag.Copyright = $"Copyright {DateTime.Now.Year} all right reserved.";

            ViewBag.Copyright = _service.GetCopyrightString()  //ViewBag개체에 Copyright속성을 만들어 카피라이트 정보를 문자열로 담는 역할
            +"," + _service2.GetCopyrightString();
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Copyright = _service.GetCopyrightString();

            return View();
        }

        //@inject 직접 주입
        public IActionResult AtInjectDemo()
        {
            return View();
        }
    }
}
