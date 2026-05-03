using State;
using UnityEngine;
namespace state
{
    public enum Speed
    {
        TooFast = 4,
        Fast = 3,
        Soso = 2,
        Slow = 1,
        TooSlow = 0
    }
}
[System.Serializable]
public class ProbabilityManager
{
    [Range(0,999)]
    public int NormalRange;
    [Range(0,999)]
    public int GoldRange;
    public Speed speed;
   
    public void Normal(float Shakespeed)
    {
        int rnd = Random.Range(0, 100);
        if (rnd >= 0 && rnd <= NormalRange)
        {
            KindofMoney(Shakespeed);
        }
    }
    public void Gold(float Shakespeed)
    {
        int rnd = Random.Range(0, 100);
        if (rnd >= 0 && rnd <= GoldRange)
        {
            KindofMoney(Shakespeed);
        }
        Debug.Log(rnd);
    }
    void KindofMoney(float Amount)
    {
        int SpeedNum = 0;
        if (Amount <= 0) return;
        if (Amount >= 2)
        {
            SpeedNum = (int)state.Speed.TooFast;
        }
        else if (Amount >= 2)
        {
            SpeedNum = (int)state.Speed.Fast;
        }
        else if (Amount >= 0.95)
        {
            SpeedNum = (int)state.Speed.Soso;
        }
        else if (Amount >= 0.65)
        {
            SpeedNum = (int)state.Speed.Slow;
        }
        else if (Amount >= 0.05)
        {
            SpeedNum = (int)state.Speed.TooSlow;
        }
        switch (SpeedNum)
        {
            case 4:
                TOOFAST(Amount);
                break;
            case 3:
                FAST(Amount);
                break;
            case 2:
                SOSO(Amount);
                break;
            case 1:
                SLOW(Amount);
                break;
            case 0:
                TOOSLOW(Amount);
                break;
        }
    }
    void TOOFAST(float Amount)
    {
        if (Amount >= 2.9)
        {
            PoolManagement.Instance.Money_500();
        }
        else if (Amount >= 2.5)
        {
            int rnd = Random.Range(0, 2);
            if (rnd == 0)
            {
                PoolManagement.Instance.Money_500();
            }
            else
            {
                PoolManagement.Instance.Money_100();
            }
        }
        else
        {
            PoolManagement.Instance.Money_100();
        }
    }

    void FAST(float Amount)
    {
        if (Amount >= 1.9)
        {
            PoolManagement.Instance.Money_100();
        }
        else if (Amount >= 1.5)
        {
            int rnd = Random.Range(0, 2);
            if (rnd == 0)
            {
                PoolManagement.Instance.Money_100();
            }
            else
            {
                PoolManagement.Instance.Money_50();
            }
        }
        else
        {
            PoolManagement.Instance.Money_50();
        }
    }

    void SOSO(float Amount)
    {
        if (Amount >= 1.4)
        {
            PoolManagement.Instance.Money_50();
        }
        else if (Amount >= 1)
        {
            int rnd = Random.Range(0, 2);
            if (rnd == 0)
            {
                PoolManagement.Instance.Money_50();
            }
            else
            {
                PoolManagement.Instance.Money_10();
            }
        }
        else
        {
            PoolManagement.Instance.Money_10();
        }
    }

    void SLOW(float Amount)
    {
        if (Amount >= 0.9)
        {
            PoolManagement.Instance.Money_10();
        }
        else if (Amount >= 0.7)
        {
            int rnd = Random.Range(0, 2);
            if (rnd == 0)
            {
                PoolManagement.Instance.Money_10();
            }
            else
            {
                PoolManagement.Instance.Money_5();
            }
        }
        else
        {
            PoolManagement.Instance.Money_5();
        }
    }

    void TOOSLOW(float Amount)
    {
        if (Amount >= 0.6)
        {
            PoolManagement.Instance.Money_5();
        }
        else if (Amount >= 0.4)
        {
            int rnd = Random.Range(0, 2);
            if (rnd == 0)
            {
                PoolManagement.Instance.Money_5();
            }
            else
            {
                PoolManagement.Instance.Money_1();
            }
        }
        else
        {
            PoolManagement.Instance.Money_1();
        }
    }
}
