using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    public class Game
    {
        // 100, 200, 300, 400, 500, 750, 1000

        // zacząć od ustawienia listy kategorii
        // sprawdzamy czy można podnieść kategorię, jeśli tak to ją podnosimy
        // jesli nie to oznacza, że to było ostatnie pytanie 

        public Game()
        {
            CreateAllQuestions();
           
            Random = new Random();
            //Categories = new List<int> { 100, 200, 300, 400, 500, 750, 1000 };
            Categories = Questions
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            CurrentCategory = Categories[CurrentCategoryIndex];
        }

        public int CurrentCategory { get; set; }
        public List<Question> Questions { get; set; }
        public Question CurrentQuestion { get; set; }
        public Random Random { get; set; }
        public List<int> Categories { get; set; }
        public int CurrentCategoryIndex { get; set; }

        private void CreateAllQuestions()
        {
            var path =  Directory.GetCurrentDirectory() + "\\questions.json";
            var text = File.ReadAllText(path);
            Questions = JsonConvert.DeserializeObject<List<Question>>(text);
        }

        public void GetQuestion()
        {
            // wybieramy tylko pytania o wartości CurrentCategory
            var questionsCat = Questions.Where(x => x.Category == CurrentCategory).ToList();

            // losujemy liczbę
            var number = Random.Next(0, questionsCat.Count);

            // wybieramy pytanie z listy na podstawie wylosowanej liczby
            var question = questionsCat[number];

            // sortujemy losowo kolejnośc odpowiedzi na wylosowane pytanie
            question.Answers = question.Answers.OrderBy(x => Random.Next()).ToList();

            // zapisujemy wartości ShowOrder (od 1 do 4)
            var index = 1;
            foreach (var answer in question.Answers)
            {
                answer.ShowOrder = index;
                index++;
            }
            
            CurrentQuestion = question;
        }

        // sprawdzanie poprawności odpowiedzi gracza
        public bool CheckPlayerAnswer(int playerNumber)
        {
            // wybieramy odpowiedź na ppodstawie podanej wartosci = wiedząc że to jest ShowOrder
            var answer = CurrentQuestion.Answers.FirstOrDefault(x => x.ShowOrder == playerNumber);
            return answer.IsCorrect;
        }


        public bool IsLastCategory()
        {
            // jeżeli to była ostatnia kategoria to zwarcamy true;
            // a jeżeli nie to podnosimy kategorię na następną i zwaracamy false
            if (CurrentCategoryIndex < Categories.Count - 1)
            {
                CurrentCategoryIndex++;
                CurrentCategory = Categories[CurrentCategoryIndex];
                return false;
            }

            return true;
        }
    }
}
