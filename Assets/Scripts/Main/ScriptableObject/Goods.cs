using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System;
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

    public UnityEvent<Action<int>> Event;
}
