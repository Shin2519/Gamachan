using UnityEngine;

[CreateAssetMenu(fileName = "ScoreSettings", menuName = "Game/Score Settings")]
public class ScoreSettings : ScriptableObject
{
    [Header("条件1：商品数ボーナス（タイムリミット）")]
    public int oneItemScore = 20;
    public int threeItemScore = 60;

    [Header("条件2：誤差スコア（タイムリミット）")]
    public int diff0Score = 500;
    public int diff100Score = 100;
    public int diff250Score = 50;
    public int diff500Score = 10;
    public int diffOverScore = 0;

    [Header("条件3：硬貨スコア（タイムリミット）")]
    public int coin1 = 50;
    public int coin5 = 30;
    public int coin10 = 20;
    public int coin50 = 10;
    public int coin100 = 5;
    public int coin500 = 2;

    [Header("評価スコア（共通）")]
    public int evalPerfect = 300;
    public int evalGreat = 200;
    public int evalGood = 100;
    public int evalBad = -50;

    [Header("ボーナス（共通）")]
    public int zeroYenBonus = 50;
    public int goldenBonus = 100;
    public int comboStepBonus = 100;
    public int comboMaxBonus = 500;
    public int speed15 = 100;
    public int speed20 = 50;

    [Header("チャレンジ：差スコア")]
    public int challengePerfectDiff = 500;
    public int challengeDiff100 = 100;
    public int challengeDiff250 = 50;
    public int challengeDiff500 = 10;
}
