using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    public class Game
    {
        public Game()
        {
            CreateQuestions();
            CurrentCategory= 100;
        }
       
        public List<Question> AllQuestions { get; set; }
        public int CurrentCategory { get; set; }
        public Question CurrentQuestion { get; set; }

        public void CreateQuestions()
        {
            AllQuestions = new List<Question>();
            var q = new Question()
            {
                Id = 1,
                Category = 100,
                Content = "Jak miał na imię Einstein?",
            };

            var a1 = new Answer()
            {
                Id = 1,
                Content = "Albert",
                IsCorrect= true
            };
            q.Answers.Add(a1);

            var a2 = new Answer()
            {
                Id = 2,
                Content = "Aaron",
                IsCorrect = false
            };

            q.Answers.Add(a2);

            var a3 = new Answer()
            {
                Id = 3,
                Content = "Anthony",
                IsCorrect = false
            };

            q.Answers.Add(a3);

            var a4 = new Answer()
            {
                Id = 4,
                Content = "Basia",
                IsCorrect = false
            };

            q.Answers.Add(a4);
            AllQuestions.Add(q);

        }

        public void GetQuestionFromCategory()
        {
            CurrentQuestion = AllQuestions[0];
        }
    }
}
