using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class SelectGoodsManager : MonoBehaviour
{
    [SerializeField] float timer;//時間制限用
    [SerializeField] private TextMeshProUGUI timetext;//時間テキスト

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
      
    }
    private void FixedUpdate()
    {
        timer -= Time.fixedDeltaTime;
    }

    
}
