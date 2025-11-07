using UnityEngine;
using UnityEngine.UI;

public class UIManagement : MonoBehaviour
{
    enum STATE
    {
        Normal,
        Gold
    }
    [SerializeField]
    private STATE state;
    public static UIManagement instance;
    [SerializeField, Header("ゲージイメージ")]
    private Image Gauge;
    [SerializeField]
    private Sprite Gold;
    [SerializeField]
    float Current = 0;
    int Min = 0;
    int Max = 100;

    public float Currentgauge {get{ return Current; }set { Current = Mathf.Clamp(value,Min,Max); } }
    void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Gauge.fillAmount = Current / Max;
    }

    // Update is called once per frame
    void Update()
    {
        if(Current>=Max)
        {
            state = STATE.Gold;
            float time = 10;
            if(time>0)
            {
                time -= Time.deltaTime;
                Currentgauge--;
            }
        }
        else
        {
            state = STATE.Normal;
            Gauge.fillAmount = Current / Max;
        }
    }
    public void gauge()
    {
        Currentgauge += 10 * Time.deltaTime;
    }
}
