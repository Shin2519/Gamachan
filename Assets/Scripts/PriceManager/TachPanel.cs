using TMPro;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class TachPanel : MonoBehaviour
{
    public static TachPanel instance;
    [SerializeField,Header("–Ú•W‹àŠz")] private TextMeshProUGUI amounttext;//¤•i‚Ì‹àŠzƒeƒLƒXƒg
    [SerializeField,Header("“Š“ü‹àŠz")] private TextMeshProUGUI inputamounttext;//“Š“ü‹àŠz(‰¼)ƒeƒLƒXƒg
    [SerializeField,Header("‡Œv‹àŠz")] private TextMeshProUGUI sumamounttext;//‡Œv‹àŠzƒeƒLƒXƒg(‰~)
 
    // ‡Œv‹àŠz‚ª+‚©-‚Å•\¦‚·‚éƒeƒLƒXƒg‚ª•Ï‚í‚é‚½‚ß
    [SerializeField] private TextMeshProUGUI sumamountyen;//‡Œv‹àŠzƒeƒLƒXƒg(‚¨’Ş‚èAx•¥cŠz)
    [SerializeField] SelectGoodsSO selectgoodsso;
    private int index = 0;
    private int inputamount;
    private float sumamount;//‡Œv‹àŠz
    [SerializeField] SelectGoods selectgoods;
    [SerializeField] private Image[] image;

    void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //–Ú•W‹àŠz
        amounttext.text = selectgoodsso.dataList[index].total.ToString() + "‰~";
        //“Š“ü‹àŠz
        inputamounttext.text = inputamount.ToString() + "‰~";
        //‡Œv‹àŠz
        sumamounttext.text = sumamount.ToString() + "‰~";


        sumamounttext.enabled = false;
        sumamountyen.enabled = false;
    }
    void Update()
    {
        
    }
    public void OnButton()
    {
        sumamount = selectgoodsso.dataList[index].total - inputamount;
        sumamounttext.enabled = true;
        sumamountyen.enabled = true;

        if (sumamount < 0)
        {
            sumamountyen.text = "‚¨’Ş‚è";
            sumamounttext.text = Mathf.Abs(sumamount).ToString() + "‰~";
            sumamounttext.color = Color.blue;
        }
        else
        {
            sumamountyen.text = "x•¥cŠz";
            sumamounttext.text = "-"+ sumamount.ToString() + "‰~";
            sumamounttext.color = Color.red;
        }
    }
}
