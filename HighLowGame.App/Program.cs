// See https://aka.ms/new-console-template for more information

var targetNumber = Random.Shared.Next(1, 11);
var numberGuesses = 1;
var userInput = "";

while (true) {
    Console.Write("enter guess: ");
    userInput = Console.ReadLine();
    if (!int.TryParse(userInput, out var userGuess)){
        continue;
    }

    if (targetNumber == userGuess){
        Console.Write($"You won with {numberGuesses} guesses!\n");
        break;
    }

    if (userGuess > targetNumber){
        Console.Write("Too High!");
    } else{
        Console.Write("Too Low!");
    }

    numberGuesses++;
}
