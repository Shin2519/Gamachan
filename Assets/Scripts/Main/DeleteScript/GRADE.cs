using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GRADE : GradeAndCombo
{
    public static GRADE Instance;

    [SerializeField]
    private Sprite Out_count;

    [SerializeField]
    private Image[] Cross_Ren;
    
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
                hyouka = Instantiate(Grade, new Vector3(1300, 950, 0), Quaternion.identity);
                Grade_Ren = hyouka.GetComponent<SpriteRenderer>();
                //Grade_Ren.sprite = about_ui.Grade[3];
                if (gauge_state == State.Gauge.Gold)
                {
                    Gama_Image.sprite = about_ui.GoldenKindofemotion[1];
                }
                else
                {
                    Gama_Image.sprite = about_ui.Kindofemotion[1];
                }
                Data.total_Data.Perfect_Count += 1;
                Data.total_Data.Zero_Count += 1;
            }
            else if (SumAmount >= 1 && SumAmount <= 10)
            {
                Combo();
                AudioManager.Instance.seSource.PlayOneShot(sound.Great);
                hyouka = Instantiate(Grade, new Vector3(1300, 950, 0), Quaternion.identity);
                Grade_Ren = hyouka.GetComponent<SpriteRenderer>();
                Grade_Ren.sprite = about_ui.Grade[2];

                if(gauge_state == State.Gauge.Gold)
                {
                    Gama_Image.sprite = about_ui.GoldenKindofemotion[1];
                }
                else
                {
                    Gama_Image.sprite = about_ui.Kindofemotion[1];
                }
                Data.total_Data.Great_Count += 1;
            }
            else
            {
                Combo();
                AudioManager.Instance.seSource.PlayOneShot(sound.Good);

                Cross_Ren[Gameover_count].sprite = Out_count;
                Gameover_count++;
                hyouka = Instantiate(Grade, new Vector3(1300, 950, 0), Quaternion.identity);
                Grade_Ren = hyouka.GetComponent<SpriteRenderer>();
                Grade_Ren.sprite = about_ui.Grade[1];
                if (gauge_state == State.Gauge.Gold)
                {
                    Gama_Image.sprite = about_ui.GoldenKindofemotion[0];
                }
                else
                {
                    Gama_Image.sprite = about_ui.Kindofemotion[0];
                }
                Data.total_Data.Good_Count += 1;
            }
        }
        else
        {
            AudioManager.Instance.seSource.PlayOneShot(sound.Bad);
            int Count = 3 - Gameover_count;
            for (int i = 0; i < Count; i++)
            {
                Gameover_count++;
                Cross_Ren[Gameover_count - 1].sprite = Out_count;
            }
            hyouka = Instantiate(Grade, new Vector3(1300, 950, 0), Quaternion.identity);
            Grade_Ren = hyouka.GetComponent<SpriteRenderer>();
            Grade_Ren.sprite = about_ui.Grade[0];
            if (gauge_state == State.Gauge.Gold)
            {
                Gama_Image.sprite = about_ui.GoldenKindofemotion[2];
            }
            else
            {
                Gama_Image.sprite = about_ui.Kindofemotion[2];
            }
            Data.total_Data.Bad_Count += 1;
        }
    }
}
