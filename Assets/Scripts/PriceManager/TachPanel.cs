using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TachPanel : MonoBehaviour
{
    int rnd;
    public static TachPanel instance;
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
    [SerializeField]
    private Sprite[] Grade_Sp;
    [SerializeField]
    private GameObject Grade;
    SpriteRenderer Grade_Ren;
    GameObject hyouka;
    [SerializeField, Header("Gama")]
    GameObject Gama;
    Image Gama_Image;
    [SerializeField, Header("GamaÇÃä¥èÓ")]
    Sprite[] KindofEmotion;
    [SerializeField]
    private GameObject combo_image;
    SpriteRenderer combo_Renderer;
    [SerializeField]
    private Sprite[] Kindcombo;
    [SerializeField]
    private int combo = 0;
    GameObject comboobject;
    [SerializeField, Header("GameoverÇ‹Ç≈ÇÃÉJÉEÉìÉg")]
    private GameObject Cross;
    [SerializeField]
    private Image[] Cross_Ren;
    [SerializeField]
    private Sprite Out_count;
    int Gameover_count = 0;
    [SerializeField] private Image[] image;
    public int InputAmount {  get { return inputamount; } set { inputamount = value; } }
    void Awake()
    {
        instance = this;
        Grade_Ren = Grade.GetComponent<SpriteRenderer>();
        Gama_Image = Gama.GetComponent<Image>();
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
    }

    void rndyentext()
    {
        rnd = Random.Range(500, 1000);
        //ñ⁄ïWã‡äz
        //amounttext.text = selectgoodsso.total.ToString() + "â~";
        amounttext.text = rnd.ToString() + "â~";
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
        //sumamount = selectgoodsso.total - inputamount;
        sumamount = inputamount - rnd;
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

        GRADE();

        yield return new WaitForSeconds(2.0f);

        Destroy(hyouka);
        Destroy(comboobject);

        Gama_Image.sprite = KindofEmotion[0];

        rndyentext();
        //if (sumamount < 0)
        //{
        //    sumamountyen.text = "Ç®íﬁÇË";
        //    sumamounttext.text = Mathf.Abs(sumamount).ToString() + "â~";
        //    sumamounttext.color = Color.blue;
        //}
        //else
        //{
        //    sumamountyen.text = "éxï•écäz";
        //    sumamounttext.text = "-"+ sumamount.ToString() + "â~";
        //    sumamounttext.color = Color.red;
        //}
    }

    void GRADE()
    {
        if (sumamount >= 0)
        {
            if(sumamount==0)
            {
                Combo();
                hyouka = Instantiate(Grade, new Vector3(1175, 886, 0), Quaternion.identity);
                Grade_Ren = hyouka.GetComponent<SpriteRenderer>();
                Grade_Ren.sprite = Grade_Sp[3];
                Gama_Image.sprite = KindofEmotion[1];
            }
            else if(sumamount >=1&&sumamount<=10)
            {
                Combo();
                hyouka = Instantiate(Grade, new Vector3(1175, 886, 0), Quaternion.identity);
                Grade_Ren = hyouka.GetComponent<SpriteRenderer>();
                Grade_Ren.sprite = Grade_Sp[2];
                Gama_Image.sprite = KindofEmotion[1];
            }
            else
            {
                Combo();
                if (!Cross.activeSelf)
                {
                    Cross.SetActive(true);
                }
                Cross_Ren[Gameover_count].sprite = Out_count;
                Gameover_count++;
                hyouka = Instantiate(Grade, new Vector3(1175, 886, 0), Quaternion.identity);
                Grade_Ren = hyouka.GetComponent<SpriteRenderer>();
                Grade_Ren.sprite = Grade_Sp[1];
            }
        }
        else
        {
            if(!Cross.activeSelf)
            {
                Cross.SetActive(true);
            }
            int Count = 3 - Gameover_count;
            for(int i = 0;i < Count;i++)
            {
                Gameover_count++;
                Cross_Ren[Gameover_count -1].sprite = Out_count;
            }
            hyouka = Instantiate(Grade, new Vector3(1175, 886, 0), Quaternion.identity);
            Grade_Ren = hyouka.GetComponent<SpriteRenderer>();
            Grade_Ren.sprite = Grade_Sp[0];
            Gama_Image.sprite = KindofEmotion[2];
        }
    }

    void Combo()
    {
        switch (combo)
        {
            case 3:
                comboobject = Instantiate(combo_image, new Vector3(1628, 926, 0), Quaternion.identity);
                combo_Renderer = comboobject.GetComponent<SpriteRenderer>();
                combo_Renderer.sprite = Kindcombo[0];
                break;
            case 6:
                comboobject = Instantiate(combo_image, new Vector3(1628, 926, 0), Quaternion.identity);
                combo_Renderer = comboobject.GetComponent<SpriteRenderer>();
                combo_Renderer.sprite = Kindcombo[1];
                break;
            case 9:
                comboobject = Instantiate(combo_image, new Vector3(1628, 926, 0), Quaternion.identity);
                combo_Renderer = comboobject.GetComponent<SpriteRenderer>();
                combo_Renderer.sprite = Kindcombo[2];
                break;
            case 12:
                comboobject = Instantiate(combo_image, new Vector3(1628, 926, 0), Quaternion.identity);
                combo_Renderer = comboobject.GetComponent<SpriteRenderer>();
                combo_Renderer.sprite = Kindcombo[3];
                break;
            case 15:
                comboobject = Instantiate(combo_image, new Vector3(1628, 926, 0), Quaternion.identity);
                combo_Renderer = comboobject.GetComponent<SpriteRenderer>();
                combo_Renderer.sprite = Kindcombo[4];
                break;
            case 18:
                comboobject = Instantiate(combo_image, new Vector3(1628, 926, 0), Quaternion.identity);
                combo_Renderer = comboobject.GetComponent<SpriteRenderer>();
                combo_Renderer.sprite = Kindcombo[5];
                break;
            case 21:
                comboobject = Instantiate(combo_image, new Vector3(1628, 926, 0), Quaternion.identity);
                combo_Renderer = comboobject.GetComponent<SpriteRenderer>();
                combo_Renderer.sprite = Kindcombo[6];
                break;
            case 24:
                comboobject = Instantiate(combo_image, new Vector3(1628, 926, 0), Quaternion.identity);
                combo_Renderer = comboobject.GetComponent<SpriteRenderer>();
                combo_Renderer.sprite = Kindcombo[7];
                break;
            case 27:
                comboobject = Instantiate(combo_image, new Vector3(1628, 926, 0), Quaternion.identity);
                combo_Renderer = comboobject.GetComponent<SpriteRenderer>();
                combo_Renderer.sprite = Kindcombo[8];
                break;
            case 30:
                comboobject = Instantiate(combo_image, new Vector3(1628, 926, 0), Quaternion.identity);
                combo_Renderer = comboobject.GetComponent<SpriteRenderer>();
                combo_Renderer.sprite = Kindcombo[9];
                break;
        }
    }
}
