using UnityEngine;

[CreateAssetMenu(fileName = "SettingScoreData", menuName = "Scriptable Objects/SettingScoreData")]
public class SettingScoreData : ScriptableObject
{
    [Header("Perfect時の加算ポイント")]
    public int EvalPerfect;
    [Header("Great時の加算ポイント")]
    public int EvalGreat;
    [Header("Good時の加算ポイント")]
    public int EvalGood;
    [Header("Bad時の減算ポイント")]
    public int EvalBad;
    [Header("おつりなしの時のボーナスポイント")]
    public int ZeroYenBonus;
    [Header("ゴールデンがまちゃんの時のボーナスポイント")]
    public int GoldenBonus;
    [Header("コンボ時のボーナス")]
    public int ComboStepBonus;
    [Header("最大コンボ")]
    public int ComboMaxBonus;
    [Header("スピードボーナス")]
    public int Speed15;
    public int Speed20;
    [Header("タイムリミット：商品数ボーナス")]
    public int ThreeItemScore;
    public int OneItemScore;
    [Header("タイムリミット:誤差スコア")]
    public int Diff0Score;
    public int Diff100Score;
    public int Diff250Score;
    public int Diff500Score;
    public int DiffOverScore;
    [Header("硬貨スコア")]
    public int Coin1;
    public int Coin5;
    public int Coin10;
    public int Coin50;
    public int Coin100;
    public int Coin500;
    [Header("チャレンジ：誤差スコア")]
    public int ChallengePerfectDiff;
    public int ChallengeDiff100;
    public int ChallengeDiff250;
    public int ChallengeDiff500;
}
