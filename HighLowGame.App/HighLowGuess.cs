namespace HighLowGame.App
{
    public class HighLowGuess {
        public int NumberOfGuesses = 0;
        public int TargetNumber = 0;

        public GuessResult TestGuess(int guess, int targetNumber)
        {
            NumberOfGuesses++;
            if (guess == targetNumber) {
                return GuessResult.Correct;
            }
            if (guess > targetNumber) {
                return GuessResult.TooHigh;
            }
            if (guess < targetNumber) {
                return GuessResult.TooLow;
            }
            return GuessResult.Undefined;
        }
    }
}