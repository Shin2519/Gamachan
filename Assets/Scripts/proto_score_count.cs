using UnityEngine;
using UnityEngine.UI;

//仮アタッチの際はリザルトパネルに


public class proto_score_count : MonoBehaviour
{
    [Header("基本スコア入力")]
    public int perfectCount;
    public int greatCount;
    public int goodCount;
    public int badCount;

    [Header("ボーナス入力")]
    public int otsuriBonus;
    public int goldenBonus;
    public int comboBonus;
    public int speedBonus;

    [Header("おつり合計")]
    public int otsuriTotal;

    [Header("UI参照")]
    public Text perfectText;
    public Text greatText;
    public Text goodText;
    public Text badText;
    public Text bonusText;
    public Text otsuriText;
    public Text finalScoreText;

    private int finalScore;

    /// <summary>
    /// リザルト計算と表示
    /// </summary>
    public void ShowResult(string playerName, string mode)
    {
        // 基本スコア計算（点数は仮に固定値を設定）
        int baseScore = (perfectCount * 100) +
                        (greatCount * 70) +
                        (goodCount * 50) +
                        (badCount * 10);

        // ボーナス合計
        int bonusScore = otsuriBonus + goldenBonus + comboBonus + speedBonus;

        // 最終スコア
        finalScore = baseScore + bonusScore + otsuriTotal;

        // UIに反映
        perfectText.text = $"Perfect: {perfectCount} × 100 = {perfectCount * 100}";
        greatText.text = $"Great: {greatCount} × 70 = {greatCount * 70}";
        goodText.text = $"Good: {goodCount} × 50 = {goodCount * 50}";
        badText.text = $"Bad: {badCount} × 10 = {badCount * 10}";
        bonusText.text = $"Bonus: {bonusScore}";
        otsuriText.text = $"Otsuri Total: {otsuriTotal}";
        finalScoreText.text = $"Final Score: {finalScore}";

        // ランキング判定
        AddToRanking(playerName, mode);
    }

    /// <summary>
    /// ランキングに追加（上位5位以内なら保存）
    /// </summary>
    private void AddToRanking(string playerName, string mode)
    {
        // 上位5位以内かどうかをチェック
        var rankingList = (mode == "Challenge") ?
            RankingManager.Instance.challengeRanking :
            RankingManager.Instance.timeLimitRanking;

        // 仮にランキングが5件未満なら必ず追加
        if (rankingList.Count < 5 || finalScore > rankingList[rankingList.Count - 1].score)
        {
            RankingManager.Instance.AddScore(mode, playerName, finalScore);
        }
        // 圏外なら保存せず破棄（タイトル戻り時にリセットされる）
    }
}
