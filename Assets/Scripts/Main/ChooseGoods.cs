using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;

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
    int x;
    [SerializeField]
    TextMeshProUGUI targetText;
    [SerializeField]
    GameObject ResultPanel;
    List<Sprite> Goods_Sp = new List<Sprite>();
    List<int> Goods_Amount = new List<int>();
    List<GameObject> Destroygameobject = new List<GameObject>();
    [SerializeField]
    KindOfSprite kos = new KindOfSprite();

    [SerializeField] TextMeshProUGUI[] resetText;
    public int Combo { get; set; }

    bool a = false;
    void Awake()
    {
        Instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ParentCanvasTrans = ParentCanvas.transform;
        GoodsSet();
        SpriteAndAmountChange();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GoodsSet()
    {
        foreach(var genre in goods.Genres)
        {
            foreach(var item in genre.Items)
            {
                Goods_Sp.Add(item.GoodsSprite);
                Goods_Amount.Add(item.Amount);
            }
        }
    }

    List<int> GetUniqueRandomIndices(int count, int max)
    {
        List<int> candidates = new List<int>();
        for(int i = 0;i < max;i++)candidates.Add(i);

        List<int> result = new List<int>();

        for(int i = 0;i < count;i++)
        {
            if (candidates.Count == 0) break;
            int idx = Random.Range(0, candidates.Count);
            result.Add(candidates[idx]);
            candidates.RemoveAt(idx);
        }
        return result;
    }

    void CreateButton(int goodsIndex, Transform parent)
    {
        Sprite sprite = Goods_Sp[goodsIndex];
        int amount = Goods_Amount[goodsIndex];

        GameObject but = Instantiate(ChoiceButton, parent);
        but.GetComponent<Button>().onClick.AddListener(() => Money(amount));

        Destroygameobject.Add(but);

        Text text = but.transform.GetChild(0).GetComponent<Text>();
        text.text = amount.ToString();

        Image image = but.transform.GetChild(1).GetComponent<Image>();
        image.sprite = sprite;
    }
    void SpriteAndAmountChange()
    {
        int buttonCount = Mathf.Clamp(x,1,5);

        var indices = GetUniqueRandomIndices(buttonCount, Goods_Sp.Count);

        if(buttonCount==5)
        {
            GameObject extraPanel = Instantiate(GoodsPanel, ParentCanvasTrans);
            Destroygameobject.Add(extraPanel);
            Transform extraPanelTrans = extraPanel.transform;
            for (int i = 0; i < 3; i++)
                CreateButton(indices[i], ParentPanel);

            for (int i = 3; i < 5; i++)
                CreateButton(indices[i], extraPanelTrans);
        }
        else
        {
            for (int i = 0; i < indices.Count; i++)
                CreateButton(indices[i], ParentPanel);
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

        x = ProbabilityManager.GradeJudge();

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

        gr_sp.sprite = kos.Grade_Sp(x);

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
