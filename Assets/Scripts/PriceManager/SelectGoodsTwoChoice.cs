using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectGoodsTwoChoice: MonoBehaviour
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

    [SerializeField] private GameObject gamachan;
    [SerializeField] private GameObject tly;
    [SerializeField] private GameObject reset;
    [SerializeField] private GameObject gametext;
    [SerializeField,Header("0左,1右")] private Image[] jageImage;//0左,1右
    [SerializeField,Header("0〇,1×")] private Sprite[] jageSprit;//0〇,1×
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip circle;
    [SerializeField] private AudioClip cross;

    
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        InitCounts();
        SetPrices();
        CreateDisplayGoodsLeft();
        CreateDisplayGoodsRight();
        SetTargetText();
    }

    // 初期化
    public void InitCounts()
    {
        jageImage[0].enabled=false;
        jageImage[1].enabled = false;
        selectSO.total = 0;
        selectSO.targetLeft = 0;
        selectSO.targetRight = 0;
        gamachan.SetActive(false);
        tly.SetActive(false);
        gametext.SetActive(false);
    }

    // 商品価格設定
    public void SetPrices()
    {
        int[] fukuro = { 30, 50, 70 };
        selectSO.dataList[0].price = fukuro[Random.Range(0, fukuro.Length)];// 袋
        int[] pan = { 2000, 2600, 3400 };
        selectSO.dataList[1].price = pan[Random.Range(0, pan.Length)]; // パン
        int[] onigiri = { 2700, 3380, 4420 };
        selectSO.dataList[2].price = onigiri[Random.Range(0, onigiri.Length)]; // おにぎり
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

    // 左側の商品
    public void CreateDisplayGoodsLeft()
    {
        displayData = selectSO.dataList
            .OrderBy(_ => Random.value)
            .Take(4)
            .ToList();

        for (int i = 0; i < 4; i++)
        {
            priceTextsLeft[i].text = displayData[i].price + "円";
            imagesLeft[i].sprite = displayData[i].image;
        }

        selectSO.targetLeft = displayData.Sum(d => d.price);
    }
    // 右側の商品
    public void CreateDisplayGoodsRight()
    {
        displayData = selectSO.dataList
           .OrderBy(_ => Random.value)
           .Take(4)
           .ToList();

        for (int i = 0; i < 4; i++)
        {
            priceTextsRight[i].text = displayData[i].price + "円";
            imagesRight[i].sprite = displayData[i].image;
        }

        selectSO.targetRight = displayData.Sum(d => d.price);
    }
    //目標金額
    public void SetTargetText()
    {
        int[] target = { selectSO.targetLeft, selectSO.targetRight };
        selectSO.total = target[Random.Range(0, target.Length)];
        targetText.text=selectSO.total.ToString() + "円はどっち？";
    }
    //左側の商品の正誤判定(成功時のスコア加算の追加予定)
    public void PayLeft()
    {
        StartCoroutine(PayJageLeft());
    }
    //右側の商品の正誤判定(成功時のスコア加算の追加予定)
    public void PayRight()
    {
        StartCoroutine (PayJageRight());
    }
    IEnumerator PayJageLeft()
    {
        if (selectSO.targetLeft == selectSO.total)
        {
            selectSO.judgement = true;
            audioSource.PlayOneShot(circle);
            jageImage[0].enabled = true;
            jageImage[0].sprite = jageSprit[0];
            
            
            yield return new WaitForSeconds(1.5f);
            
            thispanel.gameObject.SetActive(false);
            TouchPanel.instance.rndyentext();
            gamachan.SetActive(true);
            tly.SetActive(true);
            gametext.SetActive(true);
        }
        else
        {
            selectSO.judgement = false;
            audioSource.PlayOneShot(cross);
            jageImage[0].enabled = true;
            jageImage[0].sprite = jageSprit[1];
            

            yield return new WaitForSeconds(1.5f);

            gametext.SetActive(true);
            thispanel.gameObject.SetActive(false);
            TouchPanel.instance.rndyentext();
            gamachan.SetActive(true);
            tly.SetActive(true);
        }
    }

    IEnumerator PayJageRight()
    {
        if (selectSO.targetRight == selectSO.total)
        {
            selectSO.judgement = true;
            audioSource.PlayOneShot(circle);
            jageImage[1].enabled = true;
            jageImage[1].sprite = jageSprit[0];
           

            yield return new WaitForSeconds(1.5f);
            
            thispanel.gameObject.SetActive(false);
            TouchPanel.instance.rndyentext();
            gamachan.SetActive(true);
            tly.SetActive(true);
            gametext.SetActive(true);
        }
        else
        {
            selectSO.judgement = false;
            audioSource.PlayOneShot(cross);
            jageImage[1].enabled = true;
            jageImage[1].sprite = jageSprit[1];
            
            
            yield return new WaitForSeconds(1.5f);
            
            thispanel.gameObject.SetActive(false);
            TouchPanel.instance.rndyentext();
            gamachan.SetActive(true);
            tly.SetActive(true);
            gametext.SetActive(true);
        }
    }


    private void OnEnable()
    {
        InitCounts();
        SetPrices();
        CreateDisplayGoodsLeft();
        CreateDisplayGoodsRight();
        SetTargetText();
    }
    public void OnReset()
    {
        StartCoroutine(ResetGoods());
    }
    //リセットボタン
    IEnumerator ResetGoods()
    {
        InitCounts();
        SetPrices();
        CreateDisplayGoodsLeft();
        CreateDisplayGoodsRight();
        SetTargetText();
        yield return new WaitForSeconds(cooltime);
        reset.SetActive(true);
    }
}
