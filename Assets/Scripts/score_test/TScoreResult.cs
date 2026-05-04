public struct TimeLimitScoreResult
{
    // 評価点数（Excellent / Perfect / Great / Good / Bad のどれか）
    public int evalScore;

    // タイムリミット専用
    public int itemBonus;
    public int speedBonus;
    public int comboBonus;

    // コイン・お釣り
    public int coinScore;
    public int totalChange;

    // 合計
    public int totalScore;

    public int[] ToArray()
    {
        return new int[]
        {
            evalScore,
            itemBonus,
            speedBonus,
            comboBonus,
            coinScore,
            totalChange,
            totalScore
        };
    }
}
