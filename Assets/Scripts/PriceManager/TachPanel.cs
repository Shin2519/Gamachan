using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class TachPanel : MonoBehaviour
{
    [SerializeField,Header("目標金額")] private TextMeshProUGUI amounttext;//商品の金額テキスト
    [SerializeField,Header("投入金額")] private TextMeshProUGUI inputamounttext;//投入金額(仮)テキスト
    [SerializeField,Header("合計金額")] private TextMeshProUGUI sumamounttext;//合計金額テキスト(円)
 
    // 合計金額が+か-で表示するテキストが変わるため
    [SerializeField] private TextMeshProUGUI sumamountyen;//合計金額テキスト(お釣り、支払残額)
    [SerializeField] SelectGoodsSO selectgoodsso;
    private int index = 0;
    private int inputamount = 500;
    private float sumamount;//合計金額


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //目標金額
        amounttext.text = selectgoodsso.dataList[index].total.ToString() + "円";
        //投入金額
        inputamounttext.text = inputamount.ToString() + "円";
        //合計金額
        sumamounttext.text = sumamount.ToString() + "円";


        sumamounttext.enabled = false;
        sumamountyen.enabled = false;
    }


    public void OnButton()
    {
        sumamount = selectgoodsso.dataList[index].total - inputamount;
        sumamounttext.enabled = true;
        sumamountyen.enabled = true;

        if (sumamount < 0)
        {
            sumamountyen.text = "お釣り";
            sumamounttext.text = Mathf.Abs(sumamount).ToString() + "円";
            sumamounttext.color = Color.blue;
        }
        else
        {
            sumamountyen.text = "支払残額";
            sumamounttext.text = "-"+ sumamount.ToString() + "円";
            sumamounttext.color = Color.red;
        }

    }
}
