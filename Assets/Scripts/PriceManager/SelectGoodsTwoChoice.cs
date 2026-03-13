using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectGoodsTwoChoice: MasterCode
{
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI[] priceTextsLeft;//各商品の値段
    [SerializeField] private TextMeshProUGUI[] priceTextsRight;//各商品の値段

    [SerializeField] private Image[] imagesLeft;//左側の商品の画像
    [SerializeField] private Image[] imagesRight;//右側の商品の画像

    [SerializeField] private TextMeshProUGUI targetText;//目標金額


    [SerializeField] private SelectGoodsSO selectSO;

    [SerializeField] GameObject thispanel;//商品選択画面

    public static SelectGoods selectGoods;
    // 表示＆操作対象の商品
    private List<data> displayData = new();
    [Header("リセットボタンの再表示時間")] public float cooltime;
    [SerializeField] private GameObject tly;
    [SerializeField] private GameObject reset;
    [SerializeField] private GameObject gametext;
    [SerializeField,Header("0左,1右")] private Image[] jageImage;//0左,1右
    [SerializeField,Header("0〇,1×")] private Sprite[] jageSprit;//0〇,1×
    bool Onleft;
    bool Onright;


    void Start()
    {
        InitCounts();
    }

    // 初期化
    public void InitCounts()
    {
        jageImage[0].enabled = false;
        jageImage[1].enabled = false;
        selectSO.total = 0;
        Gama.SetActive(false);
        tly.SetActive(false);
        gametext.SetActive(false);
    }


    private void OnEnable()
    {
        InitCounts();
    }
}
