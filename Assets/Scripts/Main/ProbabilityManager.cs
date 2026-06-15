using UnityEngine;
namespace Statestate
{
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
    static int f_gaugeamount;
    public static int GaugeAmount
    {
        get => f_gaugeamount;
        set
        {
            f_gaugeamount = Mathf.Clamp(value, 0, 100);
        }
    }
   
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
    
    public static int TotalMoney(Coin coin_)
    {
        int Total = coin_.OneYenCoins + (5 * coin_.FiveYenCoins) + (10 * coin_.TenYenCoins) + (50 * coin_.FiftyYenCoins) + (100 * coin_.OnehundredYenCoins) + (500 * coin_.FivehundredYenCoins);

        AM.InputMoney = Total;

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
