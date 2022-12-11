using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    public class Question
    {
        public int Id { get; set; }
        public int Category { get; set; }
        public string Content { get; set; }
        public List<Answer> Answers { get; set; } = new List<Answer>();


        void ShowQuestion()
        {
            Console.WriteLine();
            Console.WriteLine($"Pytanie za {Category} pkt");
            Console.WriteLine();
            Console.WriteLine(Content);
            Console.WriteLine();
            foreach (var a in Answers)
            {
                Console.WriteLine($"{a.ShowOrder}. {a.Content}");
            }
            Console.WriteLine();
            Console.Write("Wybierz numer poprawnej odpowiedzi: 1, 2, 3 lub 4 => ");
        }



        public int Display()
        {
            ShowQuestion();
            var playerAnswer = Console.ReadLine();
            bool correctKey = IsCorrectKey(playerAnswer);
            while(!correctKey)
            {
                Console.Clear();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wcisnałeś nieprawidłowy klawisz ...");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                ShowQuestion();
                playerAnswer = Console.ReadLine();
                correctKey = IsCorrectKey(playerAnswer);
            }

            return  int.Parse(playerAnswer);
        }


        bool IsCorrectKey(string key)
        {
            bool isNumber = int.TryParse(key, out int number);
            if (!isNumber)
            {
                return false;
            }
            else
            {
                if (number > 0 && number < 5)
                    return true;
            }

            return false;
        }

        
    }
}
