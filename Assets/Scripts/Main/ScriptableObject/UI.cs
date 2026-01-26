using UnityEngine;
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
}
