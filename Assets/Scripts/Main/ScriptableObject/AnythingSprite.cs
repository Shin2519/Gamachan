using UnityEngine;

[CreateAssetMenu(fileName = "AnythingSprite", menuName = "Scriptable Objects/AnythingSprite")]
public class AnythingSprite : ScriptableObject
{
    [SerializeField, Header("コンボの種類")]
    private Sprite[] Kindofcombo;
    [SerializeField, Header("評価の種類")]
    private Sprite[] Grade;

    public int ComboNum => Kindofcombo.Length;

    public Sprite GetCombo(int num) => Kindofcombo[num];

    public Sprite GetGrade(int num) => Grade[num];
}
