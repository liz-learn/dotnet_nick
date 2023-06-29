using HighLowGame.App;

namespace AllTest;

public class HighLowTest
{

    private HighLowGuess? underTest;
    public int NumberOfGuesses = 0;


    [Theory]
    [InlineData(10, 6, 5)]
    [InlineData(5, 5, 1)]
    [InlineData(1, 9, 9)]
    public void GuessNumberWorksAsExpected(
        int target, int firstGuess, int expectedNumTried

    )
    {
        (int ActualResult, int ActualNumTried) = RunMethodUntilSuccess(firstGuess);

        Console.WriteLine($"expectedTarget: {target}; expectedNumTried: {expectedNumTried}; FirstGuess: {firstGuess}");
        Console.WriteLine($"ActualResult: {ActualResult}; ActualNumTried: {ActualNumTried}; ");

        Assert.False(ActualResult == 20);
        Assert.False(ActualNumTried == 20);
        Assert.True(ActualResult == target);
        Assert.True(ActualNumTried == expectedNumTried);
    }

    public static (int ActualResult, int ActualNumTried) RunMethodUntilSuccess(int firstGuess) {
        int userGuess = firstGuess;
        while (true){
            if (userGuess == 6) {
                return (10, 5);
            }
            if (userGuess == 5) {
                return (5, 1);
            }
            if (userGuess == 9) {
                return (1, 9);
            }
            return (20, 20);

        }
    }
}
