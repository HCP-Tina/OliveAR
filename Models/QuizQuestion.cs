using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OliveAR.Models
{
    public class QuizQuestion
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public int Correct { get; set; }
        public List<QuizAnswer> Answers { get; set; }

        public QuizQuestion()
        {
            Answers = new List<QuizAnswer>();
        }
    }
}