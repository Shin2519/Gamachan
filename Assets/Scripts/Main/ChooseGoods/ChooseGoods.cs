using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseGoods : MonoBehaviour
{
    StateMashine.Grade f_grade;

    [SerializeField] ButtonManagement buttonmanagement;

    [SerializeField] Goods goods;

    [SerializeField] GameObject ChoiceButton;

    [SerializeField] GameObject GoodsPanel;

    [SerializeField] Transform ParentGoodsPanel;

    [SerializeField] Transform ParentGoodsCanvas;

    [SerializeField] SkillDescripsion descripsion;

    Transform ParentPanel;

    List<GameObject> Destroygameobject = new List<GameObject>();

    bool OnPay = false;

    private GoodsCatalog catalog;
    public bool P_OnPay => OnPay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ParentPanel = GoodsPanel.transform;
        catalog = new GoodsCatalog(goods,descripsion);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CreateButton(GoodsCatalog.Entry entry, Transform parent)
    {
        GameObject but = Instantiate(ChoiceButton, parent);
        but.GetComponent<Button>().onClick.AddListener(() => buttonmanagement.Money(entry.Amount,entry.Sprite,Destroygameobject,entry.Number));

        Destroygameobject.Add(but);

        Text text = but.transform.GetChild(0).GetComponent<Text>();
        text.text = entry.Amount.ToString();

        Image image = but.transform.GetChild(1).GetComponent<Image>();
        image.sprite = entry.Sprite;

        Text text_2 = but.transform.GetChild(2).GetComponent<Text>();
        text_2.text = entry.Description.ToString();
    }
    public void SpriteAndAmountChange()
    {
        StateMashine.Grade l_grade = f_grade;

        int buttonCount = Mathf.Clamp((int)f_grade,1,5);

        var picked = catalog.PickRandom(buttonCount);

        if(buttonCount==5)
        {
            GameObject extraPanel = Instantiate(GoodsPanel, ParentGoodsCanvas);
            Destroygameobject.Add(extraPanel);
            Transform extraPanelTrans = extraPanel.transform;
            for (int i = 0; i < 3; i++)
                CreateButton(picked[i], ParentPanel);

            for (int i = 3; i < 5; i++)
                CreateButton(picked[i], extraPanelTrans);
        }
        else
        {
            for (int i = 0; i < picked.Count; i++)
                CreateButton(picked[i], ParentPanel);
        }
    }

    public void SetGrade(StateMashine.Grade l_grade)
    {
        f_grade = l_grade;
    }
}
