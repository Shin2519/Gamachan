using UnityEngine;

public class ScoreCalculator : MonoBehaviour
{
    public static ScoreCalculator Instance;
    
    [SerializeField]
    private ScoreSettings setdata;
    // 評価タイプ
    public enum EvalType { Perfect, Great, Good, Bad }

    void Awake()
    {
        Instance = this;
    }
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

    public int[] ScoreData(SendData senddata)
    {
        int[] data = new int[11];

        data[0] = senddata.total_Data.Perfect_Count * setdata.evalPerfect;
        data[1] = senddata.total_Data.Great_Count * setdata.evalGreat;
        data[2] = senddata.total_Data.Good_Count * setdata.evalGood;
        data[3] = senddata.total_Data.Bad_Count * setdata.evalBad;
        data[4] = senddata.total_Data.Bad_Count * setdata.evalBad;
        data[5] = GetCoinScore(senddata.total_Data.c500_count, senddata.total_Data.c100_count, senddata.total_Data.c50_count, senddata.total_Data.c10_count, senddata.total_Data.c5_count, senddata.total_Data.c1_count);
        data[6] = senddata.total_Data.Zero_Count * setdata.zeroYenBonus;
        data[7] = senddata.total_Data.Golden_Count * setdata.goldenBonus;
        data[8] = GetComboBonus(senddata.total_Data.Combo_Count);
        data[9] = senddata.total_Data.Total_Change_Amount;
        data[10] = data[0] + data[1] + data[2] + data[3] + data[4] + data[5] + data[6] + data[7] + data[8] + data[9];

        return data;
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
