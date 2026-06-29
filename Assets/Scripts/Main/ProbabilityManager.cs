using UnityEngine;
[System.Serializable]
public class ProbabilityManager
{
    [Range(0,99)]
    public int NormalRange;
    [Range(0,99)]
    public int GoldRange;
    //public void Normal(float Shakespeed)
    //{
    //    int rnd = Random.Range(0, 100);
    //    if (rnd >= 0 && rnd <= NormalRange)
    //    {
    //        KindofMoney(Shakespeed);
    //    }
    //}
    public void Gold(float Shakespeed)
    {
        int rnd = Random.Range(0, 100);
        if (rnd >= 0 && rnd <= GoldRange)
        {
            KindofMoney(Shakespeed);
        }
    }
    /// <summary>
    /// 振る激しさによって出る小銭を変える処理をする関数
    /// </summary>
    /// <param name="Amount"></param>
    public void KindofMoney(float Amount)
    {
        if (Amount <= 9) return;
        if(Amount>=100)
        {
            PoolManagement.Instance.Spawn(500);
        }
        else if(Amount>=80)
        {
            PoolManagement.Instance.Spawn(100);
        }
        else if(Amount>=60)
        {
            PoolManagement.Instance.Spawn(50);
        }
        else if(Amount>=40)
        {
            PoolManagement.Instance.Spawn(10);
        }
        else if(Amount>=20)
        {
            PoolManagement.Instance.Spawn(5);
        }
        else if(Amount>=10)
        {
            PoolManagement.Instance.Spawn(1);
        }
    }
}
