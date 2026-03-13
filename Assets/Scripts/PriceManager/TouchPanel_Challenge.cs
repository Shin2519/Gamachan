using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TouchPanel_Challenge : Register
{
    ChallengeScoreResult CS;
    void Awake()
    {
        if(Gama_Image==null)
        {
            Gama_Image = Gama.GetComponent<Image>();
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        combo = 0;
        rndyentext();
        ResultPanel.SetActive(false);
        ResultManager.Instance.SetScores(CS.ToArray());
    }
    void Update()
    {
        inputamounttext.text = inputamount.ToString() + "â~";
    }
    public void OnButton()
    {
        if (Onpay) return;
        StartCoroutine(kaikei());
        AudioManager.Instance.seSource.PlayOneShot(sound.Buttondown);
    }
    protected override IEnumerator kaikei()
    {
        Onpay = true;
        gametext.SetActive(false);
        sumamount = inputamount - selectgoodsso.total;
        sumamounttext.enabled = true;
        sumamountyen.enabled = true;

        sumamounttext.text = sumamount.ToString() + "â~";

        if (sumamount >= 0)
        {
            //float SentTimer = Timer.Instance.timer;
            combo++;
            sumamountyen.text = "Ç®íﬁÇË";
            sumamounttext.color = Color.red;
            Data.total_Data.Total_Change_Amount += sumamount;

            //if(SentTimer==15)
            //{
            //    if (selectgoodsso.judgement)
            //    {
            //        Data.total_Data.Speed_Bonus15 += 1*2;
            //    }
            //    else
            //    {
            //        Data.total_Data.Speed_Bonus15 += 1;
            //    }
                    
            //}
            //else if(SentTimer == 20)
            //{
            //    if (selectgoodsso.judgement)
            //    {
            //        Data.total_Data.Speed_Bonus20 += 1*2;
            //    }
            //    else
            //    {
            //        Data.total_Data.Speed_Bonus20 += 1;
            //    }
                
            //}
        }
        else
        {
            combo = 0;
            sumamountyen.text = "éxï•écäz";
            sumamounttext.color = Color.blue;
        }
        yield return new WaitForSeconds(2.0f);

        GRADE.Instance.GRADE_(sumamount);

        yield return new WaitForSeconds(2.0f);
        selectgoods.SetActive(true);
        Destroy(hyouka);
        Destroy(comboobject);
        rndyentext();
        Onpay = false;
    }
}
