// See https://aka.ms/new-console-template for more information
using HighLowGame.App;

int targetNumber =  Random.Shared.Next(1, 11);

HighLowTestGuess game = new(targetNumber)
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

    string result = game.TestGuess(userGuess);
    if (result == "Correct!"){
        Console.WriteLine($"You won with {game.NumberOfGuesses} guess(es)!\n");
        break;
    } else {
        Console.WriteLine(result);
    }
}
