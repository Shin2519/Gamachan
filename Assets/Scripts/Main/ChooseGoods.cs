using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChooseGoods : MonoBehaviour
{
    public static ChooseGoods Instance;
    struct Syouhin
    {
        public Sprite GoodsSprite;

        public int Amount;
    }
    Syouhin item;
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
    List<int> ChoicedNum = new List<int>();
    List<int> Money_amount = new List<int>();
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
        for (int i = 0; i < goods.SomeIceCream.Length; i++)
        {
            Goods_Sp.Add(goods.SomeIceCream[i].GoodsSprite);
            Goods_Amount.Add(goods.SomeIceCream[i].Amount);
        }

        for (int i = 0; i < goods.SomeOnigiri.Length; i++)
        {
            Goods_Sp.Add(goods.SomeOnigiri[i].GoodsSprite);
            Goods_Amount.Add(goods.SomeOnigiri[i].Amount);
        }

        for (int i = 0; i < goods.SomeGreenTea.Length; i++)
        {
            Goods_Sp.Add(goods.SomeGreenTea[i].GoodsSprite);
            Goods_Amount.Add(goods.SomeGreenTea[i].Amount);
        }

        for (int i = 0; i < goods.SomeRamen.Length; i++)
        {
            Goods_Sp.Add(goods.SomeRamen[i].GoodsSprite);
            Goods_Amount.Add(goods.SomeRamen[i].Amount);
        }

        for (int i = 0; i < goods.SomeSandwich.Length; i++)
        {
            Goods_Sp.Add(goods.SomeSandwich[i].GoodsSprite);
            Goods_Amount.Add(goods.SomeSandwich[i].Amount);
        }

        for (int i = 0; i < goods.SomeChicken.Length; i++)
        {
            Goods_Sp.Add(goods.SomeChicken[i].GoodsSprite);
            Goods_Amount.Add(goods.SomeChicken[i].Amount);
        }

        for (int i = 0; i < goods.SomeBread.Length; i++)
        {
            Goods_Sp.Add(goods.SomeBread[i].GoodsSprite);
            Goods_Amount.Add(goods.SomeBread[i].Amount);
        }

        for (int i = 0; i < goods.SomePotatoChips.Length; i++)
        {
            Goods_Sp.Add(goods.SomePotatoChips[i].GoodsSprite);
            Goods_Amount.Add(goods.SomePotatoChips[i].Amount);
        }

        for (int i = 0; i < goods.SomeRegiBags.Length; i++)
        {
            Goods_Sp.Add(goods.SomeRegiBags[i].GoodsSprite);
            Goods_Amount.Add(goods.SomeRegiBags[i].Amount);
        }

        for (int i = 0; i < goods.SomeLanchs.Length; i++)
        {
            Goods_Sp.Add(goods.SomeLanchs[i].GoodsSprite);
            Goods_Amount.Add(goods.SomeLanchs[i].Amount);
        }
    }

    void Choice()
    {
        int Num = Random.Range(0, 10);
        if(ChoicedNum.Count!=0)
        {
            int a = 0;

            int UsedNum = ChoicedNum[a];

            if (ChoicedNum.Count != 0)
            {
                while (Num == UsedNum)
                {
                    Num = Random.Range(0, 10);
                    
                    UsedNum = ChoicedNum[a];
                    a++;
                }
            }
        }
        ChoicedNum.Add(Num);
        item.GoodsSprite = Goods_Sp[Num];
        item.Amount = Goods_Amount[Num];
    }
    void SpriteAndAmountChange()
    {
        if (x == 5)
        {
            GameObject Panel = Instantiate(GoodsPanel, ParentCanvasTrans);

            Transform PanelTrans = Panel.transform;

            GameObject[] But = new GameObject[2];

            for (int i = 0; i < But.Length; i++)
            {
                Choice();

                But[i] = Instantiate(ChoiceButton, PanelTrans);

                int saveitem = item.Amount;

                But[i].GetComponent<Button>().onClick.AddListener(() => Money(saveitem));

                Destroygameobject.Add(But[i]);

                GameObject But_Text = But[i].transform.GetChild(0).gameObject;

                Text teXt = But_Text.GetComponent<Text>();

                teXt.text = saveitem.ToString();

                GameObject But_Image = But[i].transform.GetChild(1).gameObject;

                Image image = But_Image.GetComponent<Image>();

                image.sprite = item.GoodsSprite;
            }

            But = new GameObject[3];

            for (int i = 0; i < But.Length; i++)
            {
                Choice();

                But[i] = Instantiate(ChoiceButton, ParentPanel);

                int saveitem = item.Amount;

                But[i].GetComponent<Button>().onClick.AddListener(() => Money(saveitem));

                Destroygameobject.Add(But[i]);

                GameObject But_Text = But[i].transform.GetChild(0).gameObject;

                Text teXt = But_Text.GetComponent<Text>();

                teXt.text = saveitem.ToString();

                GameObject But_Image = But[i].transform.GetChild(1).gameObject;

                Image image = But_Image.GetComponent<Image>();

                image.sprite = item.GoodsSprite;
            }
        }
        else if (x == 4)
        {
            GameObject[] But = new GameObject[4];

            for (int i = 0; i < But.Length; i++)
            {
                Choice();

                But[i] = Instantiate(ChoiceButton, ParentPanel);

                int saveitem = item.Amount;

                But[i].GetComponent<Button>().onClick.AddListener(() => Money(saveitem));

                Destroygameobject.Add(But[i]);

                GameObject But_Text = But[i].transform.GetChild(0).gameObject;

                Text teXt = But_Text.GetComponent<Text>();

                teXt.text = saveitem.ToString();
                GameObject But_Image = But[i].transform.GetChild(1).gameObject;

                Image image = But_Image.GetComponent<Image>();

                image.sprite = item.GoodsSprite;
            }
        }
        else if (x == 3)
        {
            GameObject[] But = new GameObject[3];

            for (int i = 0; i < But.Length; i++)
            {
                Choice();

                But[i] = Instantiate(ChoiceButton, ParentPanel);

                int saveitem = item.Amount;

                But[i].GetComponent<Button>().onClick.AddListener(() => Money(saveitem));

                Destroygameobject.Add(But[i]);

                GameObject But_Text = But[i].transform.GetChild(0).gameObject;

                Text teXt = But_Text.GetComponent<Text>();

                teXt.text = saveitem.ToString();

                GameObject But_Image = But[i].transform.GetChild(1).gameObject;

                Image image = But_Image.GetComponent<Image>();

                image.sprite = item.GoodsSprite;
            }
        }
        else if (x == 2)
        {
            GameObject[] But = new GameObject[2];

            for (int i = 0; i < But.Length; i++)
            {
                Choice();

                int saveitem = item.Amount;

                But[i] = Instantiate(ChoiceButton, ParentPanel);

                But[i].GetComponent<Button>().onClick.AddListener(() => Money(saveitem));

                Destroygameobject.Add(But[i]);

                GameObject But_Text = But[i].transform.GetChild(0).gameObject;

                Text teXt = But_Text.GetComponent<Text>();

                teXt.text = saveitem.ToString();

                GameObject But_Image = But[i].transform.GetChild(1).gameObject;

                Image image = But_Image.GetComponent<Image>();

                image.sprite = item.GoodsSprite;
            }
        }
        else if (x == 1)
        {
            Choice();

            GameObject But = Instantiate(ChoiceButton, ParentPanel);

            But.GetComponent<Button>().onClick.AddListener(() => Money(item.Amount));

            Destroygameobject.Add(But);

            GameObject But_Text = But.transform.GetChild(0).gameObject;

            Text teXt = But_Text.GetComponent<Text>();

            teXt.text = item.Amount.ToString();

            GameObject But_Image = But.transform.GetChild(1).gameObject;

            Image image = But_Image.GetComponent<Image>();

            image.sprite = item.GoodsSprite;
        }
        else
        {
            Choice();

            GameObject But = Instantiate(ChoiceButton, ParentPanel);

            But.GetComponent<Button>().onClick.AddListener(() => Money(item.Amount));

            Destroygameobject.Add(But);

            GameObject But_Text = But.transform.GetChild(0).gameObject;

            Text teXt = But_Text.GetComponent<Text>();

            teXt.text = item.Amount.ToString();

            GameObject But_Image = But.transform.GetChild(1).gameObject;

            Image image = But_Image.GetComponent<Image>();

            image.sprite = item.GoodsSprite;
        }
    }

    public void Money(int am)
    {
        if (a) return;
        a = true;
        targetText.text = am.ToString();

        for (int i = 0;i < Destroygameobject.Count;i++)
        {
            Destroy(Destroygameobject[i]);
        }

        ProbabilityManager.AM.TargetAmount = am;
        ParentCanvas.SetActive(false);
        Destroygameobject.Clear();
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
