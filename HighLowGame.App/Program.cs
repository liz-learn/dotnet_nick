// See https://aka.ms/new-console-template for more information
using HighLowGame.App;

int targetNumber =  Random.Shared.Next(1, 11);

HighLowGuess game = new(targetNumber)
{
    TargetNumber = targetNumber,
    NumberOfGuesses = 0
};


while (true) {
    Console.WriteLine("enter guess: ");
    var userInput = Console.ReadLine();
    if (!int.TryParse(userInput, out var userGuess)){
        continue;
    }

    GuessResult result = game.TestGuess(userGuess);
    if (result == GuessResult.Correct){
        Console.WriteLine($"You won with {game.NumberOfGuesses} guess(es)!\n");
        break;
    } else {
        Console.WriteLine(result);
    }
}
