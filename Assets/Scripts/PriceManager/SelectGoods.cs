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
    [SerializeField] private TextMeshProUGUI pricetext;//商品単価のテキスト
    
    [SerializeField] public Image image;//商品画像
    [SerializeField] private GameObject ui;//ボタン表示用
    [SerializeField] private SelectGoodsSO select;
    
    

    int counta = 0;//選択個数
    bool max;


    public int index = 0;
    List<int> imageindex = new List<int>();//イメージ用


    void Start()
    {
        ui.gameObject.SetActive(false);


        select.dataList[index].count = 0;
        select.dataList[index].total = 0;


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
    //商品画像
    private void Goods()
    {
        select.dataList[index].price = Random.Range(1, 500);
        pricetext.text = select.dataList[index].price.ToString() + "円";


        for (int i = 0; i < 10; i++)
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


        for (int i = 0; i < imageindex.Count; i++)
        {
            image.sprite = select.dataList[imageindex[i]].image;
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

        select.dataList[index].total = total;

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
