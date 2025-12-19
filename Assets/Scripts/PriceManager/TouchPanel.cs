using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TouchPanel : MonoBehaviour
{
    public static int combo;
    public static TouchPanel instance;
    [SerializeField,Header("ñ⁄ïWã‡äz")] private TextMeshProUGUI amounttext;//è§ïiÇÃã‡äzÉeÉLÉXÉg
    [SerializeField,Header("ìäì¸ã‡äz")] private TextMeshProUGUI inputamounttext;//ìäì¸ã‡äz(âº)ÉeÉLÉXÉg
    [SerializeField,Header("çáåvã‡äz")] private TextMeshProUGUI sumamounttext;//çáåvã‡äzÉeÉLÉXÉg(â~)
 
    // çáåvã‡äzÇ™+Ç©-Ç≈ï\é¶Ç∑ÇÈÉeÉLÉXÉgÇ™ïœÇÌÇÈÇΩÇﬂ
    [SerializeField] private TextMeshProUGUI sumamountyen;//çáåvã‡äzÉeÉLÉXÉg(Ç®íﬁÇËÅAéxï•écäz)
    [SerializeField] SelectGoodsSO selectgoodsso;
    [SerializeField]
    private int inputamount = 0;
    private float sumamount;//çáåvã‡äz
    [SerializeField] SelectGoods selectgoods;
    public static GameObject hyouka;
    [SerializeField, Header("Gama")]
    public GameObject Gama;
    Image Gama_Image;
    [SerializeField, Header("GamaÇÃä¥èÓ")]
    Sprite[] KindofEmotion;
    [SerializeField]
    private Sprite[] Kindcombo;
    public static GameObject comboobject;
    public GameObject Cross;
    [SerializeField] private Image[] image;

    [SerializeField, Header("âüÇµÇΩÇ∆Ç´ÇÃâπ")]
    AudioClip buttondown;
    AudioSource audiosource;
    public int InputAmount {  get { return inputamount; } set { inputamount = value; } }
    public int Total => selectgoodsso.total;
    void Awake()
    {
        instance = this;
        Gama_Image = Gama.GetComponent<Image>();
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

    void rndyentext()
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
    }

    IEnumerator kaikei()
    {
        sumamount = selectgoodsso.total - inputamount;
        sumamounttext.enabled = true;
        sumamountyen.enabled = true;

        sumamounttext.text = sumamount.ToString() + "â~";

        if (sumamount >= 0)
        {
            combo++;
            sumamountyen.text = "Ç®íﬁÇË";
            sumamounttext.color = Color.red;
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

        Destroy(hyouka);
        Destroy(comboobject);

        Gama_Image.sprite = KindofEmotion[0];

        rndyentext();
    }
}
