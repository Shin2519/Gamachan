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
    [SerializeField,Header("ñ⁄ïWã‡äz")] private TextMeshProUGUI amounttext;//è§ïiÇÃã‡äzÉeÉLÉXÉg
    [SerializeField,Header("ìäì¸ã‡äz")] private TextMeshProUGUI inputamounttext;//ìäì¸ã‡äz(âº)ÉeÉLÉXÉg
    [SerializeField,Header("çáåvã‡äz")] private TextMeshProUGUI sumamounttext;//çáåvã‡äzÉeÉLÉXÉg(â~)
 
    // çáåvã‡äzÇ™+Ç©-Ç≈ï\é¶Ç∑ÇÈÉeÉLÉXÉgÇ™ïœÇÌÇÈÇΩÇﬂ
    [SerializeField] private TextMeshProUGUI sumamountyen;//çáåvã‡äzÉeÉLÉXÉg(Ç®íﬁÇËÅAéxï•écäz)
    [SerializeField] SelectGoodsSO selectgoodsso;
    [SerializeField]
    private int inputamount = 0;
    private int sumamount;//çáåvã‡äz
    [SerializeField] GameObject selectgoods;
    public static GameObject hyouka;
    [SerializeField, Header("Gama")]
    public GameObject Gama;
    public static Image Gama_Image;
    [SerializeField, Header("GamaÇÃä¥èÓ")]
    Sprite[] KindofEmotion;
    [SerializeField]
    private Sprite[] Kindcombo;
    public static GameObject comboobject;
    public GameObject Cross;

    [SerializeField, Header("âüÇµÇΩÇ∆Ç´ÇÃâπ")]
    AudioClip buttondown;
    [SerializeField, Header("èIÇÌÇËÇÃâπ")]
    AudioClip SEofFinish;
    public static AudioSource audiosource;
    public int InputAmount {  get { return inputamount; } set { inputamount = value; } }
    public int Total => selectgoodsso.total;

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
    }
    void Update()
    {
        inputamounttext.text = inputamount.ToString() + "â~";
    }
    public void OnButton()
    {
        StartCoroutine(kaikei());
        audiosource.PlayOneShot(buttondown);
        
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

        Debug.Log(UIManagement.instance.state);

        if (UIManagement.instance.state == UIManagement.STATE.Gold)
        {
            Gama_Image.sprite = GRADE.Instance.GoldenKindofEmotion[0];
        }
    }

    IEnumerator kaikei()
    {
        sumamount = inputamount - selectgoodsso.total;
        sumamounttext.enabled = true;
        sumamountyen.enabled = true;

        sumamounttext.text = sumamount.ToString() + "â~";

        if (sumamount >= 0)
        {
            combo++;
            sumamountyen.text = "Ç®íﬁÇË";
            sumamounttext.color = Color.red;
            Data.TotalSumAmount += sumamount;
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
            audiosource.PlayOneShot(SEofFinish);

            yield return new WaitForSeconds(2.0f);

            Data.Combo_count = combo;

            SceneManager.LoadScene("Resultpanel");
        }
            rndyentext();
    }
}
