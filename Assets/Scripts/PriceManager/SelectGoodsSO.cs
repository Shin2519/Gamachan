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


    [Serializable]
    public class data
    {
        /// <summary>
        /// ¤•i‚Ì‰æ‘œ
        /// </summary>
        [SerializeField]public Image image;
        /// <summary>
        /// ¤•i‚Ì’P‰¿
        /// </summary>
        public int price;
    }

}
