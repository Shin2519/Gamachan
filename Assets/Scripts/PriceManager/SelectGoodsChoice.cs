using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectGoodsChoice : MonoBehaviour//MasterCodeに戻す
{
    private int jageCount = 0;//正解回数

    [SerializeField,Header("覚える画像")]private Image[] targetImage;//正解の画像


    private int rand;

    [SerializeField, Header("商品表示時間")] private float displaytime;

    [SerializeField] private SelectGoodsSO selectSO;

    [SerializeField,Header("商品選択パネル")] private GameObject[] choosePanel;//商品選択パネル

    [SerializeField] GameObject targetpanel;//正解商品画面
    //[SerializeField] private GameObject tly;
    //[SerializeField] private GameObject reset;
    //[SerializeField] private GameObject gametext;
    //[SerializeField, Header("0左,1右")] private Image[] jageImage;//0左,1右
    //[SerializeField, Header("0〇,1×")] private Sprite[] jageSprit;//0〇,1×


    void Start()
    {
        InitCounts();
    }

    // 初期化
    public void InitCounts()
    {
        //jageImage[0].enabled = false;
        //jageImage[1].enabled = false;
        //Gama.SetActive(false);
        //tly.SetActive(false);
        //gametext.SetActive(false);
        rand = Random.Range(0, 10);
        for(int i=0;i<choosePanel.Length;i++)
        {
            choosePanel[i].SetActive(false);
        }
    }


    IEnumerator Mainroop()
    {
        

        yield return new WaitForSeconds(displaytime);


        switch (jageCount)
        {
            case 0://一倍目
                targetImage[0].sprite = selectSO.dataList[rand].image;
                SetchooseUI(2);
                choosePanel[0].SetActive(true);
                break;
            case 1://二倍目
                targetImage[0].sprite = selectSO.dataList[rand].image;
                SetchooseUI(3);
                choosePanel[1].SetActive(true);

                break;
            case 2://三倍目
                targetImage[0].sprite = selectSO.dataList[rand].image;
                SetchooseUI(4);
                choosePanel[2].SetActive(true);

                break;
            case 3://四倍目
                SetchooseUI(5);
                choosePanel[3].SetActive(true);

                break;
            case 4://五倍目
                SetchooseUI(6);
                choosePanel[4].SetActive(true);

                break;
            case 5://六倍目
                SetchooseUI(6);
                choosePanel[5].SetActive(true);

                break;
        }
    }

    void SetchooseUI(int j)
    {
        for (int i = 0; i < j; i++)
        {
            selectSO.chooseDatas[i].image[rand] = selectSO.damyDatas[rand].image;
        }
    }


    private void OnEnable()
    {
        InitCounts();

    }
}
