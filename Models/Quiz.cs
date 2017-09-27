using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OliveAR.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string BackgroundImage { get; set; }
        public string SmallImage { get; set; }
        public List<QuizQuestion> Questions { get; set; }

        public Quiz()
        {
            Questions = new List<QuizQuestion>();
        }

        public Quiz(int id, string title, string backgroundImage, string smallImage, List<QuizQuestion> questions)
        {
            Id = id;
            Title = title;
            BackgroundImage = backgroundImage;
            SmallImage = smallImage;
            Questions = questions;
        }
    }
}