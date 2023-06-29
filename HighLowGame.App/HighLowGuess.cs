namespace HighLowGame.App
{
    public class HighLowGuess {
        public int NumberOfGuesses = 0;
        public int TargetNumber;

        public HighLowGuess (int targetNumber) {
            TargetNumber = targetNumber;
        }

        public GuessResult TestGuess(int guess)
        {
            NumberOfGuesses++;
            if (guess == TargetNumber) {
                return GuessResult.Correct;
            }
            if (guess > TargetNumber) {
                return GuessResult.TooHigh;
            }
            if (guess < TargetNumber) {
                return GuessResult.TooLow;
            }
            return GuessResult.Undefined;
        }
    }
}