using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class SelectGoods : MonoBehaviour
{
    private  int displaycount = 6;//最大表示
    private  int max = 6;//最大選択個数

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI[] countTexts;//各商品の個数
    [SerializeField] private TextMeshProUGUI[] priceTexts;//各商品の値段
    [SerializeField] private Image[] images;//商品の画像
    [SerializeField] private GameObject[] plusMinusUI;//各商品の+-ボタンの表示、非表示
    [SerializeField] private TextMeshProUGUI totalText;//現在の金額
    [SerializeField] private TextMeshProUGUI targetText;//目標金額

    [SerializeField] private SelectGoodsSO selectSO;

    // 表示＆操作対象の商品
    private List<data> displayData = new();

    void Start()
    {
        InitCounts();
        SetPrices();
        CreateDisplayGoods();
        UpdateUI();
    }

    // 初期化
    public void InitCounts()
    {
        foreach (var d in selectSO.dataList)
            d.count = 0;

        foreach (var ui in plusMinusUI)
            ui.SetActive(false);

        selectSO.total = 0;
        selectSO.target = 0;
    }

    // 商品価格設定
    public void SetPrices()
    {
        selectSO.dataList[0].price = Random.Range(3, 6);         // 袋
        selectSO.dataList[1].price = Random.Range(10, 20) * 10; // パン
        selectSO.dataList[2].price = Random.Range(10, 25) * 10; // おにぎり
        selectSO.dataList[3].price = Random.Range(20, 35) * 10; // サンド
        selectSO.dataList[4].price = Random.Range(40, 60) * 10; // 弁当
        selectSO.dataList[5].price = Random.Range(15, 25) * 10; // チキン
        selectSO.dataList[6].price = Random.Range(8, 11) * 10;  // お茶
        selectSO.dataList[7].price = Random.Range(11, 16) * 10; // ポテチ
        selectSO.dataList[8].price = Random.Range(8, 15) * 10;  // アイス
        selectSO.dataList[9].price = Random.Range(15, 32) * 10; // ラーメン
    }

    // 表示する6商品を決定
    public void CreateDisplayGoods()
    {
        displayData = selectSO.dataList
            .OrderBy(_ => Random.value)
            .Take(displaycount)
            .ToList();

        for (int i = 0; i < displaycount; i++)
        {
            priceTexts[i].text = displayData[i].price + "円";
            images[i].sprite = displayData[i].image;
        }

        int usecount = Random.Range(2,6);
        var targetgoods = displayData
            .OrderBy(_ => Random.value)
            .Take(usecount);

        selectSO.target = targetgoods.Sum(d => d.price);
        targetText.text = selectSO.target + " 円を目指せ";
    }

    // ＋ボタン
    public void OnPlusButton(int index)
    {
        if (GetTotalCount() >= max) return;

        displayData[index].count++;
        Recalculate();
    }

    // −ボタン
    public void OnMinusButton(int index)
    {
        if (displayData[index].count <= 0) return;

        displayData[index].count--;
        Recalculate();
    }

    // 商品選択時（±表示）
    public void OnGoodsButton(int index)
    {
        plusMinusUI[index].SetActive(true);
    }

    // 再計算
    private void Recalculate()
    {
        selectSO.total = displayData.Sum(d => d.price * d.count);
        UpdateUI();
    }

    // UI更新
    public void UpdateUI()
    {
        for (int i = 0; i < displaycount; i++)
        {
            countTexts[i].text = displayData[i].count.ToString();
        }

        totalText.text = selectSO.total.ToString();
    }

    // 合計
    private int GetTotalCount()
    {
        return displayData.Sum(d => d.count);
    }
}
