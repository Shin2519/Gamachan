using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Globalization;
using System.Collections;


public class SelectGoods : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI goodscount;//商品個数のテキスト
    [SerializeField] private TextMeshProUGUI[] pricetext;//商品単価のテキスト
    

    [SerializeField] public Image[] image;//商品画像
    [SerializeField] private GameObject ui;//ボタン表示用
    [SerializeField] private SelectGoodsSO select;
    private data[] currentgood = new data[6];
    [SerializeField] private TextMeshProUGUI targettext;//目標金額
    //public int target;

    int counta = 0;//選択個数
    bool max;
    public int sum;

    
    public int index = 0;
    List<int> imageindex = new List<int>();//イメージ用


    void Start()
    {
        ui.gameObject.SetActive(false);


        select.dataList[index].count = 0;
        select.total = 0;


        Price();

        //Goods(); 
        max = false;
        

    }
    private void Update()
    {
        goodscount.text = select.dataList[index].count.ToString();
        
        Total();
        //最大選択数6
        if(counta > 5)
        {
            max = true;
        }
        else
        {
            max = false;
        }
        counta = select.dataList.Sum(data=>data.count);
        
    }

    //商品価格.画像
    private void Price()
    {
        priceset();
        List<int> prices = select.dataList.Select(d=>d.price).ToList();

        List<int> total = new List<int>();

        int n = prices.Count;

        for(int m =1;m<(1<<n);m++)
        {
            int sum = 0;
            for(int i=0;i<n;i++)
            {
                if((m&(1<<i))!=0)
                {
                    sum += prices[i];
                }
            }
            total.Add(sum);
        }
        total = total.Distinct().ToList();


        select.target = total[Random.Range(0,total.Count)];
        targettext.text = select.target.ToString() + "円を目指せ!";

        var shuffled = select.dataList.OrderBy(a => Random.value).ToList();
        for(int i=0;i<6;i++)
        {
            currentgood[i] = shuffled[i];
            pricetext[i].text = shuffled[i].price + "円";
            image[i].sprite = shuffled[i].image;
        }

    }
    //商品の価格設定
    private void priceset()
    {
        //商品の価格
        select.dataList[0].price = Random.Range(3, 5);//袋
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
        foreach(var item in select.dataList)
        {
            total += item.price * item.count;
        }

        select.total = total;

    }
    //商品プラス
    public void OnPlusButton()
    {
        if(!max)
        {
            select.dataList[index].count += 1;
        } 
    }
    //商品マイナス
    public void OnMinusButton()
    {
        if (select.dataList[index].count > 0)
            select.dataList[index].count -= 1;
    }
    //プラスマイナスボタンの表示
    public void OnGoodsButton()
    {
        ui.gameObject.SetActive(true);

    }

    

}
