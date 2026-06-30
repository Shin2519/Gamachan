using UnityEngine;

public class ScoreCalculator : MonoBehaviour
{
    public static ScoreCalculator Instance;

    [SerializeField]
    private ScoreSettings setdata;

    // 5段階評価
    public enum EvalType { Perfect, Great, Good, Bad, Miss }

    void Awake()
    {
        Instance = this;
    }

    // 評価ロジック
    public EvalType GetEvaluation(int target, int result)
    {
        int diff = Mathf.Abs(target - result);
        int change = result - target;

        // 指定金額に届いていない 
        if (change < 0)
            return EvalType.Miss;

        // 誤差 0 
        if (diff == 0)
            return EvalType.Perfect;

        // 誤差 ±1 ～ ±500
        if (diff <= 500)
            return EvalType.Great;

        // 誤差 ±501 ～ ±1000
        if (diff <= 1000)
            return EvalType.Good;

        // 誤差 ±1001 以上
        return EvalType.Bad;
    }

    // 評価ごとの点数
    public int GetEvalScore(EvalType eval)
    {
        switch (eval)
        {
            case EvalType.Perfect: return 5000;
            case EvalType.Great: return 1000;
            case EvalType.Good: return 300;
            case EvalType.Bad: return 100;
            case EvalType.Miss: return -100;
        }
        return 0;
    }

    // コンボボーナス
    int GetComboBonus(int comboCount)
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

    // 硬貨スコア
    int GetCoinScore(int c1, int c5, int c10, int c50, int c100, int c500)
    {
        return
            c1 * setdata.coin1 +
            c5 * setdata.coin5 +
            c10 * setdata.coin10 +
            c50 * setdata.coin50 +
            c100 * setdata.coin100 +
            c500 * setdata.coin500;
    }

    // チャレンジ最終スコア
    public ChallengeScoreResult CalculateChallenge()
    {
        ChallengeScoreResult r = new ChallengeScoreResult();
        r.perfectScore = AnythingData.gradecount.PerfectCount * 5000;
        r.greatScore = AnythingData.gradecount.GreatCount * 1000;
        r.goodScore = AnythingData.gradecount.GoodCount * 300;
        r.badScore = AnythingData.gradecount.BadCount * 100;
        r.missScore = AnythingData.gradecount.MissCount * -100;
        r.goldenBonus = AnythingData.anotherbonus.GoldenCount;
        r.comboBonus = AnythingData.anotherbonus.ComboBonusCount;
        r.speedBonus = AnythingData.anotherbonus.SpeedCount;

        r.coinScore = AnythingData.anotherbonus.CoinBonusCount;

        r.totalChange = AnythingData.anotherbonus.TotalChangeCount;

        r.totalScore =
            r.perfectScore +
            r.greatScore +
            r.goodScore +
            r.badScore +
            r.missScore +
            r.goldenBonus +
            r.comboBonus +
            r.speedBonus +
            r.coinScore -
            r.totalChange;

        return r;
    }

    // リザルト画面用の10項目配列
    public int[] ScoreData(SendData senddata)
    {
        int[] data = new int[10];

        data[0] = senddata.total_Data.Perfect_Count * 5000;
        data[1] = senddata.total_Data.Great_Count * 1000;
        data[2] = senddata.total_Data.Good_Count * 300;
        data[3] = senddata.total_Data.Bad_Count * 100;
        data[4] = senddata.total_Data.Miss_Count * -100;

        data[5] = senddata.total_Data.Golden_Count * setdata.goldenBonus;
        data[6] = GetComboBonus(senddata.total_Data.Combo_Count);
        data[7] = senddata.total_Data.Total_Change_Amount;

        data[8] =
            data[0] + data[1] + data[2] + data[3] + data[4] +
            data[5] + data[6] + data[7] + data[8] +
            GetCoinScore(
                senddata.total_Data.c1_count,
                senddata.total_Data.c5_count,
                senddata.total_Data.c10_count,
                senddata.total_Data.c50_count,
                senddata.total_Data.c100_count,
                senddata.total_Data.c500_count
            );

        return data;
    }

    // タイムリミット最終スコア
    public TimeLimitScoreResult CalculateTimeLimit(
        int itemCount, int target, int result, int speedBonusTotal, SendData data)
    {
        TimeLimitScoreResult r = new TimeLimitScoreResult();

        r.itemBonus = GetItemBonus(itemCount);

        // 評価ロジック
        EvalType eval = GetEvaluation(target, result);
        r.evalScore = GetEvalScore(eval);

        r.coinScore = GetCoinScore(
            data.total_Data.c1_count,
            data.total_Data.c5_count,
            data.total_Data.c10_count,
            data.total_Data.c50_count,
            data.total_Data.c100_count,
            data.total_Data.c500_count
        );

        r.speedBonus = speedBonusTotal;
        r.comboBonus = GetComboBonus(data.total_Data.Combo_Count);
        r.totalChange = data.total_Data.Total_Change_Amount;

        r.totalScore =
            r.itemBonus +
            r.evalScore +
            r.coinScore +
            r.speedBonus +
            r.comboBonus -
            r.totalChange;

        return r;
    }
}
