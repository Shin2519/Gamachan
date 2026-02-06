public struct ChallengeScoreResult
{
    public int perfectScore;
    public int greatScore;
    public int goodScore;
    public int badScore;

    public int zeroYenBonus;
    public int goldenBonus;
    public int comboBonus;
    public int speedBonus;

    public int diffScore;
    public int coinScore;
    public int totalChange;

    public int totalScore;

    public int[] ToArray()
    {
        return new int[]
        {
            perfectScore,
            greatScore,
            goodScore,
            badScore,
            zeroYenBonus,
            goldenBonus,
            comboBonus,
            speedBonus,
            diffScore,
            coinScore,
            totalChange,
            totalScore
        };
    }
}
