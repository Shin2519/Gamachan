using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GaugeState
{
    public enum Gauge
    {
        Normal,
        Gold
    }
}
/// <summary>
/// Textの更新をするクラス
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
        TargetMoneyAmountText.text = l_paymentstate.TargetAmount + "�~";

        InputMoneyAmountText.text = ProbabilityManager.TotalMoney(ProbabilityManager.coin) + "�~";

        ChangeMoneyText.text = l_paymentstate.ChangeMoney + "�~";
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

class GaugeDisplay
{
    private readonly Image gauge_image;

    private readonly Color gauge_color;

    public bool gaugedown;

    public GaugeDisplay(GameObject l_gauge)
    {
        gauge_image = l_gauge.GetComponent<Image>();

        gauge_color = gauge_image.color;
    }
    public void GaugeUpdate(float Current,float Max) => gauge_image.fillAmount = Current / Max;

    IEnumerator GaugeDown(float l_current)
    {
        gaugedown = true;

        while (gauge_image.fillAmount > 0)
        {
            if(GameLoopManagement.Instance._Gamestate==StateMashine.GameState.ScorePhase)break;
            yield return new WaitUntil(() => !ChooseGoods.Instance.P_OnPay);
            l_current -= 1 * Time.deltaTime;
            yield return null;
        }
        gauge_image.color = gauge_color;
        gaugedown = false;
    }
    IEnumerator ColorChange()
    {
        while (gauge_image.fillAmount > 0)
        {
            Color l_gauge_color = gauge_color;
            float rnd_R = Random.Range(0.0f, 1.0f);
            float rnd_G = Random.Range(0.0f, 1.0f);
            float rnd_B = Random.Range(0.0f, 1.0f);
            l_gauge_color.r = rnd_R;
            l_gauge_color.g = rnd_G;
            l_gauge_color.b = rnd_B;
            gauge_image.color = l_gauge_color;
            yield return new WaitForSeconds(0.5f);
        }
    }
}


