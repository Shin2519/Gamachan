using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "UI", menuName = "Scriptable Objects/UI")]
public class UI : ScriptableObject
{
    [Header("通常時の表情")]
    public Sprite[] Kindofemotion; 
    [Header("ゲージがMaxになった時の表情")]
    public Sprite[] GoldenKindofemotion;
    [Header("コンボの種類")]
    public Sprite[] Kindofcombo;
    [Header("評価の種類")]
    public Sprite[] Grade;
    [Header("小銭の種類")]
    public GameObject[] Kindofsmallmoney;

    [Header("マウスカーソルに使うテクスチャ")]
    public Texture2D[] mouse;

    [Header("ゲージの最大値、最小値、上昇値")]
    public float Current;

    public int Min;

    public int Max;
}
