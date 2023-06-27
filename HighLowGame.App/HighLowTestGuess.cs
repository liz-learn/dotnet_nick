namespace HighLowGame.App
{
    public class HighLowTestGuess {
        public int NumberOfGuesses = 0;
        public int TargetNumber;

        public HighLowTestGuess (int targetNumber) {
            TargetNumber = targetNumber;
        }

        public string TestGuess(int guess)  {
            NumberOfGuesses++;
            if (guess == TargetNumber) {
                return "Correct!";
            }
            if (guess > TargetNumber) {
                return "Too high!";
            }
            if (guess < TargetNumber) {
                return "Too low!";
            }
            return "";
        }

    }
}