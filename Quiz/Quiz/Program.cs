using Quiz;

// tworzenie obiektu typu Gra
var game = new Game();

// tworzenie obiektu typu Message
var message = new Message();

// wyświetlanie powitania
message.DisplayWelcomeScreen();

// losowanie pytania
game.GetQuestion();

// wyświetlanie pytania i pobieramy odpowiedź gracza
int playerAnswer = game.CurrentQuestion.Display();

// sprawdzamy poprawność odpowiedzi
bool correct = game.CheckPlayerAnswer(playerAnswer);

if (correct)
{
    // HURRA
}
else
{
    message.DisplayFailAndGameOver();
}




