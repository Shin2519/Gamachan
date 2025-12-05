using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;


public class SelectGoods : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI goodscount;//商品個数のテキスト
    [SerializeField] private TextMeshProUGUI[] pricetext;//商品単価のテキスト
    

    [SerializeField] public Image[] image;//商品画像
    [SerializeField] private GameObject ui;//ボタン表示用
    [SerializeField] private SelectGoodsSO select;
    [SerializeField] private TextMeshProUGUI targettext;//目標金額

    int counta = 0;//選択個数
    bool max;
    
    public int index = 0;

    private List<data> pricedata;
    void Start()
    {
        ui.gameObject.SetActive(false);
        pricedata = select.dataList
            .Select(x => new data { price = x.price, image = x.image, count = x.count })
            .ToList();

        select.dataList[index].count = 0;
        select.total = 0;
        select.target = 0;

        priceset();

        Price();
        max = false;
    }
    void Update()
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
    public void Price()
    {
        int usecount = Random.Range(2, 6);
        

        List<int> ans = new List<int>();
        

        int n =pricedata.Count;
        //目標金額の作成
        ans.Clear();

        for (int i = 1; i < (1<<n); i++)
        {
            int sum = 0;
            for(int f=0;f<n;f++)
            {
                if((i&(1<<i)) !=0)
                {
                    sum += pricedata[i].price;
                }
            }
            ans.Add(sum);
        }
        ans =ans.Distinct().ToList();

        select.target = ans[Random.Range(0, ans.Count)];

        int last = select.target;
        ans.Add(last);
        
        List<int> temp = new List<int>(ans);
        //ダミー料金
        //while (temp.Count < 6 &&pricedata.Count>0)
        //{
        //    int dummy = pricedata[Random.Range(0, pricedata.Count)];

        //    if (dummy == select.target || ans.Contains(dummy))
        //    {
        //        pricedata.Remove(dummy);
        //        continue;
        //    }
        //    temp.Add(dummy);
        //    pricedata.Remove(dummy);
        //}
        //表示シャッフル
        for (int i = 0; i < temp.Count; i++)
        {
            int r = Random.Range(i, temp.Count);
            (temp[i], temp[r]) = (temp[r], temp[i]);
        }
        while (temp.Count<6)
        {
            int dm = ans[Random.Range(0, ans.Count)];
            temp.Add(dm);
        }
        //UI適応
        for (int i = 0; i < 6; i++)
        {
            pricedata[i].price=temp[i];
            pricetext[i].text = temp[i].ToString() + "円";//select.dataList[0]のindexを変更することで表示される金額が変わる
        }
        targettext.text = select.target.ToString();
    }
    
    //商品の価格設定
    public void priceset()
    {
        //商品の価格
        select.dataList[0].price = Random.Range(3, 5)*1;//袋
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
