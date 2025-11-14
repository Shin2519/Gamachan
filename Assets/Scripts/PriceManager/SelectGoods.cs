using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System.Linq;


public class SelectGoods : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI goodscount;//商品個数のテキスト
    [SerializeField] private TextMeshProUGUI pricetext;//商品単価のテキスト
    [SerializeField] private Image image;//商品画像
    [SerializeField] private GameObject ui;//ボタン表示用
    [SerializeField] private SelectGoodsSO selectGoodsso;
    

    int counta = 0;

    bool max;

    public int index;

    void Start()
    {
        image.SetNativeSize();

        ui.gameObject.SetActive(false);
        
        pricetext.text = selectGoodsso.dataList[index].price.ToString() + "円";
        image.sprite=selectGoodsso.dataList[index].image;

        selectGoodsso.dataList[index].count = 0;
        selectGoodsso.dataList[index].total = 0;

        max = false;

        
    }
    private void Update()
    {
        goodscount.text = selectGoodsso.dataList[index].count.ToString();

        Total();

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
    private void Total()
    {
        int total = 0;
        foreach(var item in selectGoodsso.dataList)
        {
            total += item.price * item.count;
        }

        selectGoodsso.dataList[index].total = total;

    }
    
    public void OnPlusButton()
    {
        if(!max)
        {
            selectGoodsso.dataList[index].count += 1;
        } 
    }
    public void OnMinusButton()
    {
        if (selectGoodsso.dataList[index].count > 0)
            selectGoodsso.dataList[index].count -= 1;
    }

    public void OnGoodsButton()
    {
        ui.gameObject.SetActive(true);
        
    }

}
