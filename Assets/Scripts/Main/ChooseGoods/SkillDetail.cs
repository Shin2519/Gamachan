using UnityEngine;

public class SkillDetail
{
    float before_gaugeamount;

    public float NoSkill(float l_gaugeamount)
    {
        l_gaugeamount = before_gaugeamount;
        return l_gaugeamount;
    }
    public void Golden(float l_gaugeamount)
    {
        before_gaugeamount = l_gaugeamount;
        //GameLoopManagement.Instance.GamaStateChange();
        Debug.Log("ゴールデン");
    }

    public void NormalLocked()
    {
        Debug.Log("ノーマル固定");
    }

    public void AddTime(float l_currenttimer)
    {
        l_currenttimer += 3;
        Debug.Log("時間が増えた");
    }
}
