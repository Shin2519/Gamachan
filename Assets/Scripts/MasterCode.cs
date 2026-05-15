using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace State
{
    public enum Gauge
    {
        Normal,
        Gold
    }
}

public class MasterCode : MonoBehaviour
{
    public static MasterCode mastercode;

    protected int combo;
    [SerializeField]
    protected State.Gauge gauge_state;

    [SerializeField]
    protected Sound sound;

    [SerializeField]
    protected SendData Data;

    [SerializeField]
    protected UI about_ui;

    [SerializeField]
    protected GameObject Gama;

    protected GameObject hyouka;

    protected GameObject comboobject;

    [SerializeField]
    protected GameObject ResultPanel;
    protected Image Gama_Image;


    protected bool isDown = false;

    protected bool Onpay = false;

    void Awake()
    {
        mastercode = this;
    }
    

    
}

public class GradeAndCombo : MasterCode
{
    public static GradeAndCombo gradeandcombo;

    protected int Gameover_count = 0;

    protected SpriteRenderer Grade_Ren;

    [SerializeField]
    protected GameObject Grade;

    [SerializeField]
    protected GameObject combo_image;

    SpriteRenderer combo_Renderer;

    void Awake()
    {
        gradeandcombo = this;
    }
    protected void Combo()
    {
        int i = 0;
        switch (combo)
        {
            case 3:
                ComboObjects(i);
                break;
            case 6:
                i = 1;
                ComboObjects(i);
                break;
            case 9:
                i = 2;
                ComboObjects(i);
                break;
            case 12:
                i = 3;
                ComboObjects(i);
                break;
            case 15:
                i = 4;
                ComboObjects(i);
                break;
            case 18:
                i = 5;
                ComboObjects(i);
                break;
            case 21:
                i = 6;
                ComboObjects(i);
                break;
            case 24:
                i = 7;
                ComboObjects(i);
                break;
            case 27:
                i = 8;
                ComboObjects(i);
                break;
            case 30:
                i = 9;
                ComboObjects(i);
                break;
        }
    }
    void ComboObjects(int i)
    {
        comboobject = Instantiate(combo_image, new Vector3(1750, 1000, 0), Quaternion.identity);
        combo_Renderer = comboobject.GetComponent<SpriteRenderer>();
        combo_Renderer.sprite = about_ui.Kindofcombo[i];
    }
}
public class Register : MasterCode
{
    public static Register register;
    [SerializeField] 
    protected SelectGoodsSO selectgoodsso;
    [SerializeField, Header("合計金額")] 
    protected TextMeshProUGUI sumamounttext;//合計金額テキスト(円)
    // 合計金額が+か-で表示するテキストが変わるため
    [SerializeField]
    protected TextMeshProUGUI sumamountyen;//合計金額テキスト(お釣り、支払残額)
    [SerializeField] 
    protected GameObject selectgoods;
    protected int inputamount = 0;
    public int InputAmount { get { return inputamount; } set { inputamount = value; } }

    public int Total => selectgoodsso.total;

    void Awake()
    {
        register = this;
    }
    public void rndyentext()
    {

        sumamountyen.enabled = false;
        sumamounttext.enabled = false;
        if (gauge_state == State.Gauge.Gold)
        {
            Gama_Image.sprite = about_ui.GoldenKindofemotion[0];
        }
    }
    
}



