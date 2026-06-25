
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

    public static GradeCount gradecount;
    public static Coin coin;
    public static PaymentState payment;

    public static int TotalMoney(AnythingData.Coin coin_)
    {
        int Total = coin_.OneYenCoins + (5 * coin_.FiveYenCoins) + (10 * coin_.TenYenCoins) + (50 * coin_.FiftyYenCoins) + (100 * coin_.OnehundredYenCoins) + (500 * coin_.FivehundredYenCoins);

        payment.InputMoney = Total;

        return Total;
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
