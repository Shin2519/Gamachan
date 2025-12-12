using UnityEngine;
using UnityEngine.UI;

public class ResultPanel : MonoBehaviour
{
    [Header("UI参照")]
    public Text perfectText;
    public Text greatText;
    public Text goodText;
    public Text badText;
    public Text changeBonusText;
    public Text goldenBonusText;
    public Text comboBonusText;
    public Text speedBonusText;
    public Text totalChangeText;
    public Text finalScoreText;

    [Header("評価回数")]
    public int perfectCount;
    public int greatCount;
    public int goodCount;
    public int badCount;

    [Header("評価ごとの点数設定 (Inspectorで調整可能)")]
    public int perfectPoint = 300;
    public int greatPoint = 200;
    public int goodPoint = 100;
    public int badPoint = -50;

    [Header("ボーナス設定 (Inspectorで調整可能)")]
    public int changeBonus;
    public int goldenBonus;
    public int comboBonus;
    public int speedBonus;

    [Header("その他")]
    public int totalChange; // おつり合計（マイナス対象）

    private int finalScore;

    public void ShowResult()
    {
        // 基本スコア計算
        int baseScore = (perfectCount * perfectPoint) +
                        (greatCount * greatPoint) +
                        (goodCount * goodPoint) +
                        (badCount * badPoint);

        // ボーナス合計
        int bonusScore = changeBonus + goldenBonus + comboBonus + speedBonus;

        // 最終スコア（おつり合計をマイナス）
        finalScore = baseScore + bonusScore - totalChange;

        // UIに数字だけ反映
        perfectText.text = (perfectCount * perfectPoint).ToString();
        greatText.text = (greatCount * greatPoint).ToString();
        goodText.text = (goodCount * goodPoint).ToString();
        badText.text = (badCount * badPoint).ToString();

        changeBonusText.text = changeBonus.ToString();
        goldenBonusText.text = goldenBonus.ToString();
        comboBonusText.text = comboBonus.ToString();
        speedBonusText.text = speedBonus.ToString();

        totalChangeText.text = "-" + totalChange.ToString(); 
        finalScoreText.text = finalScore.ToString();
    }
}


//ShowResultという変数を呼び出して起動する