using HighLowGame.App;

namespace AllTest;

public class HighLowTests
{
    public HighLowGuess underTest;

    public HighLowTests ()
    {
       underTest = new HighLowGuess();
    }

    public int NumberOfGuesses = 0;

    [Theory]
    [InlineData(10, 6, 5)]
    [InlineData(5, 5, 1)]
    [InlineData(1, 9, 9)]
    public void GuessNumberWorksAsExpected(int target, int firstGuess, int expectedNumTried)
    {
        (int ActualResult, int ActualNumTried) = RunMethodUntilSuccess(firstGuess, target);

        Assert.False(ActualResult == 20);
        Assert.False(ActualNumTried == 20);
        Assert.True(ActualResult == target);
        Assert.True(ActualNumTried == expectedNumTried);
    }

    public (int ActualResult, int ActualNumTried) RunMethodUntilSuccess(int userGuess, int target)
    {
        int actualResult = 20;
        int actualNumTried = 20;

        while (true){
            GuessResult resEnum = underTest.TestGuess(userGuess, target);

            if (resEnum == GuessResult.Correct) {
                return (userGuess, underTest.NumberOfGuesses);
            }

            if (resEnum == GuessResult.TooHigh) {
                userGuess--;
                continue;
            }

            if (resEnum == GuessResult.TooLow) {
                userGuess++;
                continue;
            }
            return (actualResult, actualNumTried);
        }
    }
}
