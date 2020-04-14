using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace DotNetNote.Controllers
{
    //모델 클래스
    public class BoardSummaryModel
    {
        public int Id { get; set; }
        public string Alias { get; set; } // Notice, Free, Photo
        public string Title { get; set; }
        public string Name { get; set; }
        public DateTime PostDate { get; set; }
    }

    //[2] 리파지터리 클래스 : 네 개의 데이터를 담아 반환시켜주는 메서드 두개를 리파지터리 클래스로 구성
    public class BoardSummaryRepository
    {
        public List<BoardSummaryModel> GetAll()
        {
            //인 메모리 데이터베이스 => 실제 데이터베이스
            var lists = new List<BoardSummaryModel>()
            {
                new BoardSummaryModel
                {
                    Id = 1, Alias = "Notice", Name="홍길동",
                    Title = "공지사항입니다.", PostDate = DateTime.Now
                },
                new BoardSummaryModel
                {
                    Id = 2, Alias = "Free", Name="백두산",
                    Title = "자유게시판입니다.", PostDate = DateTime.Now
                },
                new BoardSummaryModel
                {
                    Id = 3, Alias = "Photo", Name="임꺽정",
                    Title = "사진 게시판입니다.", PostDate = DateTime.Now
                },
                new BoardSummaryModel
                {
                    Id = 4, Alias="Notice", Name="홍길동",
                    Title="공지사항입니다.", PostDate=DateTime.Now
                }
            };

            return lists;
        }

        public List<BoardSummaryModel> GetByAlias(string alias)
        {
            return GetAll().Where(b => b.Alias == alias).ToList();
        }
    }

    //[3] Web API :전체 레코드를 JSON으로 반환하거나 특정 별칭에 따른 JSON데이터를 출력하는 HTTP GET 메서드 두개 생성
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/boardSummaryApi")]
    public class BoardSummaryApiController : Controller
    {
        private BoardSummaryRepository _repository;

        public BoardSummaryApiController()
        {
            _repository = new BoardSummaryRepository();
        }

        [HttpGet]
        public IEnumerable<BoardSummaryModel> Get()  /*https://localhost:44373/Api/BoardSummaryApi*/
        {
            return _repository.GetAll();
        }

        [HttpGet("{alias}", Name ="Get")]
        public IEnumerable<BoardSummaryModel> Get(string alias)  /*https://localhost:44373/Api/BoardSummaryApi/Free*/
        {
            return _repository.GetByAlias(alias);
        }
    }

    //[4]컨트롤러 : HTML + Javascript코드를 동적으로 생성해 [3]을 제이쿼리로 호출해 그 결과를 문자열로 출력하는 내용
    public class BoardSummaryDemoController : Controller
    {
        public IActionResult Index()
        {
            string html = @"
                            <div id='print'></div>
                            <script src='http://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.4.1.min.js'></script>
                            <script src='/lib/jquery/dist/jquery.js'></script>
                            <script>
                                $(function(){
                                    $.getJSON('/api/BoardSummaryApi', function(data){
                                          var str = '<dl>';

                                        $.each(data, function(Index, entry){
                                          str += '<dt>' + entry.title +'</dt><dd>' + entry.name + '</dd>';
                                        });

                                          str += '</di>';
                                        $('#print').html(str);
                                    });
                                });
                            </script>";

                ContentResult cr = new ContentResult()
                {
                    ContentType = "text/html", Content = html
                };
                return cr;
            }
        }
    }

    //[Route("api/[controller]")]
    //public class BoardSummaryApiController : Controller
    //{
    //    // GET: api/<controller>
    //    [HttpGet]
    //    public IEnumerable<string> Get()
    //    {
    //        return new string[] { "value1", "value2" };
    //    }

    //    // GET api/<controller>/5
    //    [HttpGet("{id}")]
    //    public string Get(int id)
    //    {
    //        return "value";
    //    }

    //    // POST api/<controller>
    //    [HttpPost]
    //    public void Post([FromBody]string value)
    //    {
    //    }

    //    // PUT api/<controller>/5
    //    [HttpPut("{id}")]
    //    public void Put(int id, [FromBody]string value)
    //    {
    //    }

    //    // DELETE api/<controller>/5
    //    [HttpDelete("{id}")]
    //    public void Delete(int id)
    //    {
    //    }
    //}
