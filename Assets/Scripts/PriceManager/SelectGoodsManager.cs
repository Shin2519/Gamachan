using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectGoodsManager : MonoBehaviour
{
    [SerializeField] private GameObject tachpanel;//シーン切り替え用
    [SerializeField] private SelectGoodsSO selectgoodsso;

    [SerializeField] float timer;//時間制限用
    [SerializeField] private TextMeshProUGUI timetext;//時間テキスト
    
    [SerializeField] SelectGoods so;

    int index;
    [SerializeField]private RectTransform button;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        tachpanel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        
        if (timer>=0)
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
       
        //if(selectgoodsso.total>selectgoodsso.target)
        //{
        //    StartCoroutine(Butto());
        //}
    }
    private void FixedUpdate()
    {
        timer -= Time.fixedDeltaTime;
    }

    public void OnPay()
    {
        if (selectgoodsso.target == selectgoodsso.total)
        {
            tachpanel.SetActive(true);
            this.gameObject.SetActive(false);
        }
        else if(selectgoodsso.total>selectgoodsso.target)
        {
            so.InitCounts();
            so.SetPrices();
            so.CreateDisplayGoods();
            so.UpdateUI();
        }
    }

    //IEnumerator Butto()
    //{
    //    for(int i=0;i<6;i++)
    //    {
    //        button.position = new Vector3(5,0,0);
    //        button.position = new Vector3(-5, 0, 0);
    //        yield return null;
    //    }
    //    so.priceset();
    //}
}
