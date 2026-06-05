using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseGoods : MonoBehaviour
{
    public static ChooseGoods Instance;

    [SerializeField] ButtonManagement buttonmanagement;

    [SerializeField] Goods goods;

    [SerializeField] GameObject ChoiceButton;

    [SerializeField] GameObject GoodsPanel;

    [SerializeField] Transform ParentGoodsPanel;

    [SerializeField] Transform ParentGoodsCanvas;

    Transform ParentPanel;

    List<GameObject> Destroygameobject = new List<GameObject>();

    bool OnPay = false;

    private GoodsCatalog catalog;

    private ComboCounter combo = new ComboCounter();

    public Statestate.Grade p_grade { get; set; }

    public int Combo
    {
        get => combo.Current; 
        set
        {
            if (value == 0) combo.Reset();

            else if (value > combo.Current) combo.Add();
        }
    }

    public bool P_OnPay => OnPay;

    void Awake()
    {
        Instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ParentPanel = GoodsPanel.transform;
        catalog = new GoodsCatalog(goods);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CreateButton(GoodsCatalog.Entry entry, Transform parent)
    {
        GameObject but = Instantiate(ChoiceButton, parent);
        but.GetComponent<Button>().onClick.AddListener(() => buttonmanagement.Money(entry.Amount,Destroygameobject));

        Destroygameobject.Add(but);

        Text text = but.transform.GetChild(0).GetComponent<Text>();
        text.text = entry.Amount.ToString();

        Image image = but.transform.GetChild(1).GetComponent<Image>();
        image.sprite = entry.Sprite;
    }
    public void SpriteAndAmountChange()
    {
        Statestate.Grade l_grade = p_grade;

        int buttonCount = Mathf.Clamp((int)p_grade,1,5);

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
}
