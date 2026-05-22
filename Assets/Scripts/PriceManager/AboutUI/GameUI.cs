using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// UIの表示・非表示だけを扱うクラス
/// </summary>
public class GameUI : MonoBehaviour
{
    public static GameUI instance;

    public GameObject f_gradeimage;

    public GameObject f_comboimage;

    [SerializeField] private GameObject goodscanvas;

    [SerializeField] private GameObject[] f_register_text;

    [SerializeField] private GameObject timetext;//時間テキスト

    [SerializeField] private GameObject[] f_gaugeimege;

    [SerializeField] private Sprite[] startsprites;

    [SerializeField] private Sprite[] finishsprites;

    [SerializeField] private GameObject f_CountDownImage;

    bool finish = true;

    [SerializeField] private GameObject result;

    [SerializeField] private GameObject ui;

    [SerializeField] KindOfSprite KindOfSprite;

    UIDisplay uidisplay;
    TimerDisplay timerDisplay;
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        uidisplay = new UIDisplay(f_register_text[1], f_register_text[3], f_register_text[5]);
        timerDisplay = new TimerDisplay(timetext);
    }

    void Update()
    {
        uidisplay.TextDisPlay(ProbabilityManager.AM, TimerManagement.instance.Timer);
        timerDisplay.Refresh(TimerManagement.instance.Timer);
        if (GameLoopManagement.Instance._Gamestate == StateMashine.GameState.GoodsSelectPhase)
        {
            uidisplay.ResetText();
        }
        if (TimerManagement.instance.Timer <= 4 && finish) StartCoroutine(FinnishTimer());
    }
    /// <summary>
    /// StartCountDownPhaseになった時に一度だけ発動するカウントダウンのコルーチン
    /// </summary>
    /// <returns></returns>
    public IEnumerator StartTimer()
    {
        f_CountDownImage.SetActive(true);
        StartSetActive(false);
        TextInRegister(false);
        int startTimer = 2;

        Image sprite = f_CountDownImage.GetComponent<Image>();

        result.SetActive(false);

        while (startTimer > -1)
        {
            sprite.sprite = startsprites[startTimer];
            startTimer--;
            yield return new WaitForSeconds(1);
        }
        yield return null;
        sprite.sprite = startsprites[3];
        yield return new WaitForSeconds(1);
        StartSetActive(true);
        GameLoopManagement.Instance._Gamestate = StateMashine.GameState.GoodsSelectPhase;
    }

    public IEnumerator FinnishTimer()
    {
        finish = false;
        Image sprite = f_CountDownImage.GetComponent<Image>();
        int finishTimer = 2;
        f_CountDownImage.SetActive(true);
        while (finishTimer > -1)
        {
            sprite.sprite = finishsprites[finishTimer];
            finishTimer--;
            yield return new WaitForSeconds(1);
        }
        sprite.sprite = finishsprites[3];
        
        yield return new WaitForSeconds(1);     
        ui.SetActive(false);
        f_CountDownImage.SetActive(false);
        ScoreCalculator.Instance.CalculateChallenge(ProbabilityManager.gradecount, ChooseGoods.Instance.Combo, ProbabilityManager.coin, ProbabilityManager.AM);
        result.SetActive(true);
    }
    /// <summary>
    /// カウントダウンの初めと終わりで表示・非表示させるものを変える
    /// </summary>
    /// <param name="l_active"></param>
    void StartSetActive(bool l_active)
    {
        timetext.SetActive(l_active);
        goodscanvas.SetActive(l_active);
        for(int i = 0;i < f_gaugeimege.Length;i++)
        {
            f_gaugeimege[i].SetActive(l_active);
        }
    }
    public void TextInRegister(bool l_active)
    {
        for(int i = 0;i < f_register_text.Length;i++)
        {
            f_register_text[i].SetActive(l_active);
        }
    }
}
