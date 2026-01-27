using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GRADE : MonoBehaviour
{
    [SerializeField]
    SendData Data;
    [SerializeField]
    private UI ui;
    [SerializeField]
    private Somethings_State Gauge_State;
    [SerializeField]
    private Sound SE;
    public static GRADE Instance;
    public int Gameover_count = 0;
    Image Gama_Image;

    [SerializeField]
    private Sprite Out_count;
    SpriteRenderer Grade_Ren;
    SpriteRenderer combo_Renderer;

    [SerializeField]
    private Image[] Cross_Ren;

    [SerializeField]
    private GameObject Grade;
    [SerializeField]
    private GameObject combo_image;
    [SerializeField, Header("Gameover‚Ü‚Å‚ÌƒJƒEƒ“ƒg")]
    private GameObject Cross;
    void Awake()
    {
        Instance = this;
        Grade_Ren = Grade.GetComponent<SpriteRenderer>();
        Gama_Image = TouchPanel.instance.Gama.GetComponent<Image>();
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
                TouchPanel.audiosource.PlayOneShot(SE.Perfect);
                TouchPanel.hyouka = Instantiate(Grade, new Vector3(1175, 886, 0), Quaternion.identity);
                Grade_Ren = TouchPanel.hyouka.GetComponent<SpriteRenderer>();
                Grade_Ren.sprite = ui.Grade[3];
                if (Gauge_State.gauge_state == Somethings_State.Gauge_State.Gold)
                {
                    Gama_Image.sprite = ui.GoldenKindofemotion[1];
                }
                Gama_Image.sprite = ui.Kindofemotion[1];
                Data.Perfect_count+=1;
                Data.JustSumAmount_Bonus += 1;
            }
            else if (SumAmount >= 1 && SumAmount <= 10)
            {
                Combo();
                TouchPanel.audiosource.PlayOneShot(SE.Great);
                TouchPanel.hyouka = Instantiate(Grade, new Vector3(1175, 886, 0), Quaternion.identity);
                Grade_Ren = TouchPanel.hyouka.GetComponent<SpriteRenderer>();
                Grade_Ren.sprite = ui.Grade[2];

                if(Gauge_State.gauge_state ==Somethings_State.Gauge_State.Gold)
                {
                    Gama_Image.sprite = ui.GoldenKindofemotion[1];
                }
                else
                {
                    Gama_Image.sprite = ui.Kindofemotion[1];
                }
                Data.Great_count += 1;
            }
            else
            {
                Combo();
                TouchPanel.audiosource.PlayOneShot(SE.Good);
                if (!Cross.activeSelf)
                {
                    Cross.SetActive(true);
                }
                Cross_Ren[Gameover_count].sprite = Out_count;
                Gameover_count++;
                TouchPanel.hyouka = Instantiate(Grade, new Vector3(1175, 886, 0), Quaternion.identity);
                Grade_Ren = TouchPanel.hyouka.GetComponent<SpriteRenderer>();
                Grade_Ren.sprite = ui.Grade[1];
                if (Gauge_State.gauge_state == Somethings_State.Gauge_State.Gold)
                {
                    Gama_Image.sprite = ui.GoldenKindofemotion[0];
                }
                else
                {
                    Gama_Image.sprite = ui.Kindofemotion[0];
                }
                Data.Good_count += 1;
            }
        }
        else
        {
            if (!Cross.activeSelf)
            {
                Cross.SetActive(true);
            }
            TouchPanel.audiosource.PlayOneShot(SE.Bad);
            int Count = 3 - Gameover_count;
            for (int i = 0; i < Count; i++)
            {
                Gameover_count++;
                Cross_Ren[Gameover_count - 1].sprite = Out_count;
            }
            TouchPanel.hyouka = Instantiate(Grade, new Vector3(1175, 886, 0), Quaternion.identity);
            Grade_Ren = TouchPanel.hyouka.GetComponent<SpriteRenderer>();
            Grade_Ren.sprite = ui.Grade[0];
            if (Gauge_State.gauge_state == Somethings_State.Gauge_State.Gold)
            {
                Gama_Image.sprite = ui.GoldenKindofemotion[2];
            }
            else
            {
                Gama_Image.sprite = ui.Kindofemotion[2];
            }
            Data.Bad_count += 1;
        }
    }
    void Combo()
    {
        switch (TouchPanel.combo)
        {
            case 3:
                TouchPanel.comboobject = Instantiate(combo_image, new Vector3(1628, 926, 0), Quaternion.identity);
                combo_Renderer = TouchPanel.comboobject.GetComponent<SpriteRenderer>();
                combo_Renderer.sprite = ui.Kindofcombo[0];
                break;
            case 6:
                TouchPanel.comboobject = Instantiate(combo_image, new Vector3(1628, 926, 0), Quaternion.identity);
                combo_Renderer = TouchPanel.comboobject.GetComponent<SpriteRenderer>();
                combo_Renderer.sprite = ui.Kindofcombo[1];
                break;
            case 9:
                TouchPanel.comboobject = Instantiate(combo_image, new Vector3(1628, 926, 0), Quaternion.identity);
                combo_Renderer = TouchPanel.comboobject.GetComponent<SpriteRenderer>();
                combo_Renderer.sprite = ui.Kindofcombo[2];
                break;
            case 12:
                TouchPanel.comboobject = Instantiate(combo_image, new Vector3(1628, 926, 0), Quaternion.identity);
                combo_Renderer = TouchPanel.comboobject.GetComponent<SpriteRenderer>();
                combo_Renderer.sprite = ui.Kindofcombo[3];
                break;
            case 15:
                TouchPanel.comboobject = Instantiate(combo_image, new Vector3(1628, 926, 0), Quaternion.identity);
                combo_Renderer = TouchPanel.comboobject.GetComponent<SpriteRenderer>();
                combo_Renderer.sprite = ui.Kindofcombo[4];
                break;
            case 18:
                TouchPanel.comboobject = Instantiate(combo_image, new Vector3(1628, 926, 0), Quaternion.identity);
                combo_Renderer = TouchPanel.comboobject.GetComponent<SpriteRenderer>();
                combo_Renderer.sprite = ui.Kindofcombo[5];
                break;
            case 21:
                TouchPanel.comboobject = Instantiate(combo_image, new Vector3(1628, 926, 0), Quaternion.identity);
                combo_Renderer = TouchPanel.comboobject.GetComponent<SpriteRenderer>();
                combo_Renderer.sprite = ui.Kindofcombo[6];
                break;
            case 24:
                TouchPanel.comboobject = Instantiate(combo_image, new Vector3(1628, 926, 0), Quaternion.identity);
                combo_Renderer = TouchPanel.comboobject.GetComponent<SpriteRenderer>();
                combo_Renderer.sprite = ui.Kindofcombo[7];
                break;
            case 27:
                TouchPanel.comboobject = Instantiate(combo_image, new Vector3(1628, 926, 0), Quaternion.identity);
                combo_Renderer = TouchPanel.comboobject.GetComponent<SpriteRenderer>();
                combo_Renderer.sprite = ui.Kindofcombo[8];
                break;
            case 30:
                TouchPanel.comboobject = Instantiate(combo_image, new Vector3(1628, 926, 0), Quaternion.identity);
                combo_Renderer = TouchPanel.comboobject.GetComponent<SpriteRenderer>();
                combo_Renderer.sprite = ui.Kindofcombo[9];
                break;
        }
    }
}
