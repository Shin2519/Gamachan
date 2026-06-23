using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;
/// <summary>
/// Textの更新をするクラス
/// </summary>
public class UIDisplay
{
    private readonly TextMeshProUGUI TargetMoneyAmountText;
    private readonly TextMeshProUGUI InputMoneyAmountText;
    private readonly TextMeshProUGUI ChangeMoneyText;

    int ChangeMoney;

    public UIDisplay(GameObject l_TargetText, GameObject l_InputMoneyAmountText,GameObject l_ChangeMoneyText)
    {
        TargetMoneyAmountText = l_TargetText.GetComponent<TextMeshProUGUI>();

        InputMoneyAmountText = l_InputMoneyAmountText.GetComponent<TextMeshProUGUI>();

        ChangeMoneyText = l_ChangeMoneyText.GetComponent<TextMeshProUGUI>();
    }

    public void TextDisPlay(AnythingData.PaymentState l_paymentstate,float timer)
    {
        ChangeMoney = l_paymentstate.ChangeMoney;

        TargetMoneyAmountText.text = l_paymentstate.TargetAmount + "円";

        InputMoneyAmountText.text = AnythingData.TotalMoney(AnythingData.coin) + "円";
    }

    public void ChangeTextDisplay()
    {
        ChangeMoneyText.text = ChangeMoney + "円";
    }
    

    public void ResetText()
    {
        TargetMoneyAmountText.text = string.Empty;

        InputMoneyAmountText.text = string.Empty;

        ChangeMoneyText.text = string.Empty;
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
    private readonly Gradient gradient;
    private readonly Image gauge_image;

    private readonly Color gauge_color;

    private readonly UIDisplayAmountManagement AmountManagement;

    private readonly Action<bool> Onstatechange;

    public bool gaugedown;

    public bool gaugecolor;

    public GaugeDisplay(GameObject l_gauge,Gradient l_gradient, UIDisplayAmountManagement amountManagement, Action<bool> l_statechange)
    {
        gauge_image = l_gauge.GetComponent<Image>();

        gauge_image.fillAmount = 0;

        gauge_color = gauge_image.color;

        gradient = l_gradient;

        AmountManagement = amountManagement;

        Onstatechange = l_statechange;
    }
    public void GaugeUpdate(float Current,float Max) => gauge_image.fillAmount = Current / Max;

    public IEnumerator Gaugedown()
    {
        gaugedown = true;
        Tween ColorTween =  DOTween.To(() => 0.0f, x =>
        gauge_image.color = gradient.Evaluate(x),
        1f,
        0.5f
        ).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
        gauge_image.DOFillAmount(0.0f,2.0f).OnComplete(() => ColorTween.Kill());
        yield return new WaitForSeconds(2.0f);
        
        AmountManagement.Current = 0;
        gauge_image.color = gauge_color;
        Onstatechange(false);
        gaugedown = false;
    }
}
[System.Serializable]
class ScoreDisplay
{
    ChallengeScoreResult challengeScoreResult;
    [SerializeField] UIDisplayAmountManagement AmountManagement;
    [SerializeField] Text PerfectScore;
    [SerializeField] Text GreatScore;
    [SerializeField] Text GoodScore;
    [SerializeField] Text BadScore;
    [SerializeField] Text MissScore;
    [SerializeField] Text GoldenBonus;
    [SerializeField] Text ComboBonus;
    [SerializeField] Text SpeedBonus;
    [SerializeField] Text ChangeBonus;
    [SerializeField] Text TotalScore;
    public void AllScoreDisplay()
    {
        challengeScoreResult = ScoreCalculator.Instance.CalculateChallenge(AnythingData.gradecount,AmountManagement.Combo, AnythingData.coin, AnythingData.payment);

        PerfectScore.text = challengeScoreResult.perfectScore.ToString();
        GreatScore.text = challengeScoreResult.greatScore.ToString();
        GoodScore.text = challengeScoreResult.goodScore.ToString();
        BadScore.text = challengeScoreResult.badScore.ToString();
        ComboBonus.text = challengeScoreResult.comboBonus.ToString();
        ChangeBonus.text = challengeScoreResult.totalChange.ToString();
        TotalScore.text = challengeScoreResult.totalScore.ToString();
    }
}


