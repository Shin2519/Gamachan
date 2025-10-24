using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SelectGoods : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI goodscount;
    private int count = 0;
    private int total;
    private int price = 100;

    [SerializeField] private GameObject[] ui;
    public int dami => total;

    private void Start()
    {
        for (int i = 0; i < ui.Length; i++)
        {
            ui[i].gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        goodscount.text = count.ToString();

        total = price * count;
    }
    public void OnPlusButton()
    {
        count += 1;
    }
    public void OnMinusButton()
    {
        if(count > 0)
        count -= 1;
    }

    public void OnGoodsButton()
    {
        for(int i =0; i<ui.Length; i++)
        {
            ui[i].gameObject.SetActive(true);
        }
    }

}
