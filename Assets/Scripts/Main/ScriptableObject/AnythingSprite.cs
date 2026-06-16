using UnityEngine;

[CreateAssetMenu(fileName = "AnythingSprite", menuName = "Scriptable Objects/AnythingSprite")]
public class AnythingSprite : ScriptableObject
{
    [Header("コンボの種類")]
    public Sprite[] Kindofcombo;
    [Header("評価の種類")]
    public Sprite[] Grade;
}
