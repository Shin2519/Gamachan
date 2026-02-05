using UnityEngine;

public class ScoreCalculator : MonoBehaviour
{
    public static ScoreCalculator Instance;
    //[Header("評価スコア")]
    //[SerializeField] private int evalPerfect = 100;
    //[SerializeField] private int evalGreat = 70;
    //[SerializeField] private int evalGood = 40;
    //[SerializeField] private int evalBad = -50;

    //[Header("ボーナス")]
    //[SerializeField] private int zeroYenBonus = 200;
    //[SerializeField] private int goldenBonus = 300;

    //[Header("コンボボーナス")]
    //[SerializeField] private int comboStepBonus = 20;
    //[SerializeField] private int comboMaxBonus = 300;

    //[Header("スピードボーナス")]
    //[SerializeField] private int speed15 = 200;
    //[SerializeField] private int speed20 = 100;

    //[Header("タイムリミット：商品数ボーナス")]
    //[SerializeField] private int threeItemScore = 300;
    //[SerializeField] private int oneItemScore = 100;

    //[Header("タイムリミット：誤差スコア")]
    //[SerializeField] private int diff0Score = 300;
    //[SerializeField] private int diff100Score = 200;
    //[SerializeField] private int diff250Score = 100;
    //[SerializeField] private int diff500Score = 50;
    //[SerializeField] private int diffOverScore = 0;

    //[Header("硬貨スコア")]
    //[SerializeField] private int coin1 = 1;
    //[SerializeField] private int coin5 = 5;
    //[SerializeField] private int coin10 = 10;
    //[SerializeField] private int coin50 = 50;
    //[SerializeField] private int coin100 = 100;
    //[SerializeField] private int coin500 = 500;

    //[Header("チャレンジ：誤差スコア")]
    //[SerializeField] private int challengePerfectDiff = 300;
    //[SerializeField] private int challengeDiff100 = 200;
    //[SerializeField] private int challengeDiff250 = 100;
    //[SerializeField] private int challengeDiff500 = 50;
    [SerializeField]
    private ScoreSettings setdata;
    // 評価タイプ
    public enum EvalType { Perfect, Great, Good, Bad }

    // 評価判定
    public EvalType GetEvaluation(int target, int result)
    {
        int diff = Mathf.Abs(target - result);
        int change = result - target;

        if (change < 0)
            return EvalType.Bad;

        if (diff == 0 && change == 0)
            return EvalType.Perfect;

        bool isGreat =
            (diff >= 1 && diff <= 10 && change >= 1 && change <= 10) ||
            (diff == 0 && change >= 1 && change <= 10) ||
            (diff >= 1 && diff <= 10 && change == 0);

        if (isGreat)
            return EvalType.Great;

        if (diff >= 11)
            return EvalType.Good;

        return EvalType.Good;
    }

    // コンボボーナス
    public int GetComboBonus(int comboCount)
    {
        int step = comboCount / 3;
        int bonus = step * setdata.comboStepBonus;
        return Mathf.Min(bonus, setdata.comboMaxBonus);
    }

    // スピードボーナス
    public int GetSpeedBonus(float time)
    {
        if (time <= 15f) return setdata.speed15;
        if (time <= 20f) return setdata.speed20;
        return 0;
    }

    // 商品数ボーナス（タイムリミット）
    public int GetItemBonus(int itemCount)
    {
        if (itemCount >= 3) return setdata.threeItemScore;
        if (itemCount >= 1) return setdata.oneItemScore;
        return 0;
    }

    // 誤差スコア（タイムリミット）
    public int GetDiffScoreTimeLimit(int target, int result)
    {
        int diff = Mathf.Abs(target - result);

        if (diff == 0) return setdata.diff0Score;
        if (diff <= 100) return setdata.diff100Score;
        if (diff <= 250) return setdata.diff250Score;
        if (diff <= 500) return setdata.diff500Score;
        return setdata.diffOverScore;
    }

