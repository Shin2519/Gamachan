using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
/// <summary>
/// UIを表示させる処理のスクリプト
/// </summary>
public class GameUI : MonoBehaviour
{
    StateMashine.Grade f_grade;

    Action OnGameState;

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

    [SerializeField] GaugeDisplay gaugeDisplay;

    [SerializeField] ScoreDisplay scoredisplay;

    [SerializeField] Gradient gradient;

    [SerializeField] GamachanRendererChange gamachanRendererChange;

    [SerializeField] UIDisplayAmountManagement AmountManagement;

    public TextMeshProUGUI p_InputNameUGUI => f_InputName_ui.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();

    bool OnPaying;

    public bool p_OnPaying => OnPaying;
    void Start()
    {
        AmountManagement.SetActionMesod(GaugeImageControl);
        AmountManagement.SetFuncMesod(FinishTimer);
        uidisplay = new UIDisplay(f_register_text[1], f_register_text[3], f_register_text[5]);
        timerDisplay = new TimerDisplay(timetext);
        gaugeDisplay = new GaugeDisplay(f_gaugeimege[1],gradient,AmountManagement);
        f_pause_ui.SetActive(false);
    }

    void Update()
    {
        uidisplay.TextDisPlay();
        gaugeDisplay.GaugeUpdate(AmountManagement.Current,100);
        timerDisplay.Refresh(AmountManagement.Timer);
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
        OnGameState();
    }

    public IEnumerator FinishTimer()
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
    /// 初めに処理される表示・非表示の関数
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

    void ShowGrade(StateMashine.Grade l_grade)
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

    void ShowResult()
    {
        OnGameState();

        result.SetActive(true);

        scoredisplay.AllScoreDisplay();

        ResultManagement.Instance.ActiveAndSlide();

        List<DataDetail> l_details = RankingData.Load_DataAmount();

        if (l_details.Count < 5) Debug.Log("ランキング入り");
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

        ShowGrade(f_grade);

        gamachanRendererChange.NormalOrGold_GradeEmotion(f_grade);

        if (AmountManagement.Combo >= 3)
        {
            ShowCombo(AmountManagement.Combo);
        }

        yield return new WaitForSeconds(1.0f);

        GradeAndCombo();

        gamachanRendererChange.NomalAndGold();

        goodscanvas.SetActive(true);

        OnGameState();

        OnPaying = false;
    }

    public void ChangeMoneyDisplay()
    {
        uidisplay.ChangeTextDisplay();
    }

    public void GaugeImageControl(Action<bool> l_statechange)
    {
        StartCoroutine(gaugeDisplay.Gaugedown(l_statechange));
    }

    public void SetGrade(StateMashine.Grade l_grade)
    {
        f_grade = l_grade;
    }
    public void SetActionMesod_GameState(Action l_gamestate)
    {
        OnGameState = l_gamestate;
    }
}
