using UnityEngine;

[CreateAssetMenu(fileName = "Sprite", menuName = "Scriptable Objects/Gama_SpriteRenderer")]
public class Gama_SpriteRenderer : ScriptableObject
{
    [SerializeField,Header("通常時の表情")]
    private Sprite[] Kindofemotion;
    [SerializeField, Header("ゲージがMaxになった時の表情")]
    private Sprite[] GoldenKindofemotion;

    public Sprite GetGamaEmotion_Normal(int num) => Kindofemotion[num];

    public Sprite GetGamaEmotion_Gold(int num) => GoldenKindofemotion[num];
}
