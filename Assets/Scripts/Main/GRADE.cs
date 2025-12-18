using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GRADE : MonoBehaviour
{
    public static GRADE Instance;
    int Gameover_count = 0;
    Image Gama_Image;

    [SerializeField]
    private Sprite Out_count;
    [SerializeField]
    private Sprite[] Grade_Sp;
    [SerializeField, Header("GamaÇÃä¥èÓ")]
    Sprite[] KindofEmotion;
    [SerializeField]
    private Sprite[] Kindcombo;

    SpriteRenderer Grade_Ren;
    SpriteRenderer combo_Renderer;

    [SerializeField]
    private Image[] Cross_Ren;

    [SerializeField]
    private GameObject Grade;
    [SerializeField]
    private GameObject combo_image;
    [SerializeField, Header("GameoverÇ‹Ç≈ÇÃÉJÉEÉìÉg")]
    private GameObject Cross;

    void Awake()
    {
        Grade_Ren = Grade.GetComponent<SpriteRenderer>();
        Gama_Image = TachPanel.instance.Gama.GetComponent<Image>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GRADE_(float SumAmount)
    {
        if (SumAmount >= 0)
        {
            if (SumAmount == 0)
            {
                Combo();
                TachPanel.hyouka = Instantiate(Grade, new Vector3(1175, 886, 0), Quaternion.identity);
                Grade_Ren = TachPanel.hyouka.GetComponent<SpriteRenderer>();
                Grade_Ren.sprite = Grade_Sp[3];
                Gama_Image.sprite = KindofEmotion[1];
            }
            else if (SumAmount >= 1 && SumAmount <= 10)
            {
                Combo();
                TachPanel.hyouka = Instantiate(Grade, new Vector3(1175, 886, 0), Quaternion.identity);
                Grade_Ren = TachPanel.hyouka.GetComponent<SpriteRenderer>();
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
                TachPanel.hyouka = Instantiate(Grade, new Vector3(1175, 886, 0), Quaternion.identity);
                Grade_Ren = TachPanel.hyouka.GetComponent<SpriteRenderer>();
                Grade_Ren.sprite = Grade_Sp[1];
            }
        }
        else
        {
            if (!Cross.activeSelf)
            {
                Cross.SetActive(true);
            }
            int Count = 3 - Gameover_count;
            for (int i = 0; i < Count; i++)
            {
                Gameover_count++;
                Cross_Ren[Gameover_count - 1].sprite = Out_count;
            }
            TachPanel.hyouka = Instantiate(Grade, new Vector3(1175, 886, 0), Quaternion.identity);
            Grade_Ren = TachPanel.hyouka.GetComponent<SpriteRenderer>();
            Grade_Ren.sprite = Grade_Sp[0];
            Gama_Image.sprite = KindofEmotion[2];
        }
    }
    void Combo()
    {
        switch (TachPanel.combo)
        {
            case 3:
                TachPanel.comboobject = Instantiate(combo_image, new Vector3(1628, 926, 0), Quaternion.identity);
                combo_Renderer = TachPanel.comboobject.GetComponent<SpriteRenderer>();
                combo_Renderer.sprite = Kindcombo[0];
                break;
            case 6:
                TachPanel.comboobject = Instantiate(combo_image, new Vector3(1628, 926, 0), Quaternion.identity);
                combo_Renderer = TachPanel.comboobject.GetComponent<SpriteRenderer>();
                combo_Renderer.sprite = Kindcombo[1];
                break;
            case 9:
                TachPanel.comboobject = Instantiate(combo_image, new Vector3(1628, 926, 0), Quaternion.identity);
                combo_Renderer = TachPanel.comboobject.GetComponent<SpriteRenderer>();
                combo_Renderer.sprite = Kindcombo[2];
                break;
            case 12:
                TachPanel.comboobject = Instantiate(combo_image, new Vector3(1628, 926, 0), Quaternion.identity);
                combo_Renderer = TachPanel.comboobject.GetComponent<SpriteRenderer>();
                combo_Renderer.sprite = Kindcombo[3];
                break;
            case 15:
                TachPanel.comboobject = Instantiate(combo_image, new Vector3(1628, 926, 0), Quaternion.identity);
                combo_Renderer = TachPanel.comboobject.GetComponent<SpriteRenderer>();
                combo_Renderer.sprite = Kindcombo[4];
                break;
            case 18:
                TachPanel.comboobject = Instantiate(combo_image, new Vector3(1628, 926, 0), Quaternion.identity);
                combo_Renderer = TachPanel.comboobject.GetComponent<SpriteRenderer>();
                combo_Renderer.sprite = Kindcombo[5];
                break;
            case 21:
                TachPanel.comboobject = Instantiate(combo_image, new Vector3(1628, 926, 0), Quaternion.identity);
                combo_Renderer = TachPanel.comboobject.GetComponent<SpriteRenderer>();
                combo_Renderer.sprite = Kindcombo[6];
                break;
            case 24:
                TachPanel.comboobject = Instantiate(combo_image, new Vector3(1628, 926, 0), Quaternion.identity);
                combo_Renderer = TachPanel.comboobject.GetComponent<SpriteRenderer>();
                combo_Renderer.sprite = Kindcombo[7];
                break;
            case 27:
                TachPanel.comboobject = Instantiate(combo_image, new Vector3(1628, 926, 0), Quaternion.identity);
                combo_Renderer = TachPanel.comboobject.GetComponent<SpriteRenderer>();
                combo_Renderer.sprite = Kindcombo[8];
                break;
            case 30:
                TachPanel.comboobject = Instantiate(combo_image, new Vector3(1628, 926, 0), Quaternion.identity);
                combo_Renderer = TachPanel.comboobject.GetComponent<SpriteRenderer>();
                combo_Renderer.sprite = Kindcombo[9];
                break;
        }
    }
}
