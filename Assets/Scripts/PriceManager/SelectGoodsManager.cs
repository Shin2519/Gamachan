using TMPro;
using UnityEngine;

public class SelectGoodsManager : MonoBehaviour
{
    [SerializeField] private GameObject tachpanel;
    [SerializeField] private SelectGoodsSO selectgoodsso;
    [SerializeField] float timer;
    [SerializeField] private TextMeshProUGUI timetext;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tachpanel.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer>=0)
        timetext.text = "TIME:" + timer.ToString("F0");

        if(10< timer && timer<30)
        {
            timetext.color = new Color32(255, 128, 0, 255);
        }
        else if(timer<10)
        {
            timetext.color = new Color32(255, 0, 0, 255);
        }
       
    }
    private void FixedUpdate()
    {
        timer -= Time.fixedDeltaTime;
    }

    public void OnPay()
    {
        tachpanel.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
