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

        public int c1_count;

        public int c5_count;

        public int c10_count;

        public int c50_count;

        public int c100_count;

        public int c500_count;

        public int Zero_Count;

        public int Golden_Count;

        public int Speed_Bonus15;

        public int Speed_Bonus20;

        public int Total_Change_Amount;

        public int Combo_Count;
    }
    public Total_data total_Data;
}
