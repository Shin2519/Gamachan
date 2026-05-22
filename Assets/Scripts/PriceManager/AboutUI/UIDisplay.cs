using TMPro;
using UnityEngine;
/// <summary>
/// TextÇÃçXêVÇæÇØÇÇ∑ÇÈÉNÉâÉX
/// </summary>
public class UIDisplay
{
    private readonly TextMeshProUGUI TargetMoneyAmountText;
    private readonly TextMeshProUGUI InputMoneyAmountText;
    private readonly TextMeshProUGUI ChangeMoneyText;

    public UIDisplay(GameObject l_TargetText, GameObject l_InputMoneyAmountText,GameObject l_ChangeMoneyText)
    {
        TargetMoneyAmountText = l_TargetText.GetComponent<TextMeshProUGUI>();

        InputMoneyAmountText = l_InputMoneyAmountText.GetComponent<TextMeshProUGUI>();

        ChangeMoneyText = l_ChangeMoneyText.GetComponent<TextMeshProUGUI>();
    }

    public void TextDisPlay(ProbabilityManager.PaymentState l_paymentstate,float timer)
    {
        TargetMoneyAmountText.text = l_paymentstate.TargetAmount + "â~";

        InputMoneyAmountText.text = ProbabilityManager.TotalMoney(ProbabilityManager.coin) + "â~";

        ChangeMoneyText.text = l_paymentstate.ChangeMoney + "â~";
    }
    

    public void ResetText()
    {
        TargetMoneyAmountText.text = "";

        InputMoneyAmountText.text = "";

        ChangeMoneyText.text = "";
    }
}
class TimerDisplay
{ 
    private readonly TextMeshProUGUI TimerText;

    public TimerDisplay(GameObject l_timertext)
    {
        TimerText = l_timertext.GetComponent<TextMeshProUGUI>();
    }

    public void Refresh(float timer)
    {
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);
        TimerText.text = string.Format("TIME:{0:D2}:{1:D2}", minutes, seconds);

        UpdateColor(timer);
    }

    private void UpdateColor(float timer)
    {
        if (10 < timer && timer <= 30)
            TimerText.color = new Color32(255, 128, 0, 255);
        else if (timer <= 10)
            TimerText.color = new Color32(255, 0, 0, 255);
    }
}

