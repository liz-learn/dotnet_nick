using HighLowGame.App;

namespace AllTest;

public class HighLowTests
{
    private readonly HighLowGuess _underTest;

    public HighLowTests ()
    {
       _underTest = new HighLowGuess();
    }

    [Theory]
    [InlineData(10, 6, 5)]
    [InlineData(5, 5, 1)]
    [InlineData(1, 9, 9)]
    public void GuessNumberWorksAsExpected(int target, int firstGuess, int expectedNumTried)
    {
        (var actualResult, var actualNumTried) = RunMethodUntilSuccess(firstGuess, target);

        Assert.False(actualResult == 20);
        Assert.False(actualNumTried == 20);
        Assert.True(actualResult == target);
        Assert.True(actualNumTried == expectedNumTried);
    }

    private (int, int) RunMethodUntilSuccess(int userGuess, int target)
    {
        var defaultResult = 20;
        var defaultNumTried = 20;

        while (true)
        {
            var resEnum = _underTest.TestGuess(userGuess, target);
            var numGuesses = _underTest.NumberOfGuesses;
            
            if (numGuesses < 1 | numGuesses > 19)
                return (defaultResult, defaultNumTried);

            switch (resEnum)
            {
                case GuessResult.Correct:
                    return (userGuess, numGuesses);

                case GuessResult.TooHigh:
                    userGuess--;
                    continue;

                case GuessResult.TooLow:
                    userGuess++;
                    continue;
                
                case GuessResult.Undefined:
                    return (defaultResult, defaultNumTried);

                default:
                    return (defaultResult, defaultNumTried);
            }
        }
    }
}
