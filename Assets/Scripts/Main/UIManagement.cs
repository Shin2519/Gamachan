using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManagement : MasterCode
{
    public static UIManagement uimanagement;
    [SerializeField, Header("ゲージイメージ")]
    private Image Gauge;
    Color color;
    float Current;

    public float Currentgauge { get { return Current; } set { Current = Mathf.Clamp(value, about_ui.Min, about_ui.Max); } }

    void Awake()
    {
        uimanagement = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gauge_state = State.Gauge.Normal;
        Gauge.fillAmount = Current / about_ui.Max;
        color = Gauge.color;
        Finish.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Current >=about_ui.Max)
        {
            gauge_state = State.Gauge.Gold;
            Gama_Image.sprite = about_ui.GoldenKindofemotion[0];
            StartCoroutine(GaugeDown());
            StartCoroutine(ColorChange());
        }
        else
        {
            Gauge.fillAmount = Current / about_ui.Max;
        }
    }
    IEnumerator ColorChange()
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
    IEnumerator GaugeDown()
    {
        isDown = true;

        while (Gauge.fillAmount > 0)
        {
            if (ResultPanel.activeSelf) break;
            yield return new WaitUntil(() => !Onpay);
            Currentgauge -= 1 * Time.deltaTime;
            yield return null;
        }
        gauge_state = State.Gauge.Normal;
        Gama_Image.sprite = about_ui.Kindofemotion[0];
        Gauge.color = color;
        isDown = false;
    }
    public void gauge()
    {
        if (!isDown)
        {
            Currentgauge += 5 * Time.deltaTime;
        }
    }
}
