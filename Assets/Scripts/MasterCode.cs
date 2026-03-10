using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace State
{
    public enum Gauge
    {
        Normal,
        Gold
    }
    public enum Speed
    {
        TooFast,
        Fast,
        Soso,
        Slow,
        TooSlow
    }
}
public class MasterCode : MonoBehaviour
{
    public static MasterCode instance;

    protected State.Gauge gauge_state;

    protected State.Speed speed_state;

    [SerializeField]
    protected Sound sound;

    [SerializeField]
    protected SendData Data;

    [SerializeField]
    protected UI about_ui;

    [SerializeField]
    protected GameObject Finish;

    [SerializeField]
    protected GameObject Panel;

    protected GameObject hyouka;

    protected Image Gama_Image;

    protected Color color;
    //タイマー
    protected float gameTimer =300;

    protected int combo;

    protected GameObject comboobject;

    protected bool isDown = false;

    public float Currentgauge { get { return about_ui.Current; } set { about_ui.Current = Mathf.Clamp(value, about_ui.Min, about_ui.Max); } }

    void Awake()
    {
        instance = this;
    }
    
    public void gauge()
    {
        if (!isDown)
        {
            Currentgauge += 5 * Time.deltaTime;
        }
    }
    public void Finishistrue()
    {
        Finish.SetActive(true);
    }
    public void DownTimer(GameObject countdown, TextMeshProUGUI timetext, bool stop)
    {
        int minuts = Mathf.FloorToInt(gameTimer / 60);
        int seconds = Mathf.FloorToInt(gameTimer % 60);
        if (!countdown.activeSelf)
        {
            gameTimer -= Time.fixedDeltaTime;
        }

        if (gameTimer > 0 && !stop)
        {
            timetext.text = string.Format("TIME:" + "{0:D2}:{1:D2}", minuts, seconds);
        }

        if (10 < gameTimer && gameTimer <= 30)
        {
            timetext.color = new Color32(255, 128, 0, 255);//オレンジ
        }
        else if (gameTimer <= 10)
        {
            timetext.color = new Color32(255, 0, 0, 255);//赤
        }
    }

    //UIカウントダウン
    public void CountDownUI(GameObject one, GameObject two, GameObject three, GameObject finish)
    {
        switch(gameTimer)
        {
            case <= -2:
                finish.SetActive(false);
                break;
            case <=1:
                one.SetActive(false);
                finish.SetActive(true);
                break;
            case <=2:
                two.SetActive(false);
                one.SetActive(true);
                break;
            case <= 3:
                three.SetActive(false);
                two.SetActive(true);
                break;
            case <= 4:
                three.SetActive(true);
                break;
        }
    }
}

public class GradeAndCombo : MasterCode
{
    protected int Gameover_count = 0;

    protected SpriteRenderer Grade_Ren;

    [SerializeField]
    protected GameObject Grade;

    [SerializeField]
    protected GameObject combo_image;
    
    SpriteRenderer combo_Renderer;
    protected void Combo()
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
        comboobject = Instantiate(combo_image, new Vector3(1750, 1000, 0), Quaternion.identity);
        combo_Renderer = comboobject.GetComponent<SpriteRenderer>();
        combo_Renderer.sprite = about_ui.Kindofcombo[i];
    }
}
public class GAUGE : MasterCode
{
    [SerializeField, Header("ゲージイメージ")]
    protected Image Gauge;

    protected IEnumerator ColorChange()
    {
        while (Gauge.fillAmount > 0)
        {
            Color gauge_color = Gauge.color;
            float rnd_R = Random.Range(0.0f, 1.0f);
            float rnd_G = Random.Range(0.0f, 1.0f);
            float rnd_B = Random.Range(0.0f, 1.0f);
            gauge_color.r = rnd_R;
            gauge_color.g = rnd_G;
            gauge_color.b = rnd_B;
            Gauge.color = gauge_color;
            yield return new WaitForSeconds(0.5f);
        }
    }
    protected IEnumerator GaugeDown()
    {
        isDown = true;

        while (Gauge.fillAmount > 0)
        {
            if (Panel.activeSelf) break;
            yield return new WaitUntil(() => !TouchPanel.instance.Onpay);
            Currentgauge -= 1 * Time.deltaTime;
            yield return null;
        }
        gauge_state = State.Gauge.Normal;
        Gama_Image.sprite = about_ui.Kindofemotion[0];
        Gauge.color = color;
        isDown = false;
    }
}

