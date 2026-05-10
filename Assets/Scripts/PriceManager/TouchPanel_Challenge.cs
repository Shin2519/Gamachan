using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TouchPanel_Challenge : Register
{
    ChallengeScoreResult CS;
    [SerializeField] private GameObject cover;
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
        cover.SetActive(false);
    }
    void Update()
    {
        
    }
    public void OnButton()
    {
        cover.SetActive(true);
        if (Onpay) return;
        StartCoroutine(kaikei());
        AudioManager.Instance.seSource.PlayOneShot(sound.Buttondown);
    }
    protected override IEnumerator kaikei()
    {
        Onpay = true;
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
        cover.SetActive(false);
    }
}
