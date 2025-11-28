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

        select.target = Random.Range(70, 250)*10;
        targettext.text = select.target.ToString() + "円を目指せ!";

        Price();

        Goods(); 
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

    //商品価格
    private void Price()
    {
        int usecount = Random.Range(2, 6);

        List<int> ans = new List<int>();
        int sum = 0;

        for(int i=0; i<usecount-1;i++)
        {
            int v=Random.Range(1, select.target /20)*10;
            ans.Add(v);
            sum += v;
        }

        int last = select.target - sum;
        if(last<=0||last%100!=0)
        {
            Price();
            return;
        }
        ans.Add(last);

        List<int> temp=new List<int>(ans);

        while(temp.Count < 6)
        {
            int dummy = Random.Range(10, 50)*10;
            if (dummy == select.target ||ans.Contains(dummy))
            {
                continue;
            }
            temp.Add(dummy);
        }
        for (int i=0;i<temp.Count;i++)
        { 
            int r=Random.Range(i,temp.Count);
            (temp[i], temp[r]) = (temp[r], temp[i]);
        }
        for(int i=0;i<6;i++)
        {
            select.dataList[i].price = temp[i];
            pricetext[i].text= select.dataList[i].price.ToString() + "円";
        }

    }
    //商品画像
    private void Goods()
    {
        int slotcount=image.Length;
        int imagecount = select.dataList.Count;

        if(imagecount<slotcount)
        {
            Debug.Log("ss");
            return;
        }

        imageindex.Clear();

        for (int i = 0; i < imagecount; i++)
        {
            imageindex.Add(i);
        }
        for (int i = 0; i < imageindex.Count; i++)
        {
            int random = Random.Range(i, imageindex.Count);
            int temp = imageindex[i];
            imageindex[i] = imageindex[random];
            imageindex[random] = temp;

        }

        for(int i=0;i<slotcount;i++)
        {
            int index = imageindex[i];
            image[i].sprite = select.dataList[index].image;
        }
        
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
