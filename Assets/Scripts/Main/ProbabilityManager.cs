using UnityEngine;

public class ProbabilityManager 
{
    public void Normal(float Shakespeed)
    {
        int rnd = Random.Range(0, 100);
        if (rnd >= 0 && rnd <= 49)
        {
            DropMoney.instance.KindofMoney(Shakespeed);
        }
        Debug.Log(rnd);
    }
    public void Gold(float Shakespeed)
    {
        int rnd = Random.Range(0, 100);
        if (rnd >= 0 && rnd <= 59)
        {
            DropMoney.instance.KindofMoney(Shakespeed);
        }
        Debug.Log(rnd);
    }
}
