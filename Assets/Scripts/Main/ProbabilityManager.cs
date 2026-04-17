using UnityEngine;
[System.Serializable]
public class ProbabilityManager
{
    [Range(0,999)]
    public int NormalRange;
    [Range(0,999)]
    public int GoldRange;
    public void Normal(float Shakespeed)
    {
        int rnd = Random.Range(0, 100);
        if (rnd >= 0 && rnd <= NormalRange)
        {
            DropMoney.instance.KindofMoney(Shakespeed);
        }
        Debug.Log(rnd);
    }
    public void Gold(float Shakespeed)
    {
        int rnd = Random.Range(0, 100);
        if (rnd >= 0 && rnd <= GoldRange)
        {
            DropMoney.instance.KindofMoney(Shakespeed);
        }
        Debug.Log(rnd);
    }
}
