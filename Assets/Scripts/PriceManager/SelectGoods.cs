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


    void Start()
    {
        priceset();

        ui.gameObject.SetActive(false);


        select.dataList[index].count = 0;
        select.total = 0;


        Price();
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
        int usecount = Random.Range(2, 6);

        List<int> ans = new List<int>();
        int sum = 0;

        List<int> registered = select.dataList.Select(x=>x.price).ToList();

        while(true)
        {
            for (int i = 0; i < usecount - 1; i++)
            {
                int v = registered[Random.Range(0, registered.Count)];
                ans.Add(v);
                sum += v;
            }

            int last = select.target - sum;
            if (last <= 0 || !registered.Contains(last))
            {
                Price();
                break;
            }
            ans.Add(last);
        }
        

        List<int> temp = new List<int>(ans);

        while (temp.Count < 6)
        {
            int dummy = registered[Random.Range(0,registered.Count)];

            if (dummy == select.target || ans.Contains(dummy))
            {
                continue;
            }
            temp.Add(dummy);
        }
        for (int i = 0; i < temp.Count; i++)
        {
            int r = Random.Range(i, temp.Count);
            (temp[i], temp[r]) = (temp[r], temp[i]);
        }
        for (int i = 0; i < 6; i++)
        {
            select.dataList[i].price = temp[i];
            pricetext[i].text = select.dataList[i].price.ToString() + "円";
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
