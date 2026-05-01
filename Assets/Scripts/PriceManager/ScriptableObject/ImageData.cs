using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ImageData", menuName = "Scriptable Objects/ImageData")]
public class ImageData : ScriptableObject
{
   public List<datapool> datapools;
}


[Serializable]
public class datapool
{
    [SerializeField, Header("¤•i‰æ‘œ")] public Sprite image;//¤•i‚Ì‰æ‘œ
    [SerializeField, Header("‹àŠz")] public int price;//¤•i‚Ì‹àŠz
}

