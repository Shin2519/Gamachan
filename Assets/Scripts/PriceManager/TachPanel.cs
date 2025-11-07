using TMPro;
using UnityEngine;

public class TachPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI sumamounttext;//合計金額テキスト(円)
    [SerializeField] private TextMeshProUGUI sumamountyen;//合計金額テキスト
    [SerializeField] private TextMeshProUGUI amounttext;//商品の金額テキスト
    [SerializeField] private TextMeshProUGUI inputamounttext;//投入金額(仮)テキスト

    [SerializeField] private SelectGoodsManager selectGoods;
    private int sumamount = 0;
    //private int amount = 100;
    private int inputamount = 50;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sumamounttext.text = sumamount.ToString() + "円";
        amounttext.text = selectGoods.total.ToString() + "円";
        inputamounttext.text = inputamount.ToString() + "円";

        sumamounttext.enabled = false;
        sumamountyen.enabled = false;
    }


    public void OnButton()
    {
        sumamount = selectGoods.total - inputamount;
        sumamounttext.enabled = true;
        sumamountyen.enabled = true;

        if (sumamount <0)
        {
            sumamountyen.text = "お釣り";
            sumamounttext.text =  sumamount.ToString() + "円";
            sumamounttext.color = Color.blue;
        }
        else
        {
            sumamountyen.text = "支払残額";
            sumamounttext.text = sumamount.ToString() + "円";
            sumamounttext.color = Color.red;
        }

    }
}
