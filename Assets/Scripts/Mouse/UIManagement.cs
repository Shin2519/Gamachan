using UnityEngine;
using UnityEngine.UI;

public class UIManagement : MonoBehaviour
{
    public static UIManagement instance;
    [SerializeField, Header("ゲージイメージ")]
    private Image Gauge;
    [SerializeField]
    private Sprite Gold;
    [SerializeField]
    int Current = 0;
    int Min = 0;
    int Max = 100;

    public int Currentgauge {get{ return Current; }set { Current = Mathf.Clamp(value,Min,Max); } }
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
            float time = 10;
            while(time>0)
            {
                time -= Time.deltaTime;
                Currentgauge--;
            }
        }
        else
        {
            Gauge.fillAmount = Current / Max;
        }
    }

    public void gauge()
    {
        Currentgauge += 10;
    }
}
