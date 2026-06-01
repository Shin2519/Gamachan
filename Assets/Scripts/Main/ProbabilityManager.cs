using UnityEngine;
namespace Statestate
{
    public enum Speed
    {
        TooFast = 4,
        Fast = 3,
        Soso = 2,
        Slow = 1,
        TooSlow = 0
    }

    public enum Grade
    { 
        Perfect = 5,
        Great = 4,
        Good = 3,
        Bad = 2,
        Miss = 1
    }
    public enum GamaState
    {
        Nomal,
        Gold
    }
}
[System.Serializable]
public class ProbabilityManager
{
    public struct Coin
    {
        public int OneYenCoins;
        public int FiveYenCoins;
        public int TenYenCoins;
        public int FiftyYenCoins;
        public int OnehundredYenCoins;
        public int FivehundredYenCoins;
    }

    public struct PaymentState
    {
        public int TargetAmount;

        public int InputMoney;

        public int ChangeMoney;
    }

    public struct GradeCount
    {
        public int MissCount;

        public int BadCount;

        public int GoodCount;

        public int GreatCount;

        public int PerfectCount;
    }
    public static GradeCount gradecount = new GradeCount();
    public static Coin coin = new Coin();
    public static PaymentState AM = new PaymentState();
    [Range(0,99)]
    public int NormalRange;
    [Range(0,99)]
    public int GoldRange;
    public Statestate.Speed speed;
    static int f_gaugeamount;
    public static int GaugeAmount
    {
        get => f_gaugeamount;
        set
        {
            f_gaugeamount = Mathf.Clamp(value, 0, 100);
        }
    }
   
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
        if (Amount >= 3)
        {
            SpeedNum = (int)Statestate.Speed.TooFast;
        }
        else if (Amount >= 2)
        {
            SpeedNum = (int)Statestate.Speed.Fast;
        }
        else if (Amount >= 0.95)
        {
            SpeedNum = (int)Statestate.Speed.Soso;
        }
        else if (Amount >= 0.65)
        {
            SpeedNum = (int)Statestate.Speed.Slow;
        }
        else if (Amount >= 0.05)
        {
            SpeedNum = (int)Statestate.Speed.TooSlow;
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
        if (Amount >= 3.9)
        {
            PoolManagement.Instance.Spawn(500);
        }
        else if (Amount >= 3.5)
        {
            int rnd = Random.Range(0, 2);
            if (rnd == 0)
            {
                PoolManagement.Instance.Spawn(500);
            }
            else
            {
                PoolManagement.Instance.Spawn(100);
            }
        }
        else
        {
            PoolManagement.Instance.Spawn(100);
        }
    }

    void FAST(float Amount)
    {
        if (Amount >= 2.9)
        {
            PoolManagement.Instance.Spawn(100);
        }
        else if (Amount >= 2.5)
        {
            int rnd = Random.Range(0, 2);
            if (rnd == 0)
            {
                PoolManagement.Instance.Spawn(100);
            }
            else
            {
                PoolManagement.Instance.Spawn(50);
            }
        }
        else
        {
            PoolManagement.Instance.Spawn(50);
        }
    }

    void SOSO(float Amount)
    {
        if (Amount >= 1.4)
        {
            PoolManagement.Instance.Spawn(50);
        }
        else if (Amount >= 1)
        {
            int rnd = Random.Range(0, 2);
            if (rnd == 0)
            {
                PoolManagement.Instance.Spawn(50);
            }
            else
            {
                PoolManagement.Instance.Spawn(10);
            }
        }
        else
        {
            PoolManagement.Instance.Spawn(10);
        }
    }

    void SLOW(float Amount)
    {
        if (Amount >= 0.9)
        {
            PoolManagement.Instance.Spawn(10);
        }
        else if (Amount >= 0.7)
        {
            int rnd = Random.Range(0, 2);
            if (rnd == 0)
            {
                PoolManagement.Instance.Spawn(10);
            }
            else
            {
                PoolManagement.Instance.Spawn(5);
            }
        }
        else
        {
            PoolManagement.Instance.Spawn(5);
        }
    }

    void TOOSLOW(float Amount)
    {
        if (Amount >= 0.6)
        {
            PoolManagement.Instance.Spawn(5);
        }
        else if (Amount >= 0.4)
        {
            int rnd = Random.Range(0, 2);
            if (rnd == 0)
            {
                PoolManagement.Instance.Spawn(5);
            }
            else
            {
                PoolManagement.Instance.Spawn(1);
            }
        }
        else
        {
            PoolManagement.Instance.Spawn(1);
        }
    }
    public static int TotalMoney(Coin coin_)
    {
        int Total = coin_.OneYenCoins + (5 * coin_.FiveYenCoins) + (10 * coin_.TenYenCoins) + (50 * coin_.FiftyYenCoins) + (100 * coin_.OnehundredYenCoins) + (500 * coin_.FivehundredYenCoins);

        return Total;
    }

    public static Statestate.Grade GradeJudge()
    {
        Statestate.Grade GradeState;

        if (AM.InputMoney >= AM.TargetAmount)
        {
            int Sub = AM.InputMoney - AM.TargetAmount;
            if(Sub<=0)
            {
                GradeState = Statestate.Grade.Perfect;
                gradecount.PerfectCount++;
                ChooseGoods.Instance.Combo++;
                AM.ChangeMoney += Sub;
                return GradeState;
            }
            else if(Sub>=1&&Sub<=500)
            {
                GradeState = Statestate.Grade.Great;
                gradecount.GreatCount++;
                ChooseGoods.Instance.Combo++;
                AM.ChangeMoney += Sub;
                return GradeState;
            }
            else if(Sub >= 501 && Sub <= 1000)
            {
                GradeState = Statestate.Grade.Good;
                gradecount.GoodCount++;
                ChooseGoods.Instance.Combo++;
                AM.ChangeMoney += Sub;
                return GradeState;
            }
            else
            {
                GradeState = Statestate.Grade.Bad;
                gradecount.BadCount++;
                ChooseGoods.Instance.Combo = 0;
                AM.ChangeMoney += Sub;
                return GradeState;
            }
        }
        else
        {
            GradeState = Statestate.Grade.Miss;
            gradecount.MissCount++;
            ChooseGoods.Instance.Combo = 0;
            return GradeState;
        }
    }
    public static void PaymentReset()
    {
        AM.TargetAmount = 0;
        AM.InputMoney = 0;
        AM.ChangeMoney = 0;
    }
}
