using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OliveAR.Controllers
{
    public class QuizController : Controller
    {
        // GET: Quiz
        public JsonResult Index(int quizId)
        {
            var result = new JsonResult
            {
                Data = new { Question = "What's your favorite color?", Answer = "Red" },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
            return result;
        }
    }
}