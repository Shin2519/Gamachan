using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class TouchPanel : MonoBehaviour
{
    public static int combo;
    public static TouchPanel instance;
    [SerializeField]
    SendData Data;
    [SerializeField]
    UI Gama_Emotion;
    [SerializeField]
    Somethings_State Gauge_State;
    [SerializeField]
    private Sound SE;
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
    public static AudioSource audiosource;

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
        audiosource = GetComponent<AudioSource>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rndyentext();
        Cross.SetActive(false);
        Result.SetActive(false);
    }
    void Update()
    {
        inputamounttext.text = inputamount.ToString() + "â~";
    }
    public void OnButton()
    {
        StartCoroutine(kaikei());
        audiosource.PlayOneShot(SE.Buttondown);
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
        if (Gauge_State.gauge_state==Somethings_State.Gauge_State.Gold)
        {
            Gama_Image.sprite = Gama_Emotion.GoldenKindofemotion[0];
        }
    }

    IEnumerator kaikei()
    {
        gametext.SetActive(false);
        Onpay = true;
        sumamount = inputamount - selectgoodsso.total;
        sumamounttext.enabled = true;
        sumamountyen.enabled = true;

        sumamounttext.text = sumamount.ToString() + "â~";

        if (sumamount >= 0)
        {
            combo++;
            sumamountyen.text = "Ç®íﬁÇË";
            sumamounttext.color = Color.red;
            Data.total_Data.Total_Change_Amount += sumamount;

            if(Gauge_State.gauge_state==Somethings_State.Gauge_State.Gold)
            {
                Data.total_Data.Golden_Count += 1;
            }
            
            if (sumamount==0)
            {
                Timer.Instance.timer += 15;
            }
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
            audiosource.PlayOneShot(SE.SEofFinish);

            yield return new WaitForSeconds(2.0f);

            Data.total_Data.Combo_Count = combo;

            //ResultManager.Instance.SetScores(ScoreCalculator.Instance.CalculateChallenge(Data));

            //SceneManager.LoadScene("Resultpanel");
            Result.SetActive(true);
        }
            rndyentext();
        Onpay = false;
    }
}
