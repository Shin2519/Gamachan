using TMPro;
using UnityEngine;

public class SelectGoodsManager : MonoBehaviour
{
    [SerializeField] private GameObject tachpanel;//シーン切り替え用
    [SerializeField] private SelectGoodsSO selectgoodsso;

    [SerializeField] float timer;//時間制限用
    [SerializeField] private TextMeshProUGUI timetext;//時間テキスト

    [SerializeField]private TextMeshProUGUI targettext;//目標金額
    private int target;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tachpanel.SetActive(false);
        target = Random.Range(500, 1000);
    }

    // Update is called once per frame
    void Update()
    {
        targettext.text = target.ToString()+"円を目指せ!";

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

        if(timer<=0)
        {
            Debug.Log("gameover");
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
