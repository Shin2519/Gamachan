using UnityEngine;

[CreateAssetMenu(fileName = "ScoreSettings", menuName = "Game/Score Settings")]
public class ScoreSettings : ScriptableObject
{
    [Header("評価スコア（新仕様）")]
    public int evalPerfect = 5000;  // 誤差0
    public int evalGreat = 1000;    // 誤差1〜500
    public int evalGood = 300;       // 誤差501〜1000
    public int evalBad = 100;        // 誤差1001以上
    public int evalMiss = -100;        // 指定金額未満

    [Header("ボーナス（共通）")]
    public int goldenBonus = 100;
    public int comboStepBonus = 100;
    public int comboMaxBonus = 500;
    public int speed15 = 100;
    public int speed20 = 50;

    [Header("タイムリミット：商品数ボーナス")]
    public int oneItemScore = 20;
    public int threeItemScore = 60;

    [Header("硬貨スコア（タイムリミット）")]
    public int coin1 = 50;
    public int coin5 = 30;
    public int coin10 = 20;
    public int coin50 = 10;
    public int coin100 = 5;
    public int coin500 = 2;
}
