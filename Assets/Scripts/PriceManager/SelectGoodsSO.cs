using System;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using JetBrains.Annotations;

[CreateAssetMenu(fileName = "SelectGoodsSO", menuName = "Scriptable Objects/SelectGoodsSO")]
public class SelectGoodsSO : ScriptableObject
{
    public List<data> dataList;
    public List<DamyData> damyDatas;
    public List<ChooseData> chooseDatas;
    
    /// <summary>
    /// 合計金額
    /// </summary>
    public int total;

    /// <summary>
    /// 目標金額
    /// </summary>
    public int target;
}

[Serializable]
public class data//正解
{
    /// <summary>
    /// 商品の画像
    /// </summary>
    public Sprite image;

    /// <summary>
    /// 商品の単価
    /// </summary>
    public int price;

}

[Serializable]
public class DamyData//ボタンUIimageリスト
{
    public Sprite image;

}


[Serializable]
public class ChooseData//選択肢ボタンUIimage....選択肢の数
{
    public Sprite[] image;

}
