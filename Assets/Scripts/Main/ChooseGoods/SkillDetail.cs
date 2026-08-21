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
        //AmountManagement.Current = before_gaugeamount;
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

    public void AddTime5()
    {
        AmountManagement.AddTimer(5);
        Debug.Log("時間が増えた");
    }
    public void AddTime7()
    {
        AmountManagement.AddTimer(7);
        Debug.Log("7");
    }
    public void AddTime10()
    {
        AmountManagement.AddTimer(10);
        Debug.Log("10");
    }

}
