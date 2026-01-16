using UnityEngine;

public class ScoreCalculator : MonoBehaviour
{
    public ScoreSettings settings;

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
        int bonus = step * settings.comboStepBonus;
        return Mathf.Min(bonus, settings.comboMaxBonus);
    }

    // スピードボーナス
    public int GetSpeedBonus(float time)
    {
        if (time <= 15f) return settings.speed15;
        if (time <= 20f) return settings.speed20;
        return 0;
    }

    // 条件1：商品数ボーナス（タイムリミット）
    public int GetItemBonus(int itemCount)
    {
        if (itemCount >= 3) return settings.threeItemScore;
        if (itemCount >= 1) return settings.oneItemScore;
        return 0;
    }

    // 条件2：誤差スコア（タイムリミット）
    public int GetDiffScoreTimeLimit(int target, int result)
    {
        int diff = Mathf.Abs(target - result);

        if (diff == 0) return settings.diff0Score;
        if (diff <= 100) return settings.diff100Score;
        if (diff <= 250) return settings.diff250Score;
        if (diff <= 500) return settings.diff500Score;
        return settings.diffOverScore;
    }

    // 条件3：硬貨スコア（タイムリミット）
    public int GetCoinScore(int c1, int c5, int c10, int c50, int c100, int c500)
    {
        return
            c1 * settings.coin1 +
            c5 * settings.coin5 +
            c10 * settings.coin10 +
            c50 * settings.coin50 +
            c100 * settings.coin100 +
            c500 * settings.coin500;
    }

    // チャレンジ：差スコア
    public int GetDiffScoreChallenge(int target, int result)
    {
        int diff = Mathf.Abs(target - result);

        if (diff == 0) return settings.challengePerfectDiff;
        if (diff <= 100) return settings.challengeDiff100;
        if (diff <= 250) return settings.challengeDiff250;
        if (diff <= 500) return settings.challengeDiff500;
        return 0;
    }

    // ★ チャレンジ最終スコア
    public ChallengeScoreResult CalculateChallenge(
        int perfectCount, int greatCount, int goodCount, int badCount,
        int zeroBonusCount, int goldenBonusCount,
        int comboCount, int speedBonusTotal,
        int target, int result,
        int coinScore, int totalChangeAmount
    )
    {
        ChallengeScoreResult r = new ChallengeScoreResult();

        r.perfectScore = perfectCount * settings.evalPerfect;
        r.greatScore = greatCount * settings.evalGreat;
        r.goodScore = goodCount * settings.evalGood;
        r.badScore = badCount * settings.evalBad;

        r.zeroYenBonus = zeroBonusCount * settings.zeroYenBonus;
        r.goldenBonus = goldenBonusCount * settings.goldenBonus;
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

    // ★ タイムリミット最終スコア
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

        r.perfectScore = perfectCount * settings.evalPerfect;
        r.greatScore = greatCount * settings.evalGreat;
        r.goodScore = goodCount * settings.evalGood;
        r.badScore = badCount * settings.evalBad;

        r.zeroYenBonus = zeroBonusCount * settings.zeroYenBonus;
        r.goldenBonus = goldenBonusCount * settings.goldenBonus;
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
