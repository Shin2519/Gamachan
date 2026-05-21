using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
public class UIDisplay
{
    private readonly TextMeshProUGUI TargetMoneyAmountText;
    private readonly TextMeshProUGUI InputMoneyAmountText;
    private readonly TextMeshProUGUI ChangeMoneyText;
    private readonly TextMeshProUGUI TimerText;

    public UIDisplay(GameObject l_TargetText, GameObject l_InputMoneyAmountText,GameObject l_ChangeMoneyText,GameObject l_timertext)
    {
        TargetMoneyAmountText = l_TargetText.GetComponent<TextMeshProUGUI>();

        InputMoneyAmountText = l_InputMoneyAmountText.GetComponent<TextMeshProUGUI>();

        ChangeMoneyText = l_ChangeMoneyText.GetComponent<TextMeshProUGUI>();

        TimerText = l_timertext.GetComponent<TextMeshProUGUI>();
    }

    public void TextDisPlay(ProbabilityManager.PaymentState l_paymentstate,float timer)
    {
        TargetMoneyAmountText.text = l_paymentstate.TargetAmount + "‰~";

        InputMoneyAmountText.text = ProbabilityManager.TotalMoney(ProbabilityManager.coin) + "‰~";

        ChangeMoneyText.text = l_paymentstate.ChangeMoney + "‰~";

        TimerText.text = string.Format("TIME:" + "{0:D2}:{1:D2}",MinutesConvert(timer), Seconds(timer));

        UpdateColor(timer);
    }

    void UpdateColor(float timer)
    {
        if (10 < timer && timer <= 30)
        {
            TimerText.color = new Color32(255, 128, 0, 255);//ƒIƒŒƒ“ƒW
        }
        else if (timer <= 10)
        {
            TimerText.color = new Color32(255, 0, 0, 255);//Ô
        }
    }

    float MinutesConvert(float Seconds)
    {
        int minutes = Mathf.FloorToInt(TimerManagement.instance.Timer / 60);

        return minutes;
    }

    float Seconds(float second)
    {
        int seconds = Mathf.FloorToInt(TimerManagement.instance.Timer % 60);

        return seconds;
    }

    public void ResetText()
    {
        TargetMoneyAmountText.text = "";

        InputMoneyAmountText.text = "";

        ChangeMoneyText.text = "";
    }
}
