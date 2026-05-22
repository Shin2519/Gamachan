using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using NUnit.Framework.Constraints;

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
    Statestate.Grade grade;
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
    public void SpriteAndAmountChange()
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
    /// <summary>
    /// 生成されたボタン一つ一つに入っている関数
    /// </summary>
    /// <param name="am"></param>
    public void Money(int am)
    {
        if (a) return;
        a = true;
        GameUI.instance.TextInRegister(true);
        foreach (var obj in Destroygameobject)
        {
            Destroy(obj);
        }
        Destroygameobject.Clear();
        ProbabilityManager.AM.TargetAmount = am;
        ParentCanvas.SetActive(false);
        GameLoopManagement.Instance._Gamestate = StateMashine.GameState.GamaSakePhase;
        a = false;
    }

    /// <summary>
    /// 精算ボタンを押したときにPaymentStatesという構造体の要素の中に値が入り、おつりや評価、コンボ数が表示される
    /// </summary>
    public void TotalInputMoney()
    {
        if (GameLoopManagement.Instance._Gamestate != StateMashine.GameState.GamaSakePhase) return;
        if (a) return;
        a = true;
        ProbabilityManager.AM.InputMoney = ProbabilityManager.TotalMoney(ProbabilityManager.coin);

        grade = ProbabilityManager.GradeJudge();

        StartCoroutine(AmountDisplay());

        for(int i = 0; i < resetText.Length;i++)
        {
            resetText[i].text = "";
        }

        ProbabilityManager.PaymentReset();
        GameLoopManagement.Instance._Gamestate = StateMashine.GameState.GoodsSelectPhase;
        a = false;
    }

    IEnumerator AmountDisplay()
    {
        GameUI.instance.f_gradeimage.SetActive(true);

        Image gr_sp = GameUI.instance.f_gradeimage.GetComponent<Image>();

        gr_sp.sprite = kos.Grade_Sp(grade);

        if(Combo>=3)
        {
            GameUI.instance.f_comboimage.SetActive(true);

            Image com_sp = GameUI.instance.f_comboimage.GetComponent<Image>();

            com_sp.sprite = kos.Combo_Sp(Combo);
        }

        yield return null;

        GameUI.instance.f_gradeimage.SetActive(false);
        GameUI.instance.f_comboimage.SetActive(false);

        ParentCanvas.SetActive(true);
    }
}
