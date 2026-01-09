public struct TimeLimitScoreResult
{
    public int itemBonus;
    public int diffScore;
    public int coinScore;

    public int perfectScore;
    public int greatScore;
    public int goodScore;
    public int badScore;

    public int zeroYenBonus;
    public int goldenBonus;
    public int comboBonus;
    public int speedBonus;

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
            itemBonus,
            diffScore,
            coinScore,
            zeroYenBonus,
            goldenBonus,
            comboBonus,
            speedBonus,
            totalChange,
            totalScore
        };
    }
}
