using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManagement : MasterCode
{
    public static UIManagement instance;
    void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gauge_state = State.Gauge.Normal;
        Gauge.fillAmount = about_ui.Current / about_ui.Max;
        color = Gauge.color;
        Finish.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(about_ui.Current >=about_ui.Max)
        {
            gauge_state = State.Gauge.Gold;
            TouchPanel.Gama_Image.sprite = about_ui.GoldenKindofemotion[0];
            StartCoroutine(GaugeDown());
            StartCoroutine(ColorChange());
        }
        else
        {
            Gauge.fillAmount = about_ui.Current / about_ui.Max;
        }
    }
    public void gauge()
    {
        if(!isDown)
        {
            Currentgauge += 5 * Time.deltaTime;
        }
    }
    public void Finishistrue()
    {
        Finish.SetActive(true);
    }
}
