using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TouchPanel : MasterCode
{
    public static TouchPanel instance;
    ChallengeScoreResult CS;
    [SerializeField,Header("–Ú•W‹àŠz")] private TextMeshProUGUI amounttext;//¤•i‚Ì‹àŠzƒeƒLƒXƒg
    [SerializeField,Header("“Š“ü‹àŠz")] private TextMeshProUGUI inputamounttext;//“Š“ü‹àŠz(‰¼)ƒeƒLƒXƒg
    [SerializeField,Header("‡Œv‹àŠz")] private TextMeshProUGUI sumamounttext;//‡Œv‹àŠzƒeƒLƒXƒg(‰~)
 
    // ‡Œv‹àŠz‚ª+‚©-‚Å•\Ž¦‚·‚éƒeƒLƒXƒg‚ª•Ï‚í‚é‚½‚ß
    [SerializeField] private TextMeshProUGUI sumamountyen;//‡Œv‹àŠzƒeƒLƒXƒg(‚¨’Þ‚èAŽx•¥ŽcŠz)
    [SerializeField] SelectGoodsSO selectgoodsso;
    private int inputamount = 0;
    public int sumamount;//‡Œv‹àŠz
    [SerializeField] GameObject selectgoods;
    [SerializeField]
    private GameObject Gama;
    public GameObject Cross;
    [SerializeField]
    private GameObject Result;
    public bool Onpay = false;
    public int InputAmount {  get { return inputamount; } set { inputamount = value; } }
    public int Total => selectgoodsso.total;

    [SerializeField] private GameObject gametext;
    void Awake()
    {
        instance = this;
        if(Gama_Image==null)
        {
            Gama_Image = Gama.GetComponent<Image>();
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        combo = 0;
        rndyentext();
        Cross.SetActive(false);
        Result.SetActive(false);
        ResultManager.Instance.SetScores(CS.ToArray());
    }
    void Update()
    {
        inputamounttext.text = inputamount.ToString() + "‰~";
    }
    public void OnButton()
    {
        if (Onpay) return;
        StartCoroutine(kaikei());
        AudioManager.Instance.seSource.PlayOneShot(sound.Buttondown);
    }

    public void rndyentext()
    {
        //–Ú•W‹àŠz
        amounttext.text = selectgoodsso.total.ToString() + "‰~";
        //“Š“ü‹àŠz
        inputamount = 0;
        inputamounttext.text = inputamount.ToString() + "‰~";
        //‡Œv‹àŠz
        sumamounttext.text = sumamount.ToString() + "‰~";


        sumamounttext.enabled = false;
        sumamountyen.enabled = false;
        if (gauge_state==State.Gauge.Gold)
        {
            Gama_Image.sprite = about_ui.GoldenKindofemotion[0];
        }
    }

    IEnumerator kaikei()
    {
        Onpay = true;
        gametext.SetActive(false);
        sumamount = inputamount - selectgoodsso.total;
        sumamounttext.enabled = true;
        sumamountyen.enabled = true;

        sumamounttext.text = sumamount.ToString() + "‰~";

        if (sumamount >= 0)
        {
            //float SentTimer = Timer.Instance.timer;
            combo++;
            sumamountyen.text = "‚¨’Þ‚è";
            sumamounttext.color = Color.red;
            Data.total_Data.Total_Change_Amount += sumamount;

            if (gauge_state== State.Gauge.Gold)
            {
                if(selectgoodsso.judgement)
                {
                    Data.total_Data.Golden_Count += 1*2;
                }
                else
                {
                    Data.total_Data.Golden_Count += 1;
                }
                
            }
            //if(SentTimer==15)
            //{
            //    if (selectgoodsso.judgement)
            //    {
            //        Data.total_Data.Speed_Bonus15 += 1*2;
            //    }
            //    else
            //    {
            //        Data.total_Data.Speed_Bonus15 += 1;
            //    }
                    
            //}
            //else if(SentTimer == 20)
            //{
            //    if (selectgoodsso.judgement)
            //    {
            //        Data.total_Data.Speed_Bonus20 += 1*2;
            //    }
            //    else
            //    {
            //        Data.total_Data.Speed_Bonus20 += 1;
            //    }
                
            //}
        }
        else
        {
            combo = 0;
            sumamountyen.text = "Žx•¥ŽcŠz";
            sumamounttext.color = Color.blue;
        }
        yield return new WaitForSeconds(2.0f);

        GRADE.Instance.GRADE_(sumamount);

        yield return new WaitForSeconds(2.0f);
        //if (GradeAndCombo.Instance.Gameover_count != 3)
        //{
        //    selectgoods.SetActive(true);
        //}
        //Destroy(hyouka);
        //Destroy(comboobject);

        //if (GRADE.Instance.Gameover_count == 3)
        //{
        //    Action finish = () =>
        //    {
        //        bool a = Finish.activeSelf;
        //        Finish.SetActive(!a);
        //    };
        //    finish();
        //    AudioManager.Instance.seSource.PlayOneShot(sound.SEofFinish); ;

        //    yield return new WaitForSeconds(2.0f);

        //    Data.total_Data.Combo_Count = combo;
        //}
        //rndyentext();
        //Onpay = false;
    }
}
