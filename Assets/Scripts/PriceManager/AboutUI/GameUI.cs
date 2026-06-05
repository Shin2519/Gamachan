using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
/// <summary>
/// UI�̕\���E��\�������������N���X
/// </summary>
public class GameUI : MonoBehaviour
{
    public static GameUI instance;

    [SerializeField] private GameObject f_gradeimage;

    [SerializeField] private GameObject f_comboimage;

    [SerializeField] private GameObject goodscanvas;

    [SerializeField] private GameObject[] f_register_text;

    [SerializeField] private GameObject timetext;//���ԃe�L�X�g

    [SerializeField] private GameObject[] f_gaugeimege;

    [SerializeField] private GameObject f_pause_ui;

    [SerializeField] private GameObject f_RankInFlag_ui;

    [SerializeField] private GameObject f_InputName_ui;

    [SerializeField] private Sprite[] startsprites;

    [SerializeField] private Sprite[] finishsprites;

    [SerializeField] private GameObject f_CountDownImage;

    [SerializeField] private GameObject result;

    [SerializeField] KindOfSprite KindOfSprite = new KindOfSprite();

    UIDisplay uidisplay;

    TimerDisplay timerDisplay;

    GaugeDisplay gaugeDisplay;

    [SerializeField] ScoreDisplay scoredisplay;

    public TextMeshProUGUI p_InputNameUGUI => f_InputName_ui.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();

    bool finish = false;

    bool OnPaying;

    public bool p_OnPaying => OnPaying;
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        uidisplay = new UIDisplay(f_register_text[1], f_register_text[3], f_register_text[5]);
        timerDisplay = new TimerDisplay(timetext);
        gaugeDisplay = new GaugeDisplay(f_gaugeimege[1]);
    }

    void Update()
    {
        uidisplay.TextDisPlay(ProbabilityManager.AM, UIDisplayAmountManagement.instance.Timer);
        gaugeDisplay.GaugeUpdate(UIDisplayAmountManagement.instance.Current,100);
        timerDisplay.Refresh(UIDisplayAmountManagement.instance.Timer);
        if (GameLoopManagement.Instance._Gamestate == StateMashine.GameState.GoodsSelectPhase)
        {
            uidisplay.ResetText();
        }
        if (UIDisplayAmountManagement.instance.Timer <= 4 && !finish)
        {
            finish = true;
            StartCoroutine(FinnishTimer());
        }
    }
    /// <summary>
    /// StartCountDownPhase�ɂȂ������Ɉ�x������������J�E���g�_�E���̃R���[�`��
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
        f_CountDownImage.SetActive(false);
        StartSetActive(true);
        GameLoopManagement.Instance._Gamestate = StateMashine.GameState.GoodsSelectPhase;
    }

    public IEnumerator FinnishTimer()
    {
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
        f_CountDownImage.SetActive(false);
        ShowResult();
    }
    /// <summary>
    /// �J�E���g�_�E���̏��߂ƏI���ŕ\���E��\����������̂�ς���
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

    public void ShowGrade(Statestate.Grade l_grade)
    {
        f_gradeimage.SetActive(true);

        Image gr_sp = f_gradeimage.GetComponent<Image>();

        gr_sp.sprite = KindOfSprite.Grade_Sp(l_grade);
    }

    public void ShowCombo(int l_combo)
    {
        f_comboimage.SetActive(true);

        Image com_sp = f_comboimage.GetComponent<Image>();

        com_sp.sprite = KindOfSprite.Combo_Sp(l_combo);
    }
    public void GradeAndCombo()
    {
        f_gradeimage.SetActive(false);
        f_comboimage.SetActive(false);
    }

    public void PauseActive(bool l_active)
    {
        f_pause_ui.SetActive(l_active);
    }

    void PaymentTextReset()
    {
        uidisplay.ResetText();
    }

    void ShowResult()
    {
        GameLoopManagement.Instance._Gamestate = StateMashine.GameState.ScorePhase;

        result.SetActive(true);

        scoredisplay.AllScoreDisplay();

        ResultManagement.Instance.ActiveAndSlide();

        int RankingNum = RankingDisplay.RankingJudge(ScoreCalculator.Instance.CalculateChallenge(ProbabilityManager.gradecount,ChooseGoods.Instance.Combo,ProbabilityManager.coin,ProbabilityManager.AM).totalScore);

        if(RankingNum<=5)
        {
            f_RankInFlag_ui.SetActive(true);
        }
    }

    public void InputNameSetActive()
    {
        f_InputName_ui.SetActive(true);
    }

    public void GoodsCanvas()
    {
        goodscanvas.SetActive(false);
    }

    public void ToInputNameUI()
    {
        f_RankInFlag_ui.SetActive(false);

        f_InputName_ui.SetActive(true);
    }

    public IEnumerator AmountDisplay()
    {
        if (OnPaying) yield break;
        OnPaying = true;

        ChangeMoneyDisplay();

        yield return new WaitForSeconds(1.0f);

        ShowGrade(ChooseGoods.Instance.p_grade);

        if (ChooseGoods.Instance.Combo >= 3)
        {
            yield return new WaitForSeconds(1.0f);

            ShowCombo(ChooseGoods.Instance.Combo);
        }

        yield return new WaitForSeconds(1.0f);

        GradeAndCombo();

        PaymentTextReset();

        ProbabilityManager.PaymentReset();

        goodscanvas.SetActive(true);

        GameLoopManagement.Instance._Gamestate = StateMashine.GameState.GoodsSelectPhase;
        OnPaying = false;
    }

    public void ChangeMoneyDisplay()
    {
        uidisplay.ChangeTextDisplay();
    }
}