    // 硬貨スコア
    public int GetCoinScore(int c1, int c5, int c10, int c50, int c100, int c500)
    {
        return
            c1 * setdata.coin1 +
            c5 * setdata.coin5 +
            c10 * setdata.coin10 +
            c50 * setdata.coin50 +
            c100 * setdata.coin100 +
            c500 * setdata.coin500;
    }

    // チャレンジ：差スコア
    public int GetDiffScoreChallenge(int target, int result)
    {
        int diff = Mathf.Abs(target - result);

        if (diff == 0) return setdata.challengePerfectDiff;
        if (diff <= 100) return setdata.challengeDiff100;
        if (diff <= 250) return setdata.challengeDiff250;
        if (diff <= 500) return setdata.challengeDiff500;
        return 0;
    }

    // チャレンジ最終スコア
    public ChallengeScoreResult CalculateChallenge(SendData data)
    {
        ChallengeScoreResult r = new ChallengeScoreResult();

        r.perfectScore = data.total_Data.Perfect_Count * setdata.evalPerfect;
        r.greatScore = data.total_Data.Great_Count * setdata.evalGreat;
        r.goodScore = data.total_Data.Good_Count * setdata.evalGood;
        r.badScore = data.total_Data.Bad_Count * setdata.evalBad;

        r.zeroYenBonus = data.total_Data.Zero_Count * setdata.zeroYenBonus;
        r.goldenBonus = data.total_Data.Golden_Count * setdata.goldenBonus;
        r.comboBonus = GetComboBonus(data.total_Data.Combo_Count);
        //r.speedBonus = speedBonusTotal;
        r.speedBonus = 0;

        r.diffScore = GetDiffScoreChallenge(0, 0);
        r.coinScore = GetCoinScore(data.total_Data.c1_count, data.total_Data.c5_count, data.total_Data.c10_count, data.total_Data.c50_count, data.total_Data.c100_count, data.total_Data.c500_count);
        r.totalChange = data.total_Data.Total_Change_Amount;

        r.totalScore =
            r.perfectScore +
            r.greatScore +
            r.goodScore +
            r.badScore +
            r.zeroYenBonus +
            r.goldenBonus +
            r.comboBonus +
            r.speedBonus +
            r.diffScore +
            r.coinScore -
            r.totalChange;

        return r;
    }

    // タイムリミット最終スコア
    public TimeLimitScoreResult CalculateTimeLimit(int itemCount,int target, int result,int speedBonusTotal,SendData data)
    {
        TimeLimitScoreResult r = new TimeLimitScoreResult();

        r.itemBonus = GetItemBonus(itemCount);
        r.diffScore = GetDiffScoreTimeLimit(target, result);
        r.coinScore = GetCoinScore(data.total_Data.c1_count, data.total_Data.c5_count, data.total_Data.c10_count, data.total_Data.c50_count, data.total_Data.c100_count, data.total_Data.c500_count);

        r.perfectScore = data.total_Data.Perfect_Count * setdata.evalPerfect;
        r.greatScore = data.total_Data.Great_Count * setdata.evalGreat;
        r.goodScore = data.total_Data.Good_Count * setdata.evalGood;
        r.badScore = data.total_Data.Bad_Count * setdata.evalBad;

        r.zeroYenBonus = data.total_Data.Zero_Count * setdata.zeroYenBonus;
        r.goldenBonus = data.total_Data.Golden_Count * setdata.goldenBonus;
        r.comboBonus = GetComboBonus(data.total_Data.Combo_Count);
        r.speedBonus = speedBonusTotal;

        r.totalChange = data.total_Data.Total_Change_Amount;

        r.totalScore =
            r.itemBonus +
            r.diffScore +
            r.coinScore +
            r.perfectScore +
            r.greatScore +
            r.goodScore +
            r.badScore +
            r.zeroYenBonus +
            r.goldenBonus +
            r.comboBonus +
            r.speedBonus -
            r.totalChange;

        return r;
    }
}
