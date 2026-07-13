using UnityEngine;

public class SkillDetail
{
    const float gold_gaugeamount = 100;

    float before_gaugeamount;

    UIDisplayAmountManagement AmountManagement;
    public SkillDetail(UIDisplayAmountManagement l_amountmanagement)
    {
        AmountManagement = l_amountmanagement;
    }

    public void None()
    {
        AmountManagement.Current = before_gaugeamount;
    }
    public void Golden()
    {
        before_gaugeamount = AmountManagement.Current;
        AmountManagement.Current = gold_gaugeamount;
    }

    public void NormalLocked()
    {
        Debug.Log("ノーマル固定");
    }

    public void AddTime()
    {
        int[] a = { 5, 7, 10 };
        int i = Random.Range(0, a.Length);
        AmountManagement.AddTimer(a[i]);
        Debug.Log("時間が増えた");
    }
}
