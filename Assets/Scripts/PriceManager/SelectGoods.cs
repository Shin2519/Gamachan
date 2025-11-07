using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class SelectGoods : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI goodscount;//商品個数のテキスト
    [SerializeField] private TextMeshProUGUI pricetext;//商品単価のテキスト
    //public int total;//合計金額
    [SerializeField] private GameObject ui;//ボタン表示用
    private int count;
    [SerializeField]private SelectGoodsManager manager;
    [SerializeField] private SelectGoodsSO selectGoodsso;
    [SerializeField] private int index;

    [SerializeField] private TextMeshProUGUI al;
    private void Start()
    {
      
        ui.gameObject.SetActive(false);
        
        pricetext.text = selectGoodsso.dataList[index].price.ToString() + "円";
    }
    private void Update()
    {
        goodscount.text = count.ToString();

        manager.total = selectGoodsso.dataList[index].price * count;

        al.text = manager.total.ToString();
        manager.maxcount = count;
        if (manager.maxcount == 6)
        {
            Debug.Log("最大");
        }
    }
    public void OnPlusButton()
    {
        count += 1;
    }
    public void OnMinusButton()
    {
        if (count > 0)
            count -= 1;
    }

    public void OnGoodsButton()
    {
        ui.gameObject.SetActive(true);
        
    }

}