public class GAMACHAN : MasterCode
{
    [SerializeField, Header("ガマちゃん")]
    protected GameObject Gama;

    private GameObject[] smallmoney_500 = new GameObject[10];
    private GameObject[] smallmoney_100 = new GameObject[10];
    private GameObject[] smallmoney_50 = new GameObject[10];
    private GameObject[] smallmoney_10 = new GameObject[10];
    private GameObject[] smallmoney_5 = new GameObject[10];
    private GameObject[] smallmoney_1 = new GameObject[10];

    protected IEnumerator St()
    {
        for (int i = 0; i < 10; i++)
        {
            smallmoney_500[i] = Instantiate(about_ui.Kindofsmallmoney[0], new Vector3(1000.0f, 1000.0f, 0.0f), Quaternion.identity);
            smallmoney_500[i].GetComponent<Collider2D>().enabled = false;
            smallmoney_500[i].SetActive(false);
            yield return null;
            smallmoney_100[i] = Instantiate(about_ui.Kindofsmallmoney[1], new Vector3(1000.0f, 1000.0f, 0.0f), Quaternion.identity);
            smallmoney_100[i].GetComponent<Collider2D>().enabled = false;
            smallmoney_100[i].SetActive(false);
            yield return null;
            smallmoney_50[i] = Instantiate(about_ui.Kindofsmallmoney[2], new Vector3(1000.0f, 1000.0f, 0.0f), Quaternion.identity);
            smallmoney_50[i].GetComponent<Collider2D>().enabled = false;
            smallmoney_50[i].SetActive(false);
            yield return null;
            smallmoney_10[i] = Instantiate(about_ui.Kindofsmallmoney[3], new Vector3(1000.0f, 1000.0f, 0.0f), Quaternion.identity);
            smallmoney_10[i].GetComponent<Collider2D>().enabled = false;
            smallmoney_10[i].SetActive(false);
            yield return null;
            smallmoney_5[i] = Instantiate(about_ui.Kindofsmallmoney[4], new Vector3(1000.0f, 1000.0f, 0.0f), Quaternion.identity);
            smallmoney_5[i].GetComponent<Collider2D>().enabled = false;
            smallmoney_5[i].SetActive(false);
            yield return null;
            smallmoney_1[i] = Instantiate(about_ui.Kindofsmallmoney[5], new Vector3(1000.0f, 1000.0f, 0.0f), Quaternion.identity);
            smallmoney_1[i].GetComponent<Collider2D>().enabled = false;
            smallmoney_1[i].SetActive(false);
            yield return null;
        }
    }

    protected void KindofMoney(float Amount)
    {
        if (Amount <= 0) return;
        if (Amount >= 220)
        {
            speed_state = State.Speed.TooFast;
        }
        else if (Amount >= 180)
        {
            speed_state = State.Speed.Fast;
        }
        else if (Amount >= 120)
        {
            speed_state = State.Speed.Soso;
        }
        else if (Amount >= 70)
        {
            speed_state = State.Speed.Slow;
        }
        else if (Amount <= 40)
        {
            speed_state = State.Speed.TooSlow;
        }
        switch (speed_state)
        {
            case State.Speed.TooFast:
                TOOFAST(Amount);
                break;
            case State.Speed.Fast:
                FAST(Amount);
                break;
            case State.Speed.Soso:
                SOSO(Amount);
                break;
            case State.Speed.Slow:
                SLOW(Amount);
                break;
            case State.Speed.TooSlow:
                TOOSLOW(Amount);
                break;
        }
    }
    void Money_500()
    {
        for (int i = 0; i < smallmoney_500.Length; i++)
        {
            if (!smallmoney_500[i].activeInHierarchy)
            {
                smallmoney_500[i].SetActive(true);
                smallmoney_500[i].GetComponent<Collider2D>().enabled = true;
                smallmoney_500[i].transform.position = Gama.transform.position - new Vector3(0.0f, -10.0f, 0.0f);
                return;
            }
        }
    }

