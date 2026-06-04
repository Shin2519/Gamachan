using UnityEngine;

public class SkillDetail
{
    public void Golden(float l_gaugeamount)
    {
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
