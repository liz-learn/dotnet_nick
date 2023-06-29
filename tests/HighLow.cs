using System.Collections;
using HighLowGame.App;

namespace AllTest;

public class HighLowTest
{

    private readonly HighLowGuess underTest;
    private int NumberOfGuesses = 0;


    [Theory]
    [InlineData(10, 5, 6)]
    [InlineData(5, 5, 1)]
    [InlineData(1, 9, 9)]
    public void GuessNumberWorksAsExpected(
        int target, int firstGuess, int expectedNumTried
    )
    {
        underTest = new HighLowGuess(target);
        resultHash = CreateHashtable();
        resultHash.Add("expectedTarget", target);
        resultHash.Add("firstGuess", firstGuess);
        result = RunMethodUntilSuccess(underTest, resultHash);
        AssertTrue(resultHash["expectedTarget"] == resultHash["actualTarget"]);
        AssertTrue(resultHash["expectedNumTried"] == resultHash["actualNumTried"]);
    }

    public Hashtable RunMethodUntilSuccess(HighLowGuess underTest, Hashtable resultHash)
    {
        int num = 0;
        int userGuess = resultHash["firstGuess"];
        while (underTest.NumberOfGuesses < 20 && underTest.NumberOfGuesses > 0)
        {
            GuessResult result = underTest.TestGuess(userGuess);
            if (result == GuessResult.Correct) {
                resultHash.Add("actualNumTried", underTest.NumberOfGuesses);
                resultHash.Add("actualTarget", userGuess);
                return resultHash;
                break;
            }
            if (result == GuessResult.TooHigh) {
                userGuess--;
                continue;
            }
            if (result == GuessResult.TooLow) {
                userGuess++;
            }
        }
        resultHash.Add("actualNumTried", underTest.NumberOfGuesses);
        return resultHash;

    }

    public Hashtable CreateHashtable()
    {
        Hashtable hashtable = new Hashtable();
        return hashtable;
    }
}
