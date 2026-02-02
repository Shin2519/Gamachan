using UnityEngine;

public class ScoreCalculator : MonoBehaviour
{
    public static ScoreCalculator Instance;
    [Header("評価スコア")]
    [SerializeField] private int evalPerfect = 100;
    [SerializeField] private int evalGreat = 70;
    [SerializeField] private int evalGood = 40;
    [SerializeField] private int evalBad = -50;

    [Header("ボーナス")]
    [SerializeField] private int zeroYenBonus = 200;
    [SerializeField] private int goldenBonus = 300;

    [Header("コンボボーナス")]
    [SerializeField] private int comboStepBonus = 20;
    [SerializeField] private int comboMaxBonus = 300;

    [Header("スピードボーナス")]
    [SerializeField] private int speed15 = 200;
    [SerializeField] private int speed20 = 100;

    [Header("タイムリミット：商品数ボーナス")]
    [SerializeField] private int threeItemScore = 300;
    [SerializeField] private int oneItemScore = 100;

    [Header("タイムリミット：誤差スコア")]
    [SerializeField] private int diff0Score = 300;
    [SerializeField] private int diff100Score = 200;
    [SerializeField] private int diff250Score = 100;
    [SerializeField] private int diff500Score = 50;
    [SerializeField] private int diffOverScore = 0;

    [Header("硬貨スコア")]
    [SerializeField] private int coin1 = 1;
    [SerializeField] private int coin5 = 5;
    [SerializeField] private int coin10 = 10;
    [SerializeField] private int coin50 = 50;
    [SerializeField] private int coin100 = 100;
    [SerializeField] private int coin500 = 500;

    [Header("チャレンジ：誤差スコア")]
    [SerializeField] private int challengePerfectDiff = 300;
    [SerializeField] private int challengeDiff100 = 200;
    [SerializeField] private int challengeDiff250 = 100;
    [SerializeField] private int challengeDiff500 = 50;

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
        int bonus = step * comboStepBonus;
        return Mathf.Min(bonus, comboMaxBonus);
    }

    // スピードボーナス
    public int GetSpeedBonus(float time)
    {
        if (time <= 15f) return speed15;
        if (time <= 20f) return speed20;
        return 0;
    }

    // 商品数ボーナス（タイムリミット）
    public int GetItemBonus(int itemCount)
    {
        if (itemCount >= 3) return threeItemScore;
        if (itemCount >= 1) return oneItemScore;
        return 0;
    }

    // 誤差スコア（タイムリミット）
    public int GetDiffScoreTimeLimit(int target, int result)
    {
        int diff = Mathf.Abs(target - result);

        if (diff == 0) return diff0Score;
        if (diff <= 100) return diff100Score;
        if (diff <= 250) return diff250Score;
        if (diff <= 500) return diff500Score;
        return diffOverScore;
    }

    // 硬貨スコア
    public int GetCoinScore(int c1, int c5, int c10, int c50, int c100, int c500)
    {
        return
            c1 * coin1 +
            c5 * coin5 +
            c10 * coin10 +
            c50 * coin50 +
            c100 * coin100 +
            c500 * coin500;
    }

    // チャレンジ：差スコア
    public int GetDiffScoreChallenge(int target, int result)
    {
        int diff = Mathf.Abs(target - result);

        if (diff == 0) return challengePerfectDiff;
        if (diff <= 100) return challengeDiff100;
        if (diff <= 250) return challengeDiff250;
        if (diff <= 500) return challengeDiff500;
        return 0;
    }

    // チャレンジ最終スコア
    public ChallengeScoreResult CalculateChallenge(
        int perfectCount, int greatCount, int goodCount, int badCount,
        int zeroBonusCount, int goldenBonusCount,
        int comboCount, int speedBonusTotal,
        int target, int result,
        int coinScore, int totalChangeAmount
    )
    {
        ChallengeScoreResult r = new ChallengeScoreResult();

        r.perfectScore = perfectCount * evalPerfect;
        r.greatScore = greatCount * evalGreat;
        r.goodScore = goodCount * evalGood;
        r.badScore = badCount * evalBad;

        r.zeroYenBonus = zeroBonusCount * zeroYenBonus;
        r.goldenBonus = goldenBonusCount * goldenBonus;
        r.comboBonus = GetComboBonus(comboCount);
        r.speedBonus = speedBonusTotal;

        r.diffScore = GetDiffScoreChallenge(target, result);
        r.coinScore = coinScore;
        r.totalChange = totalChangeAmount;

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
    public TimeLimitScoreResult CalculateTimeLimit(
        int itemCount,
        int target, int result,
        int c1, int c5, int c10, int c50, int c100, int c500,
        int perfectCount, int greatCount, int goodCount, int badCount,
        int zeroBonusCount, int goldenBonusCount,
        int comboCount, int speedBonusTotal,
        int totalChangeAmount
    )
    {
        TimeLimitScoreResult r = new TimeLimitScoreResult();

        r.itemBonus = GetItemBonus(itemCount);
        r.diffScore = GetDiffScoreTimeLimit(target, result);
        r.coinScore = GetCoinScore(c1, c5, c10, c50, c100, c500);

        r.perfectScore = perfectCount * evalPerfect;
        r.greatScore = greatCount * evalGreat;
        r.goodScore = goodCount * evalGood;
        r.badScore = badCount * evalBad;

        r.zeroYenBonus = zeroBonusCount * zeroYenBonus;
        r.goldenBonus = goldenBonusCount * goldenBonus;
        r.comboBonus = GetComboBonus(comboCount);
        r.speedBonus = speedBonusTotal;

        r.totalChange = totalChangeAmount;

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
