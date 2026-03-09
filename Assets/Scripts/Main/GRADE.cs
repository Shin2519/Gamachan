using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GRADE : MasterCode
{
    [SerializeField]
    private Somethings_State Gauge_State;
    public static GRADE Instance;
    public int Gameover_count = 0;

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
                AudioManager.Instance.seSource.PlayOneShot(sound.Perfect);
                TouchPanel.hyouka = Instantiate(Grade, new Vector3(1300, 950, 0), Quaternion.identity);
                Grade_Ren = TouchPanel.hyouka.GetComponent<SpriteRenderer>();
                Grade_Ren.sprite = about_ui.Grade[3];
                if (Gauge_State.gauge_state == Somethings_State.Gauge_State.Gold)
                {
                    TouchPanel.Gama_Image.sprite = about_ui.GoldenKindofemotion[1];
                }
                else
                {
                    TouchPanel.Gama_Image.sprite = about_ui.Kindofemotion[1];
                }
                Data.total_Data.Perfect_Count += 1;
                Data.total_Data.Zero_Count += 1;
            }
            else if (SumAmount >= 1 && SumAmount <= 10)
            {
                Combo();
                AudioManager.Instance.seSource.PlayOneShot(sound.Great);
                TouchPanel.hyouka = Instantiate(Grade, new Vector3(1300, 950, 0), Quaternion.identity);
                Grade_Ren = TouchPanel.hyouka.GetComponent<SpriteRenderer>();
                Grade_Ren.sprite = about_ui.Grade[2];

                if(Gauge_State.gauge_state ==Somethings_State.Gauge_State.Gold)
                {
                    TouchPanel.Gama_Image.sprite = about_ui.GoldenKindofemotion[1];
                }
                else
                {
                    TouchPanel.Gama_Image.sprite = about_ui.Kindofemotion[1];
                }
                Data.total_Data.Great_Count += 1;
            }
            else
            {
                Combo();
                AudioManager.Instance.seSource.PlayOneShot(sound.Good);
                if (!Cross.activeSelf)
                {
                    Cross.SetActive(true);
                }
                Cross_Ren[Gameover_count].sprite = Out_count;
                Gameover_count++;
                TouchPanel.hyouka = Instantiate(Grade, new Vector3(1300, 950, 0), Quaternion.identity);
                Grade_Ren = TouchPanel.hyouka.GetComponent<SpriteRenderer>();
                Grade_Ren.sprite = about_ui.Grade[1];
                if (Gauge_State.gauge_state == Somethings_State.Gauge_State.Gold)
                {
                    TouchPanel.Gama_Image.sprite = about_ui.GoldenKindofemotion[0];
                }
                else
                {
                    TouchPanel.Gama_Image.sprite = about_ui.Kindofemotion[0];
                }
                Data.total_Data.Good_Count += 1;
            }
        }
        else
        {
            if (!Cross.activeSelf)
            {
                Cross.SetActive(true);
            }
            AudioManager.Instance.seSource.PlayOneShot(sound.Bad);
            int Count = 3 - Gameover_count;
            for (int i = 0; i < Count; i++)
            {
                Gameover_count++;
                Cross_Ren[Gameover_count - 1].sprite = Out_count;
            }
            TouchPanel.hyouka = Instantiate(Grade, new Vector3(1300, 950, 0), Quaternion.identity);
            Grade_Ren = TouchPanel.hyouka.GetComponent<SpriteRenderer>();
            Grade_Ren.sprite = about_ui.Grade[0];
            if (Gauge_State.gauge_state == Somethings_State.Gauge_State.Gold)
            {
                TouchPanel.Gama_Image.sprite = about_ui.GoldenKindofemotion[2];
            }
            else
            {
                TouchPanel.Gama_Image.sprite = about_ui.Kindofemotion[2];
            }
            Data.total_Data.Bad_Count += 1;
        }
    }
    void Combo()
    {
        int i = 0;
        switch (combo)
        {
            case 3:
                ComboObjects(i);
                break;
            case 6:
                i = 1;
                ComboObjects(i);
                break;
            case 9:
                i = 2;
                ComboObjects(i);
                break;
            case 12:
                i = 3;
                ComboObjects(i);
                break;
            case 15:
                i = 4;
                ComboObjects(i);
                break;
            case 18:
                i = 5;
                ComboObjects(i);
                break;
            case 21:
                i = 6;
                ComboObjects(i);
                break;
            case 24:
                i = 7;
                ComboObjects(i);
                break;
            case 27:
                i = 8;
                ComboObjects(i);
                break;
            case 30:
                i = 9;
                ComboObjects(i);
                break;
        }
    }

    void ComboObjects(int i)
    {
        TouchPanel.comboobject = Instantiate(combo_image, new Vector3(1750, 1000, 0), Quaternion.identity);
        combo_Renderer = TouchPanel.comboobject.GetComponent<SpriteRenderer>();
        combo_Renderer.sprite = about_ui.Kindofcombo[i];
    }
}