    void Money_100()
    {
        for (int i = 0; i < smallmoney_100.Length; i++)
        {
            if (!smallmoney_100[i].activeInHierarchy)
            {
                smallmoney_100[i].SetActive(true);
                smallmoney_100[i].GetComponent<Collider2D>().enabled = true;
                smallmoney_100[i].transform.position = Gama.transform.position - new Vector3(0.0f, -10.0f, 0.0f);
                return;
            }
        }
    }

    void Money_50()
    {
        for (int i = 0; i < smallmoney_50.Length; i++)
        {
            if (!smallmoney_50[i].activeInHierarchy)
            {
                smallmoney_50[i].SetActive(true);
                smallmoney_50[i].GetComponent<Collider2D>().enabled = true;
                smallmoney_50[i].transform.position = Gama.transform.position - new Vector3(0.0f, -10.0f, 0.0f);
                return;
            }
        }
    }

    void Money_10()
    {
        for (int i = 0; i < smallmoney_10.Length; i++)
        {
            if (!smallmoney_10[i].activeInHierarchy)
            {
                smallmoney_10[i].SetActive(true);
                smallmoney_10[i].GetComponent<Collider2D>().enabled = true;
                smallmoney_10[i].transform.position = Gama.transform.position - new Vector3(0.0f, -10.0f, 0.0f);
                return;
            }
        }
    }

    void Money_5()
    {
        for (int i = 0; i < smallmoney_5.Length; i++)
        {
            if (!smallmoney_5[i].activeInHierarchy)
            {
                smallmoney_5[i].SetActive(true);
                smallmoney_5[i].GetComponent<Collider2D>().enabled = true;
                smallmoney_5[i].transform.position = Gama.transform.position - new Vector3(0.0f, -10.0f, 0.0f);
                return;
            }
        }
    }

    void Money_1()
    {
        for (int i = 0; i < smallmoney_1.Length; i++)
        {
            if (!smallmoney_1[i].activeInHierarchy)
            {
                smallmoney_1[i].SetActive(true);
                smallmoney_1[i].GetComponent<Collider2D>().enabled = true;
                smallmoney_1[i].transform.position = Gama.transform.position - new Vector3(0.0f, -10.0f, 0.0f);
                return;
            }
        }
    }

    void TOOFAST(float Amount)
    {
        if (Amount >= 380)
        {
            Money_500();
        }
        else if (Amount >= 370)
        {
            int rnd = Random.Range(0, 2);
            if (rnd == 0)
            {
                Money_500();
            }
            else
            {
                Money_100();
            }
        }
        else
        {
            Money_100();
        }
    }

    void FAST(float Amount)
    {
        if (Amount >= 120)
        {
            Money_100();
        }
        else if (Amount >= 100)
        {
            int rnd = Random.Range(0, 2);
            if (rnd == 0)
            {
                Money_100();
            }
            else
            {
                Money_50();
            }
        }
        else
        {
            Money_50();
        }
    }

    void SOSO(float Amount)
    {
        if (Amount >= 80)
        {
            Money_50();
        }
        else if (Amount >= 60)
        {
            int rnd = Random.Range(0, 2);
            if (rnd == 0)
            {
                Money_50();
            }
            else
            {
                Money_10();
            }
        }
        else
        {
            Money_10();
        }
    }

    void SLOW(float Amount)
    {
        if (Amount >= 55)
        {
            Money_10();
        }
        else if (Amount >= 50)
        {
            int rnd = Random.Range(0, 2);
            if (rnd == 0)
            {
                Money_10();
            }
            else
            {
                Money_5();
            }
        }
        else
        {
            Money_5();
        }
    }

    void TOOSLOW(float Amount)
    {
        if (Amount <= 40)
        {
            Money_5();
        }
        else if (Amount <= 30)
        {
            int rnd = Random.Range(0, 2);
            if (rnd == 0)
            {
                Money_5();
            }
            else
            {
                Money_1();
            }
        }
        else
        {
            Money_1();
        }
    }
}

