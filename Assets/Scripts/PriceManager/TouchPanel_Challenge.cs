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
        if (Gama_Image == null)
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

    private void Update()
    {
        
    }
    public void OnButton()
    {
        if (Onpay) return;
        StartCoroutine(kaikei());
        AudioManager.Instance.seSource.PlayOneShot(sound.Buttondown);
    }
    protected  IEnumerator kaikei()
    {
        Onpay = true;

        sumamounttext.text = ProbabilityManager.TotalMoney(ProbabilityManager.coin).ToString() + "â~";

        sumamountyen.enabled = true;
        sumamounttext.enabled = true;

        if (sumamount >= 0)
        {
            combo++;
            sumamountyen.text = "Ç®íﬁÇË";
            sumamounttext.color = Color.red;
            Data.total_Data.Total_Change_Amount += sumamount;

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
        //Destroy(hyouka);
        //Destroy(comboobject);
        rndyentext();
        Onpay = false;
    }
}
