using UnityEngine;

[CreateAssetMenu(fileName = "AnythingSprite", menuName = "Scriptable Objects/AnythingSprite")]
public class AnythingSprite : ScriptableObject
{
    [SerializeField, Header("コンボの種類")]
    private Sprite[] Kindofcombo;
    [SerializeField, Header("評価の種類")]
    private Sprite[] Grade;
    [SerializeField, Header("評価のエフェクト")]
    private Sprite[] GradeEfect;

    public int ComboNum => Kindofcombo.Length;

    public Sprite GetCombo(int num) => Kindofcombo[num];

    public Sprite GetGrade(int num) => Grade[num];

    public Sprite GetGradeEfect(int num) => GradeEfect[num];
}
