using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OliveAR.Services;
using OliveAR.Utilities;

namespace OliveAR.Controllers
{
    [RoutePrefix("Quiz")]
    public class QuizController : Controller
    {
        private readonly IQuizService _iQuizService;

        public QuizController(IQuizService iQuizService)
        {
            _iQuizService = iQuizService;
        }

        [Route("")]
        [HttpGet]
        public ActionResult Index(int quizId)
        {
            var quiz = _iQuizService.GetQuiz(quizId);
            return new JsonCCResult(quiz, JsonRequestBehavior.AllowGet);
        }
    }
}