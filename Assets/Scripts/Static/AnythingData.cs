
public static class AnythingData
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

    public struct AnotherBonusCount
    {
        public int CoinBonusCount;

        public int GoldenCount;

        public int ComboBonusCount;

        public int SpeedCount;

        public int TotalChangeCount;
    }

    public static GradeCount gradecount;

    public static Coin coin;

    public static PaymentState payment;

    public static AnotherBonusCount anotherbonus;
    public static int TotalMoney()
    {
        int Total = coin.OneYenCoins + (5 * coin.FiveYenCoins) + (10 * coin.TenYenCoins) + (50 * coin.FiftyYenCoins) + (100 * coin.OnehundredYenCoins) + (500 * coin.FivehundredYenCoins);

        anotherbonus.CoinBonusCount += (50 * coin.OneYenCoins) + (30 * coin.FiveYenCoins) + (20 * coin.TenYenCoins) + (10 * coin.FiftyYenCoins) + (5 * coin.OnehundredYenCoins) + (2 * coin.FivehundredYenCoins);

        payment.InputMoney = Total;

        return Total;
    }

    public static void AddComboBonus(int l_combo)
    {
        switch(l_combo)
        {
            case 3:
                anotherbonus.ComboBonusCount += 100;
                break;
            case 6:
                anotherbonus.ComboBonusCount += 200;
                break;
            case 9:
                anotherbonus.ComboBonusCount += 300;
                break;
            case 12:
                anotherbonus.ComboBonusCount += 400;
                break;
            case >=15:
                anotherbonus.ComboBonusCount += 500;
                break;
        }
    }
    
    public static void AddSpeedBonus(float l_pasttimer, float l_currenttimer)
    {
        float timer_sub = l_pasttimer - l_currenttimer;

        if(timer_sub <= 15)
        {
            anotherbonus.SpeedCount += 100;
        }
        else if(timer_sub <= 20)
        {
            anotherbonus.SpeedCount += 50;
        }
    }

    public static void PaymentReset()
    {
        payment.TargetAmount = 0;
        payment.InputMoney = 0;
        payment.ChangeMoney = 0;

        coin.FivehundredYenCoins = 0;
        coin.OnehundredYenCoins = 0;
        coin.FiftyYenCoins = 0;
        coin.TenYenCoins = 0;
        coin.FiveYenCoins = 0;
        coin.OneYenCoins = 0;
    }
}
