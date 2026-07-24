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

    [SerializeField] private GameObject f_efectgaradeimage;

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

    public Image rejistergoods;
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
    /// StartCountDownPhaseになったら発動させるカウントダウンのコルーチン
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
            AudioManager.Instance.PlaySE(AudioManager.Instance.SE[3]);

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
    /// <summary>
    /// 残り何秒になったら終わるまでのカウントダウンを表示する
    /// </summary>
    /// <returns></returns>
    public IEnumerator FinishTimer()
    {
        Image sprite = f_CountDownImage.GetComponent<Image>();
        int finishTimer = 2;
        f_CountDownImage.SetActive(true);
        while (finishTimer > -1)
        {
            AudioManager.Instance.PlaySE(AudioManager.Instance.SE[3]);

            sprite.sprite = finishsprites[finishTimer];
            finishTimer--;
            yield return new WaitForSeconds(1);
        }

        timetext.SetActive(false);

        sprite.sprite = finishsprites[3];
        
        yield return new WaitForSeconds(1);
        f_CountDownImage.SetActive(false);

        StartCoroutine(ShowResult());
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
    /// <summary>
    /// レジ内のすべてのテキストUIの表示・非表示させる
    /// </summary>
    /// <param name="l_active"></param>
    public void TextInRegister(bool l_active)
    {
        for(int i = 0;i < f_register_text.Length;i++)
        {
            f_register_text[i].SetActive(l_active);
        }
    }
    /// <summary>
    /// 評価UIを表示した後に、spriteを変更する
    /// </summary>
    /// <param name="l_grade"></param>
    void ShowGrade(StateMashine.Grade l_grade)
    {
        f_gradeimage.SetActive(true);

        Image gr_sp = f_gradeimage.GetComponent<Image>();

        gr_sp.sprite = KindOfSprite.Grade_Sp(l_grade);
    }
    /// <summary>
    /// 評価UIのエフェクト
    /// </summary>
    /// <param name="l_grade"></param>
    void ShowGradeEfect(StateMashine.Grade l_grade)
    {
        int index = (int)l_grade;

        Image gr_efect = f_efectgaradeimage.GetComponent<Image>();

        if (index >= 3)
        {
            gr_efect.sprite = KindOfSprite.GradeEfect_sp(l_grade);

            f_efectgaradeimage.SetActive(true);
        }

    }

    /// <summary>
    /// コンボUIを表示した後に、spriteを変更する
    /// </summary>
    /// <param name="l_combo"></param>
    public void ShowCombo(int l_combo)
    {
        AudioManager.Instance.PlaySE(AudioManager.Instance.SE[12]);

        f_comboimage.SetActive(true);

        Image com_sp = f_comboimage.GetComponent<Image>();

        com_sp.sprite = KindOfSprite.Combo_Sp(l_combo);
    }
    /// <summary>
    /// 評価UIとコンボUIを非表示にする
    /// </summary>
    public void GradeAndCombo()
    {
        f_gradeimage.SetActive(false);
        f_comboimage.SetActive(false);
        f_efectgaradeimage.SetActive(false);
    }

    public void PauseActive(bool l_active)
    {
        f_pause_ui.SetActive(l_active);
    }
    /// <summary>
    /// 制限時間が0になったらリザルトパネルを表示し、そのあとにランキングのトップ5入りしたら名前入力パネルを出す
    /// </summary>
    IEnumerator ShowResult()
    {
        OnGameState();

        result.SetActive(true);

        scoredisplay.AllScoreDisplay();

        ResultManagement.Instance.ActiveAndSlide();

        yield return new WaitUntil(() => !ResultManagement.Instance.p_skip);

        List<DataDetail> l_details = RankingData.Load_DataAmount();
        if (l_details.Count < 5)
        {
            AudioManager.Instance.PlaySE(AudioManager.Instance.SE[16]);

            ChallengeScoreResult scoreresult = ScoreCalculator.Instance.CalculateChallenge();

            RankingData.Save_Score(scoreresult.totalScore);

            f_RankInFlag_ui.SetActive(true);
        }
        else
        {
            AudioManager.Instance.PlaySE(AudioManager.Instance.SE[16]);

            f_RankInFlag_ui.SetActive(true);

            ChallengeScoreResult scoreresult = ScoreCalculator.Instance.CalculateChallenge();

            if (scoreresult.totalScore <= l_details[4].Score) yield break;

            l_details[4].Score = scoreresult.totalScore;

            l_details[4].Name = string.Empty;
        }
    }

    public void InputNameSetActive()
    {
        f_InputName_ui.SetActive(true);
    }

    public void TopFiveFlagUISetActive()
    {
        AudioManager.Instance.PlaySE(AudioManager.Instance.SE[1]);

        f_RankInFlag_ui.SetActive(false);
    }

    public void GoodsCanvas()
    {
        goodscanvas.SetActive(false);
    }

    public void ToInputNameUI()
    {
        AudioManager.Instance.PlaySE(AudioManager.Instance.SE[1]);

        f_RankInFlag_ui.SetActive(false);

        f_InputName_ui.SetActive(true);
    }
    /// <summary>
    /// 精算ボタンを押したときに処理されるコルーチン
    /// </summary>
    /// <returns></returns>
    public IEnumerator AmountDisplay(GameObject sumText)
    {
        if (OnPaying) yield break;
        OnPaying = true;
        sumText.SetActive(true);
        AudioManager.Instance.PlaySE(AudioManager.Instance.SE[6]);

        ChangeMoneyDisplay();

        yield return new WaitForSeconds(1.0f);
        ShowGradeEfect(f_grade);
        ShowGrade(f_grade);
        

        gamachanRendererChange.NormalOrGold_GradeEmotion(f_grade);

        if (AmountManagement.Combo >0)
        {
            if ((AmountManagement.Combo % 3) == 0)
            {
                yield return new WaitForSeconds(1.0f);

                ShowCombo(AmountManagement.Combo);
            }
        }

        yield return new WaitForSeconds(1.0f);

        GradeAndCombo();

        gamachanRendererChange.NomalAndGold();

        rejistergoods.sprite = null;
        goodscanvas.SetActive(true);

        OnGameState();
        OnPaying = false;
    }
    /// <summary>
    /// GoodsSelectPhaseや精算ボタンを押したときに発動する、おつりのテキストを更新させる関数
    /// </summary>
    public void ChangeMoneyDisplay()
    {
        uidisplay.ChangeTextDisplay();
    }
    /// <summary>
    /// ゲージが満タンになったときに何秒かかけて0まで減らすコルーチン
    /// </summary>
    /// <param name="l_statechange"></param>
    public void GaugeImageControl(Action<bool> l_statechange)
    {
        StartCoroutine(gaugeDisplay.Gaugedown(l_statechange));
    }
    /// <summary>
    /// GameUIクラスに評価の状態を渡す関数
    /// </summary>
    /// <param name="l_grade"></param>
    public void SetGrade(StateMashine.Grade l_grade)
    {
        f_grade = l_grade;
    }
    /// <summary>
    /// GameUIクラスに、GameLoopAmountManagementクラスのgameStateの状態を変える関数を渡す関数
    /// </summary>
    /// <param name="l_gamestate"></param>
    public void SetActionMesod_GameState(Action l_gamestate)
    {
        OnGameState = l_gamestate;
    }
}
