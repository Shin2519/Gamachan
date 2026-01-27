using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManagement : MonoBehaviour
{
    public static UIManagement instance;
    [SerializeField]
    private UI Gama_State;
    [SerializeField]
    private Somethings_State Gauge_State;
    [SerializeField, Header("ゲージイメージ")]
    private Image Gauge;
    [SerializeField]
    float Current = 0;
    int Min = 0;
    int Max = 100;
    Color gauge_color;
    Color color;

    [Header("Finish")]
    public GameObject Finish;

    bool isDown = false;
    public float Currentgauge {get{ return Current; }set { Current = Mathf.Clamp(value,Min,Max); } }
    void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Gauge_State.gauge_state = Somethings_State.Gauge_State.Normal;
        Gauge.fillAmount = Current / Max;
        color = Gauge.color;
        Finish.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Current>=Max)
        {
            Gauge_State.gauge_state = Somethings_State.Gauge_State.Gold;
            TouchPanel.Gama_Image.sprite = Gama_State.GoldenKindofemotion[0];
            StartCoroutine(GaugeDoun());
            StartCoroutine(ColorChange());
        }
        else
        {
            Gauge.fillAmount = Current / Max;
        }
    }
    public void gauge()
    {
        if(!isDown)
        {
            Currentgauge += 10 * Time.deltaTime;
        }
    }
        

    private IEnumerator GaugeDoun()
    {
        isDown = true;
        while(Gauge.fillAmount > 0)
        {
            Currentgauge -= 10 * Time.deltaTime;
            yield return null;
        }
        Gauge_State.gauge_state = Somethings_State.Gauge_State.Normal;
        TouchPanel.Gama_Image.sprite = Gama_State.Kindofemotion[0];
        Gauge.color = color;
        isDown = false;
    }

    private IEnumerator ColorChange()
    {
        while (Gauge.fillAmount > 0)
        {
            gauge_color = Gauge.color;
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
    public void Finishistrue()
    {
        Finish.SetActive(true);
    }
}
