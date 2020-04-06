using Microsoft.AspNetCore.Mvc;

namespace DotNetNote.Controllers
{
    public class TagHelperDemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        ///<summary>
        /// 1.environment 태그헬퍼 사용하기
        /// </summary>
        /// 
        public IActionResult EnvironmentDemo()
        {
            return View();
        }

        ///<summary>
        /// 2. 내장 태그 헬퍼에 접두사 붙이기
        /// </summary>
        /// 
        public IActionResult PrefixDemo()
        {
            return View();
        }

        ///<summary>
        /// 3. 사용자 정의 태그 헬퍼 테스트
        /// </summary>
        /// 
        public IActionResult MyTagHelperDemo()
        {
            return View();
        }

        ///<summary>
        /// 4. 커스텀 태그 헬퍼
        /// </summary>
        /// 
        public IActionResult EmailLinkDemo()
        {
            return View();
        }

        ///<summary>
        /// 5. 유닉스 시간 변경기 태그 헬퍼 사용 테스트
        /// </summary>
        /// 
        public IActionResult TagHelperDemo()
        {
            return View();
        }

        ///<summary>
        /// 6. 페이징 헬퍼
        /// </summary>
        /// 
        public IActionResult PagingHelperDemo()
        {
            return View();
        }

        ///<summary>
        /// 7. Cache태그 헬퍼
        /// </summary>
        /// 
        public IActionResult CacheDemo()
        {
            return View();
        }
    }
}
