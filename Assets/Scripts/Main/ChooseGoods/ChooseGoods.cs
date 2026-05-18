using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChooseGoods : MonoBehaviour
{
    public static ChooseGoods Instance;
    
    [SerializeField]
    Goods goods;
    [SerializeField]
    GameObject ChoiceButton;
    [SerializeField]
    GameObject GoodsPanel;
    [SerializeField]
    Transform ParentPanel;
    Transform ParentCanvasTrans;
    [SerializeField]
    GameObject ParentCanvas;
    [SerializeField]
    GameObject Grade_image;
    [SerializeField]
    GameObject Combo_image;
    [SerializeField]
    Statestate.Grade grade;
    [SerializeField]
    TextMeshProUGUI targetText;
    [SerializeField]
    GameObject ResultPanel;
    List<GameObject> Destroygameobject = new List<GameObject>();
    [SerializeField]
    KindOfSprite kos = new KindOfSprite();

    [SerializeField] TextMeshProUGUI[] resetText;

    bool a = false;

    private GoodsCatalog catalog;
    private ComboCounter combo = new ComboCounter();

    public int Combo
    {
        get => combo.Current; 
        set
        {
            if (value == 0) combo.Reset();

            else if (value > combo.Current) combo.Add();
        }
    }

    void Awake()
    {
        Instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ParentCanvasTrans = ParentCanvas.transform;
        catalog = new GoodsCatalog(goods);
        SpriteAndAmountChange();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CreateButton(GoodsCatalog.Entry entry, Transform parent)
    {
        GameObject but = Instantiate(ChoiceButton, parent);
        but.GetComponent<Button>().onClick.AddListener(() => Money(entry.Amount));

        Destroygameobject.Add(but);

        Text text = but.transform.GetChild(0).GetComponent<Text>();
        text.text = entry.Amount.ToString();

        Image image = but.transform.GetChild(1).GetComponent<Image>();
        image.sprite = entry.Sprite;
    }
    void SpriteAndAmountChange()
    {
        Statestate.Grade l_grade = grade;

        int buttonCount = Mathf.Clamp((int)grade,1,5);

        var picked = catalog.PickRandom(buttonCount);

        if(buttonCount==5)
        {
            GameObject extraPanel = Instantiate(GoodsPanel, ParentCanvasTrans);
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

    public void Money(int am)
    {
        if (a) return;
        a = true;
        targetText.text = am.ToString();

        foreach (var obj in Destroygameobject)
        {
            Destroy(obj);
        }
        Destroygameobject.Clear();
        ProbabilityManager.AM.TargetAmount = am;
        ParentCanvas.SetActive(false);
        
        a = false;
    }

    public void TotalInputMoney()
    {
        if (a) return;
        a = true;
        ProbabilityManager.AM.InputMoney = ProbabilityManager.TotalMoney(ProbabilityManager.coin);

        grade = ProbabilityManager.GradeJudge();

        StartCoroutine(AmountDisplay());

        for(int i = 0; i < resetText.Length;i++)
        {
            resetText[i].text = "";
        }

        a = false;
    }

    IEnumerator AmountDisplay()
    {
        GameObject Text = GameObject.Find("sumMoneyright");

        TextMeshProUGUI ugui = Text.GetComponent<TextMeshProUGUI>();

        ugui.text = ProbabilityManager.TotalMoney(ProbabilityManager.coin).ToString();

        yield return null;

        Grade_image.SetActive(true);

        Image gr_sp = Grade_image.GetComponent<Image>();

        gr_sp.sprite = kos.Grade_Sp(grade);

        if(Combo>=3)
        {
            Combo_image.SetActive(true);

            Image com_sp = Combo_image.GetComponent<Image>();

            com_sp.sprite = kos.Combo_Sp(Combo);
        }

        yield return null;

        Grade_image.SetActive(false);
        Combo_image.SetActive(false);

        ParentCanvas.SetActive(true);
        SpriteAndAmountChange();
    }
}
