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
    [SerializeField] private TextMeshProUGUI targettext;//目標金額
    [SerializeField] public Image image;//商品画像
    [SerializeField] private GameObject ui;//ボタン表示用
    [SerializeField] private SelectGoodsSO selectGoodsso;
    
    public int target;

    int counta = 0;

    bool max;

    public int index = 0;
    List<int> imageindex = new List<int>();//イメージ用


    void Start()
    {
        ui.gameObject.SetActive(false);


        selectGoodsso.dataList[index].count = 0;
        selectGoodsso.dataList[index].total = 0;

        target = Random.Range(500, 1000);
        targettext.text = target.ToString() + "円を目指せ!";

        selectGoodsso.dataList[index].price = Random.Range(1, 500);
        pricetext.text = selectGoodsso.dataList[index].price.ToString() + "円";


        for (int i = 0; i < 10; i++)
        {
            imageindex.Add(i);
        }
        for(int i = 0;i<imageindex.Count; i++)
        {
            int random=Random.Range(i,imageindex.Count);
            int temp = imageindex[i];
            imageindex[i] = imageindex[random];
            imageindex[random] = temp;

        }

        
        foreach (int i in imageindex)
        {
            image.sprite = selectGoodsso.dataList[imageindex[i]].image;
        }
        

        
        max = false;

        
    }
    private void Update()
    {
        goodscount.text = selectGoodsso.dataList[index].count.ToString();

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
        counta = selectGoodsso.dataList.Sum(data=>data.count);
        
    }
    //合計金額
    private void Total()
    {
        int total = 0;
        foreach(var item in selectGoodsso.dataList)
        {
            total += item.price * item.count;
        }

        selectGoodsso.dataList[index].total = total;

    }
    //商品プラス
    public void OnPlusButton()
    {
        if(!max)
        {
            selectGoodsso.dataList[index].count += 1;
        } 
    }
    //商品マイナス
    public void OnMinusButton()
    {
        if (selectGoodsso.dataList[index].count > 0)
            selectGoodsso.dataList[index].count -= 1;
    }
    //プラスマイナスボタンの表示
    public void OnGoodsButton()
    {
        ui.gameObject.SetActive(true);

    }

}
