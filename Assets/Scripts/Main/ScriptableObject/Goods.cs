using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public struct IceCream
{
    public Sprite GoodsSprite;

    public int Amount;
}
[System.Serializable]
public struct Onigiri
{
    public Sprite GoodsSprite;

    public int Amount;
}
[System.Serializable]
public struct GreenTea
{
    public Sprite GoodsSprite;

    public int Amount;
}
[System.Serializable]
public struct Ramen
{
    public Sprite GoodsSprite;

    public int Amount;
}
[System.Serializable]
public struct Sandwich
{
    public Sprite GoodsSprite;

    public int Amount;
}
[System.Serializable]
public struct Chicken
{
    public Sprite GoodsSprite;

    public int Amount;
}
[System.Serializable]
public struct Bread
{
    public Sprite GoodsSprite;

    public int Amount;
}
[System.Serializable]
public struct PotatoChips
{
    public Sprite GoodsSprite;

    public int Amount;
}
[System.Serializable]
public struct RegiBags
{
    public Sprite GoodsSprite;

    public int Amount;
}
[System.Serializable]
public struct Lanchs
{
    public Sprite GoodsSprite;

    public int Amount;
}
[CreateAssetMenu(fileName = "Goods", menuName = "Scriptable Objects/Goods")]
public class Goods : ScriptableObject
{
    public IceCream[] SomeIceCream;
    public Onigiri[] SomeOnigiri;
    public GreenTea[] SomeGreenTea;
    public Ramen[] SomeRamen;
    public Sandwich[] SomeSandwich;
    public Chicken[] SomeChicken;
    public Bread[] SomeBread;
    public PotatoChips[] SomePotatoChips;
    public RegiBags[] SomeRegiBags;
    public Lanchs[] SomeLanchs;
}
