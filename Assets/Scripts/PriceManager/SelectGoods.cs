using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;


public class SelectGoods : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goodscount;//商品個数のテキスト
    [SerializeField] private TextMeshProUGUI[] pricetext;//商品単価のテキスト
    [SerializeField] public Image[] image;//商品画像
    [SerializeField] private GameObject ui;//ボタン表示用
    [SerializeField] private SelectGoodsSO select;
    [SerializeField] private TextMeshProUGUI targettext;//目標金額

    int counta = 0;//選択個数
    bool max;

    public int index = 0;

    List<data> selectdata;

    [SerializeField] private TextMeshProUGUI sa;
    void Start()
    {
        ui.gameObject.SetActive(false);
        select.dataList[index].count = 0;
        select.total = 0;
        select.target = 0;
        priceset();
        Price();
        max = false;
    }
    void Update()
    {
        Total();
        counta = select.dataList.Sum(data => data.count);
        //最大選択数6
        if (counta > 5)
        {
            max = true;
        }
        else
        {
            max = false;
        }
        goodscount.text = select.dataList[index].count.ToString();
    }
    //商品価格.画像
    public void Price()
    {
        List<data> temp = new List<data>(select.dataList);
        //目標金額の作成
        for (int i = 0; i < temp.Count; i++)
        {
            int rand = Random.Range(i, temp.Count);
            (temp[i], temp[rand]) = (temp[rand], temp[i]);
        }
        selectdata = temp.GetRange(0, 6);
        for (int i = 0; i < 6; i++)
        {
            pricetext[i].text = selectdata[i].price.ToString() + "円";
            image[i].sprite = selectdata[i].image;
        }
        select.target = selectdata.Sum(d => d.price);
        targettext.text = select.target.ToString() + "を目指せ!";
    }

    //商品の価格設定
    public void priceset()
    {
        //商品の価格
        select.dataList[0].price = Random.Range(3, 7) * 1;//袋 3,5,7
        select.dataList[1].price = Random.Range(10, 20) * 10;//パン
        select.dataList[2].price = Random.Range(10, 25) * 10;//おにぎり
        select.dataList[3].price = Random.Range(20, 35) * 10;//サンドイッチ
        select.dataList[4].price = Random.Range(40, 60) * 10;//お弁当
        select.dataList[5].price = Random.Range(15, 25) * 10;//チキン
        select.dataList[6].price = Random.Range(8, 11) * 10;//お茶
        select.dataList[7].price = Random.Range(11, 16) * 10;//ポテトチップス
        select.dataList[8].price = Random.Range(8, 15) * 10;//アイスクリーム
        select.dataList[9].price = Random.Range(15, 32) * 10;//ラーメン
    }

    //合計金額
    private void Total()
    {
        int total = 0;
        foreach (var item in select.dataList)
        {
            total += item.price * item.count;
        }
        select.total = total;
        sa.text = select.total.ToString();
    }
    //商品プラス
    public void OnPlusButton()
    {
        if (!max)
        {
            select.dataList[index].count ++;
        }
    }
    //商品マイナス
    public void OnMinusButton()
    {
        if (select.dataList[index].count > 0)
            select.dataList[index].count --;
    }
    //プラスマイナスボタンの表示
    public void OnGoodsButton()
    {
        ui.gameObject.SetActive(true);

    }
}
