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
    
}

