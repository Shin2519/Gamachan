using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField] GameObject thispanel;//商品選択画面

    public static SelectGoods selectGoods;
    // 表示＆操作対象の商品
    private List<data> displayData = new();

    [SerializeField] RectTransform rect;
    Vector2 startpos;
    [SerializeField,Header("振動継続時間")] float time;
    [SerializeField,Header("振動強さ")] float power;
    [Header("デバッグ")] public bool debug;
    [Header("リセットボタンの再表示時間")] public float cooltime;

    [SerializeField] private GameObject gamachan;
    [SerializeField] private GameObject tly;
    [SerializeField] private GameObject reset;
    [SerializeField] private GameObject gametext;



    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        startpos = rect.anchoredPosition;
    }
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
        gamachan.SetActive(false);
        tly.SetActive(false);
        gametext.SetActive(false);

    }

    // 商品価格設定
    public void SetPrices()
    {
        int[] numer = { 3, 5, 7 };
        selectSO.dataList[0].price = numer[Random.Range(0,numer.Length)]*10;// 袋
        selectSO.dataList[1].price = Random.Range(10, 20) * 100; // パン
        selectSO.dataList[2].price = Random.Range(10, 25) * 100; // おにぎり
        selectSO.dataList[3].price = Random.Range(20, 35) * 100; // サンド
        selectSO.dataList[4].price = Random.Range(40, 60) * 100; // 弁当
        selectSO.dataList[5].price = Random.Range(15, 25) * 100; // チキン
        selectSO.dataList[6].price = Random.Range(8, 11) * 100;  // お茶
        selectSO.dataList[7].price = Random.Range(11, 16) * 100; // ポテチ
        selectSO.dataList[8].price = Random.Range(8, 15) * 100;  // アイス
        selectSO.dataList[9].price = Random.Range(15, 32) * 100; // ラーメン
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

    public void OnPay()
    {
        if (selectSO.target == selectSO.total||debug)
        {
            thispanel.gameObject.SetActive(false);
            TouchPanel.instance.rndyentext();
            gamachan.SetActive(true);
            tly.SetActive(true);
            gametext.SetActive(true);

        }
        else if (selectSO.total > selectSO.target)
        {
            StartCoroutine(PayOver());
        }
    }
    private void OnEnable()
    {
        InitCounts();
        SetPrices();
        CreateDisplayGoods();
        UpdateUI();
    }
    public void OnReset()
    {
        StartCoroutine(ResetGoods());
    }
    IEnumerator ResetGoods()
    {
        reset.SetActive(false);
        InitCounts();
        SetPrices();
        CreateDisplayGoods();
        UpdateUI();
        yield return new WaitForSeconds(cooltime);
        reset.SetActive(true);

    }
    IEnumerator PayOver()
    {
        yield return StartCoroutine(vibration());

        yield return new WaitForSeconds(0.5f);

        InitCounts();
        SetPrices();
        CreateDisplayGoods();
        UpdateUI();
    }

    IEnumerator vibration()
    {
        float timer = 0;
        while (timer < time)
        {
            float x = Mathf.Sin(timer * 60f) * power;
            float y = Mathf.Sin(timer * 60f) * power;

            rect.anchoredPosition = startpos + new Vector2(x, y);

            timer += Time.deltaTime;
            yield return null;
        }

        rect.anchoredPosition = startpos;

    }
}
