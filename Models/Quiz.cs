using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OliveAR.Models
{
    public class Quiz
    {
        public int QuizId { get; set; }
        public string Title { get; set; }
        public List<QuizQuestion> Questions { get; set; }

        public Quiz()
        {
            Questions = new List<QuizQuestion>();
        }

        public Quiz(int id, string title, List<QuizQuestion> questions)
        {
            QuizId = id;
            Title = title;
            Questions = questions;
        }
    }
}