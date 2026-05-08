using Statestate;
using UnityEngine;
using UnityEngine.Rendering.Universal;
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

    public struct AboutMoney
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
    public static AboutMoney AM = new AboutMoney();
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
        if (Amount >= 3)
        {
            SpeedNum = (int)State.Speed.TooFast;
        }
        else if (Amount >= 2)
        {
            SpeedNum = (int)State.Speed.Fast;
        }
        else if (Amount >= 0.95)
        {
            SpeedNum = (int)State.Speed.Soso;
        }
        else if (Amount >= 0.65)
        {
            SpeedNum = (int)State.Speed.Slow;
        }
        else if (Amount >= 0.05)
        {
            SpeedNum = (int)State.Speed.TooSlow;
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
            PoolManagement.Instance.Money_500();
        }
        else if (Amount >= 3.5)
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
        if (Amount >= 2.9)
        {
            PoolManagement.Instance.Money_100();
        }
        else if (Amount >= 2.5)
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
    public static int TotalMoney(Coin coin_)
    {
        int Total = coin_.OneYenCoins + (5 * coin_.FiveYenCoins) + (10 * coin_.TenYenCoins) + (50 * coin_.FiftyYenCoins) * (100 * coin_.OnehundredYenCoins) + (500 * coin_.FivehundredYenCoins);

        return Total;
    }

    public static int GradeJudge()
    {
        int GradeState;

        if (AM.InputMoney >= AM.TargetAmount)
        {
            int Sub = AM.InputMoney - AM.TargetAmount;
            if(Sub<=0)
            {
                GradeState = (int)Statestate.Grade.Perfect;
                gradecount.PerfectCount++;
                ChooseGoods.Instance.Combo++;
                AM.ChangeMoney += Sub;
                return GradeState;
            }
            else if(Sub>=1&&Sub<=500)
            {
                GradeState = (int)Statestate.Grade.Great;
                gradecount.GreatCount++;
                ChooseGoods.Instance.Combo++;
                AM.ChangeMoney += Sub;
                return GradeState;
            }
            else if(Sub >= 501 && Sub <= 1000)
            {
                GradeState = (int)Statestate.Grade.Good;
                gradecount.GoodCount++;
                ChooseGoods.Instance.Combo++;
                AM.ChangeMoney += Sub;
                return GradeState;
            }
            else
            {
                GradeState = (int)Statestate.Grade.Bad;
                gradecount.BadCount++;
                ChooseGoods.Instance.Combo++;
                AM.ChangeMoney += Sub;
                return GradeState;
            }
        }
        else
        {
            GradeState = (int)Statestate.Grade.Miss;
            gradecount.MissCount++;
            return GradeState;
        }
    }
}
