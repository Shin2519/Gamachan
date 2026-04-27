public struct ChallengeScoreResult
{
    // 新評価5段階
    public int excellentScore;
    public int perfectScore;
    public int greatScore;
    public int goodScore;
    public int badScore;

    // ボーナス類
    public int zeroYenBonus;
    public int goldenBonus;
    public int comboBonus;
    public int speedBonus;

    // コイン・お釣り
    public int coinScore;
    public int totalChange;

    // 合計
    public int totalScore;

    // 配列化
    public int[] ToArray()
    {
        return new int[]
        {
            excellentScore,
            perfectScore,
            greatScore,
            goodScore,
            badScore,
            zeroYenBonus,
            goldenBonus,
            comboBonus,
            speedBonus,
            coinScore,
            totalChange,
            totalScore
        };
    }
}
