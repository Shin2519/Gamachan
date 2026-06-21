using StateMashine;
using UnityEngine;

namespace StateMashine
{ 
    public enum GameState
    {
        StartCountDownPhase,
        GoodsSelectPhase,
        GamaSakePhase,
        RegisterPhase,
        ScorePhase
    }
    public enum GamaState
    {
        Nomal,
        Gold
    }
    public enum Skill
    {
        None,
        NoSkill,
        Golden,
        NormalLocked,
        AddTime
    }

    public enum Grade
    {
        Perfect = 5,
        Great = 4,
        Good = 3,
        Bad = 2,
        Miss = 1
    }
}
public class GameLoopManagement : MonoBehaviour
{
    public static GameLoopManagement Instance;

    [SerializeField] GamachanRendererChange GamaRendererChange;

    [SerializeField] UIDisplayAmountManagement AmountManagement;

    [SerializeField] GameUI GameUI;

    [SerializeField] ButtonManagement ButtonManagement;

    [SerializeField] ChooseGoods ChooseGoods;

    [SerializeField,Header("ゲームの流れ")] GameState gameState;

    [SerializeField] Grade gradestate;

    [SerializeField] Skill SkillState;

    [SerializeField] GamaState gamastate;

    SkillDetail skillDetail = new();

    public GameState _Gamestate 
    { 
        get => gameState; 
        set 
        {
            gameState = value;

            OnGameState(gameState);
        } 
    }

    public Skill _SkillState
    {
        get => SkillState;
        set
        {
            SkillState = value;
            OnSkillState(SkillState);
        }
    }

    public GamaState _Gamastate
    {
        get => gamastate;
        set
        {
            gamastate = value;
            GamaRendererChange.NomalAndGold(gamastate);
        }
    }

    public Grade _Gradestate
    {
        get => gradestate;
        set
        {
            gradestate = value;
        }
    }
    void Awake()
    {
        Instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _Gamestate = GameState.StartCountDownPhase;
        AmountManagement.SetActionMesod_bool(GamaStateChange);
        GameUI.SetActionMesod(GamaStateChange);
        ButtonManagement.SetActionMesod(GradeJudge);
    }

    void Update()
    {
        GameUI.SetGrade(_Gradestate);
    }
    void OnGameState(GameState l_gamestate)
    {
        switch (l_gamestate)
        {
            case GameState.StartCountDownPhase:
                StartCoroutine(GameUI.StartTimer());
                break;
            case GameState.GoodsSelectPhase:
                ChooseGoods.SpriteAndAmountChange();
                GameUI.PaymentTextReset();
                break;
        }
    }

    void OnSkillState(Skill l_skillstate)
    {
        switch (l_skillstate)
        {
            case Skill.NoSkill:
                Debug.Log("スキルどこ？");
                break;
            case Skill.Golden:
                skillDetail.Golden(AmountManagement.Current);
                break;
            case Skill.NormalLocked:
                skillDetail.NormalLocked();
                break;
            case Skill.AddTime:
                skillDetail.AddTime(AmountManagement.Timer);
                break;
        }
    }
    public void GamaStateChange(bool Change)
    {
        _Gamastate = Change ? GamaState.Gold : GamaState.Nomal;
    }

    public void GameStateChange(GameState l_gamestate)
    {
        switch (l_gamestate)
        {
            case GameState.StartCountDownPhase:
                l_gamestate = GameState.GoodsSelectPhase;
                break;
            case GameState.GoodsSelectPhase:
                l_gamestate = GameState.GamaSakePhase;
                break;
            case GameState.GamaSakePhase:
                l_gamestate = GameState.RegisterPhase;
                break;
            case GameState.RegisterPhase:
                l_gamestate = GameState.GamaSakePhase;
                break;
            case GameState.ScorePhase:
                break;
        }
    }

    public void GradeJudge()
    {
        if (AnythingData.payment.InputMoney >= AnythingData.payment.TargetAmount)
        {
            int Sub = AnythingData.payment.InputMoney - AnythingData.payment.TargetAmount;
            if (Sub <= 0)
            {
                gradestate = Grade.Perfect;
                AnythingData.gradecount.PerfectCount++;
                ChooseGoods.Instance.Combo++;
                AnythingData.payment.ChangeMoney += Sub;
            }
            else if (Sub >= 1 && Sub <= 500)
            {
                gradestate = Grade.Great;
                AnythingData.gradecount.GreatCount++;
                ChooseGoods.Instance.Combo++;
                AnythingData.payment.ChangeMoney += Sub;
            }
            else if (Sub >= 501 && Sub <= 1000)
            {
                gradestate = Grade.Good;
                AnythingData.gradecount.GoodCount++;
                ChooseGoods.Instance.Combo++;
                AnythingData.payment.ChangeMoney += Sub;
            }
            else
            {
                gradestate = Grade.Bad;
                AnythingData.gradecount.BadCount++;
                ChooseGoods.Instance.Combo = 0;
                AnythingData.payment.ChangeMoney += Sub;
            }
        }
        else
        {
            gradestate = Grade.Miss;
            AnythingData.gradecount.MissCount++;
            ChooseGoods.Instance.Combo = 0;
        }
    }
}
