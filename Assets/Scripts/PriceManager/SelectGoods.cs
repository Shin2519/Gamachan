using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectGoods : MonoBehaviour
{
    private  int displaycount;//最大表示
    private  int max = 6;//最大選択個数

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI[] countTexts;//各商品の個数
    [SerializeField] private TextMeshProUGUI[] priceTexts;//各商品の値段
    [SerializeField] private Image[] images;//商品の画像
    //[SerializeField] private GameObject[] plusMinusUI;//各商品の+-ボタンの表示、非表示
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


    //[SerializeField]private Slider slider;
    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        startpos = rect.anchoredPosition;
    }
    void Start()
    {
        displaycount = 6;
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

        //foreach (var ui in plusMinusUI)
        //    ui.SetActive(false);

        //displaycount = 6;

        
        gamachan.SetActive(false);
        tly.SetActive(false);
        gametext.SetActive(false);
    }

    // 商品価格設定
    public void SetPrices()
    {
        int[] fukuro = { 30, 50, 70 };
        selectSO.dataList[0].price = fukuro[Random.Range(0,fukuro.Length)];// 袋
        int[] pan = { 2000, 2600, 3400 };
        selectSO.dataList[1].price = pan[Random.Range(0, pan.Length) ]; // パン
        int[] onigiri = { 2700, 3380, 4420 };
        selectSO.dataList[2].price = onigiri[Random.Range(0, onigiri.Length)]   ; // おにぎり
        int[] sand = { 4100, 5300, 6900 };
        selectSO.dataList[3].price = sand[Random.Range(0, sand.Length)]; // サンド
        int[] bentou = { 7100, 9230, 12070 };
        selectSO.dataList[4].price = bentou[Random.Range(0, bentou.Length)]; // 弁当
        int[] chikin = { 6000, 7800, 10200 };
        selectSO.dataList[5].price = chikin[Random.Range(0, chikin.Length)]; // チキン
        int[] ocha = { 700, 910, 1190 };
        selectSO.dataList[6].price = ocha[Random.Range(0, ocha.Length)];  // お茶
        int[] poteti = { 1600, 2080, 2720 };
        selectSO.dataList[7].price = poteti[Random.Range(0, poteti.Length)]; // ポテチ
        int[] ice = { 1100, 1430, 1870 };
        selectSO.dataList[8].price = ice[Random.Range(0, ice.Length)];  // アイス
        int[] ramen = { 3100, 4030, 5270 };
        selectSO.dataList[9].price = ramen[Random.Range(0, ramen.Length)]; // ラーメン
    }

    // 表示する6商品を決定
    public void CreateDisplayGoods()
    {
        for (int i = 0; i < images.Length; i++)
        {
            images[i].gameObject.SetActive(false);
            priceTexts[i].gameObject.SetActive(false);
            countTexts[i].gameObject.SetActive(false);
        }
        displayData = selectSO.dataList
            .OrderBy(_ => Random.value)
            .Take(displaycount)
            .ToList();

        for (int i = 0; i < displaycount; i++)
        {
            images[i].gameObject.SetActive(true);
            priceTexts[i].gameObject.SetActive(true);
            countTexts[i].gameObject.SetActive(true);
            priceTexts[i].text = displayData[i].price + "円";
            images[i].sprite = displayData[i].image;
        }
        int usecount = 3;

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
        //plusMinusUI[index].SetActive(true);
        displayData[index].count++;
        Recalculate();
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
            Register.register.rndyentext();
            gamachan.SetActive(true);
            tly.SetActive(true);
            gametext.SetActive(true);

        }
        else if (selectSO.total > selectSO.target)
        {
            //StartCoroutine(PayOver());
            thispanel.gameObject.SetActive(false);
            Register.register.rndyentext();
            gamachan.SetActive(true);
            tly.SetActive(true);
            gametext.SetActive(true);
        }
        else if (selectSO.total < selectSO.target)
        {
            thispanel.gameObject.SetActive(false);
            Register.register.rndyentext();
            gamachan.SetActive(true);
            tly.SetActive(true);
            gametext.SetActive(true);
        }
    }
    private void OnEnable()
    {
        displaycount = 6;

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
        if (displaycount <= 3)
            yield break;
            displaycount--;
        reset.SetActive(false);
        InitCounts();
        SetPrices();
        CreateDisplayGoods();
        UpdateUI();
        //slider.value = 1;
        yield return new WaitForSeconds(cooltime);
        //slider.value = 0;
        
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
