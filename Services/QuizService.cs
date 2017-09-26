using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using OliveAR.Models;
using OliveAR.Utilities;

namespace OliveAR.Services
{
    public interface IQuizService
    {
        Quiz GetQuiz(int id);
    }

    public class QuizService : IQuizService
    {
        private readonly IWebCache _webCache;
        private List<Quiz> _quizzes;
        private const string QuizKey = "Quizzes";
        private const string QuizPath = "~/Content/Quizzes.json";
        private const int NumberOfQuestions = 3;

        public QuizService(IWebCache webCache)
        {
            _webCache = webCache;
            LoadQuizzes();
        }

        public Quiz GetQuiz(int id)
        {
            var quiz = _quizzes.FirstOrDefault(q => q.Id == id);
            if (quiz != null)
            {
                return RandomizeQuiz(quiz);
            }
            return null;
        }

        private Quiz RandomizeQuiz (Quiz quiz)
        {
            if (quiz.Questions.Count > NumberOfQuestions)
            {
                var filtered = quiz.Questions.OrderBy(arg => Guid.NewGuid()).Take(NumberOfQuestions).ToList();
                var newQuiz = new Quiz(quiz.Id, quiz.Title, filtered);
                return newQuiz;
            }

            return quiz;
        }

        private void LoadQuizzes()
        {
            _quizzes = _webCache.Get<List<Quiz>>(QuizKey);

            if (_quizzes == null)
            {
                string path = HttpContext.Current.Server.MapPath(QuizPath);
                using (StreamReader file = File.OpenText(path))
                {
                    var serializer = new JsonSerializer
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    };
                    _quizzes = (List<Quiz>)serializer.Deserialize(file, typeof(List<Quiz>));
                }
                _webCache.Insert(QuizKey, _quizzes);
            }
        }
    }
}