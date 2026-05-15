using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public struct GoodsItem
{
    public Sprite GoodsSprite;

    public int Amount;
}
[System.Serializable]
public struct GoodsGenre
{
    public string GoodsSprite;

    public GoodsItem[] Items;
}
[CreateAssetMenu(fileName = "Goods", menuName = "Scriptable Objects/Goods")]
public class Goods : ScriptableObject
{
    public GoodsGenre[] Genres;
}
