using Microsoft.AspNetCore.Mvc;
using DotNetNote.Models;

namespace DotNetNote.Controllers
{
    public class FormValidationDemoController : Controller
    {
        //[1] 폼 유효성 검사 테스트용 메인 페이지 작성
        #region Main Page
        public IActionResult Index()
        {
            return View();
        }
        #endregion

        //[2] 순수HTML과 JavaScript를 사용한 유효성 검사
        //[HttpGet] 생략
        #region HTML
        public IActionResult Html()
        {
            return View();
        }

        //[HttpPost] 생략
        public IActionResult HtmlProcess(string txtName, string txtContent)
        {
            ViewBag.ResultString = $"이름: {txtName}, 내용: {Request.Form["txtContent"]}";
            return View();
        }
        #endregion


        #region Helper Method
        [HttpGet]
        public IActionResult HelperMethod()
        {
            return View();
        }

        [HttpPost]
        public IActionResult HelperMethod(string txtName, string txtContent)
        {
            ViewBag.ResultString = $"이름: {txtName}, 내용: {txtContent}";
            return View();
        }
        #endregion

        #region Strongly Type View + Model Binding
        public IActionResult StronglyTypeView()
        {
            return View();
        }

        [HttpPost]
        public IActionResult StronglyTypeView(MaximModel model)
        {
            return View();
        }
        #endregion

        #region Model Validation + Server Valdation
        public IActionResult ModelValidation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ModelValidation(MaximModel model)
        {
            //직접 유효성 검사
            if (string.IsNullOrEmpty(model.Name))
            {
                ModelState.AddModelError("Name", "이름을 입력하세요.");
            }
            if (string.IsNullOrEmpty(model.Content))
            {
                ModelState.AddModelError("content", "내용을 입력하세요.");
            }

            if (!ModelState.IsValid)
            {
                //@Html.ValidationSummary(true)일 때는 아래 에러만 표시
                ModelState.AddModelError("", "모든 에러");
            }

            //넘어온 모델에 대한 유효성 검사
            if (ModelState.IsValid)  //정확한 데이터
            {
                return View("completed");
            }
            return View();
        }

        public IActionResult Completed()
        {
            return View();
        }
        #endregion

        #region
        public IActionResult ClientValidation(MaximModel model)
        {
            //넘어온 모델에 대한 유효성 검사
            if (ModelState.IsValid)
            {
                return View("Completed");
            }

            return View();
        }
        #endregion

        #region TagHelper
        public IActionResult TagHelperValidation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TagHelperValidation(MaximModel model)
        {
            //넘어온 모델에 대한 유효성 검사
            if (ModelState.IsValid)
            {
                return View("Completed");
            }

            return View();
        }
        #endregion
    }
}
