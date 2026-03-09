using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TouchPanel : MasterCode
{
    public static TouchPanel instance;
    ChallengeScoreResult CS;
    [SerializeField,Header("ñ⁄ïWã‡äz")] private TextMeshProUGUI amounttext;//è§ïiÇÃã‡äzÉeÉLÉXÉg
    [SerializeField,Header("ìäì¸ã‡äz")] private TextMeshProUGUI inputamounttext;//ìäì¸ã‡äz(âº)ÉeÉLÉXÉg
    [SerializeField,Header("çáåvã‡äz")] private TextMeshProUGUI sumamounttext;//çáåvã‡äzÉeÉLÉXÉg(â~)
 
    // çáåvã‡äzÇ™+Ç©-Ç≈ï\é¶Ç∑ÇÈÉeÉLÉXÉgÇ™ïœÇÌÇÈÇΩÇﬂ
    [SerializeField] private TextMeshProUGUI sumamountyen;//çáåvã‡äzÉeÉLÉXÉg(Ç®íﬁÇËÅAéxï•écäz)
    [SerializeField] SelectGoodsSO selectgoodsso;
    private int inputamount = 0;
    public int sumamount;//çáåvã‡äz
    [SerializeField] GameObject selectgoods;
    public static GameObject hyouka;
    [Header("Gama")]
    public GameObject Gama;
    public static Image Gama_Image;
    public static GameObject comboobject;
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
        inputamounttext.text = inputamount.ToString() + "â~";
    }
    public void OnButton()
    {
        if (Onpay) return;
        StartCoroutine(kaikei());
        AudioManager.Instance.seSource.PlayOneShot(sound.Buttondown);
    }

    public void rndyentext()
    {
        //ñ⁄ïWã‡äz
        amounttext.text = selectgoodsso.total.ToString() + "â~";
        //ìäì¸ã‡äz
        inputamount = 0;
        inputamounttext.text = inputamount.ToString() + "â~";
        //çáåvã‡äz
        sumamounttext.text = sumamount.ToString() + "â~";


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

        sumamounttext.text = sumamount.ToString() + "â~";

        if (sumamount >= 0)
        {
            //float SentTimer = Timer.Instance.timer;
            combo++;
            sumamountyen.text = "Ç®íﬁÇË";
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
            sumamountyen.text = "éxï•écäz";
            sumamounttext.color = Color.blue;
        }
        yield return new WaitForSeconds(2.0f);

        GRADE.Instance.GRADE_(sumamount);

        yield return new WaitForSeconds(2.0f);
        if(GRADE.Instance.Gameover_count != 3)
        {
            selectgoods.SetActive(true);
        }
        Destroy(hyouka);
        Destroy(comboobject);

        if (GRADE.Instance.Gameover_count == 3)
        {            
            Timer.Instance.stop = true;
            UIManagement.instance.Finishistrue();
            AudioManager.Instance.seSource.PlayOneShot(sound.SEofFinish); ;

            yield return new WaitForSeconds(2.0f);

            Data.total_Data.Combo_Count = combo;
            
            Result.SetActive(true);

            ResultManager.Instance.ActiveAndSlide();

            ResultManager.Instance.SetScores(ScoreCalculator.Instance.ScoreData(Data));
            Gama.SetActive(false);
            RnkingData.instance.Register();
        }
        rndyentext();
        Onpay = false;
    }
}
