using System;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "SelectGoodsSO", menuName = "Scriptable Objects/SelectGoodsSO")]
public class SelectGoodsSO : ScriptableObject
{
    public List<data> dataList;   
}

[Serializable]
public class data
{
    /// <summary>
    /// 商品の画像
    /// </summary>
    [SerializeField] public Sprite image;

    /// <summary>
    /// 商品の単価
    /// </summary>
    public int price;

    /// <summary>
    /// 個数
    /// </summary>
    public int count;

    /// <summary>
    /// 合計金額
    /// </summary>
    public int total;
}
