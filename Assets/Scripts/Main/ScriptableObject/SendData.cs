using UnityEngine;
using System.Collections.Generic;
using NUnit.Framework;

[CreateAssetMenu(fileName = "SendData", menuName = "Scriptable Objects/SendData")]
public class SendData : ScriptableObject
{
    public struct Total_data
    {
        public int Perfect_Count;

        public int Great_Count;

        public int Good_Count;

        public int Bad_Count;

        public int Zero_Count;

        public int Total_Change_Amount;

        public int Combo_Count;
    }
    public Total_data total_Data;

    public List<GameObject> Money;
}
