using Quiz;

// tworzenie obiektu typu Gra
var game = new Game();

// tworzenie obiektu typu Message
var message = new Message();

// wyświetlanie powitania
message.DisplayWelcomeScreen();

while(true)
{
    // losowanie pytania
    game.GetQuestion();

    // wyświetlanie pytania i pobieramy odpowiedź gracza
    int playerAnswer = game.CurrentQuestion.Display();

    // sprawdzamy poprawność odpowiedzi
    bool correct = game.CheckPlayerAnswer(playerAnswer);

    if (correct)
    {
        // metoda sprawdzająca czy ostatnia kategoria
        // i podnosząca ją jeżeli nie jest ostatnia
        if (game.IsLastCategory())
        {
            message.FinalScreen();
            break;
        }
        else
        {
            message.GoodAnswer();
        }
    }
    else
    {
        message.DisplayFailAndGameOver();
        break;
    }
}






