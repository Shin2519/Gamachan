using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "SendData", menuName = "Scriptable Objects/SendData")]
public class SendData : ScriptableObject
{
    public int Perfect_count;

    public int Great_count;

    public int Good_count;

    public int Bad_count;

    public int JustSumAmount_Bonus;

    public int Golden_Bonus;

    public int Combo_count;

    public int TotalSumAmount;
}
