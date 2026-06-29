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
    [SerializeField] UIDisplayAmountManagement AmountManagement;

    [SerializeField] GamachanRendererChange GamaRendererChange;

    [SerializeField] ButtonManagement ButtonManagement;

    [SerializeField] PoolManagement PoolManagement;

    [SerializeField] GamaChanControll GamaControl;

    [SerializeField] ChooseGoods ChooseGoods;

    [SerializeField] GameUI GameUI;

    [Header("ゲームの流れ")]

    [SerializeField] GameState gameState;

    [SerializeField] Grade gradestate;

    [SerializeField] Skill SkillState;

    [SerializeField] GamaState gamastate;

    SkillDetail skillDetail;

    public GameState _Gamestate 
    { 
        get => gameState; 
        set 
        {
            gameState = value;

            OnGameState(gameState);
            ButtonManagement.SetGameState(gameState);
            AmountManagement.SetGameState(gameState);
            GamaControl.SetGameState(gameState);
        } 
    }

    public Skill _SkillState
    {
        get => SkillState;
        set
        {
            SkillState = value;
            OnSkillState(value);
        }
    }

    public GamaState _Gamastate
    {
        get => gamastate;
        set
        {
            gamastate = value;
            GamaRendererChange.NomalAndGold();
        }
    }

    public Grade _Gradestate
    {
        get => gradestate;
        set
        {
            gradestate = value;
            GameUI.SetGrade(gradestate);
            ChooseGoods.SetGrade(gradestate);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _Gamestate = GameState.StartCountDownPhase;
        GamaRendererChange.SetGamaState(GetGamaState);
        skillDetail = new SkillDetail(AmountManagement);
        AmountManagement.SetActionMesod_bool(GamaStateChange);
        AmountManagement.SetSkillState(GetSkillState);
        GameUI.SetActionMesod_GameState(GameStateChange);
        ButtonManagement.SetActionMesod(GradeJudge);
        ButtonManagement.SetActionMesod_GameState(GameStateChange);
        ButtonManagement.SetActionMesod_SkillState(SkillStateChange);
        PoolManagement.SetSkillState(GetSkillState);
    }
    void OnGameState(GameState l_gamestate)
    {
        float l_pasttimer = 0;

        switch (gameState)
        {
            case GameState.StartCountDownPhase:
                StartCoroutine(GameUI.StartTimer());
                PoolManagement.CoinInitialize();
                break;
            case GameState.GoodsSelectPhase:
                _Gamastate = GamaState.Nomal;
                _SkillState = Skill.NoSkill;
                l_pasttimer = AmountManagement.Timer;
                AnythingData.PaymentReset();
                GameUI.ChangeMoneyDisplay();
                GameUI.TextInRegister(false);
                ChooseGoods.SpriteAndAmountChange();
                break;
            case GameState.RegisterPhase:
                AnythingData.AddSpeedBonus(l_pasttimer,AmountManagement.Timer);
                if (gamastate == GamaState.Gold) AnythingData.anotherbonus.GoldenCount++;
                break;
        }
    }

    void OnSkillState(Skill l_skillstate)
    {
        switch (l_skillstate)
        {
            case Skill.NoSkill:
                skillDetail.None();
                break;
            case Skill.Golden:
                skillDetail.Golden();
                break;
            case Skill.NormalLocked:
                skillDetail.NormalLocked();
                break;
            case Skill.AddTime:
                skillDetail.AddTime();
                break;
        }
    }
    public void GamaStateChange(bool Change)
    {
        _Gamastate = Change ? GamaState.Gold : GamaState.Nomal;
    }

    public void GameStateChange()
    {
        switch (_Gamestate)
        {
            case GameState.StartCountDownPhase:
                _Gamestate = GameState.GoodsSelectPhase;
                break;
            case GameState.GoodsSelectPhase:
                _Gamestate = GameState.GamaSakePhase;
                break;
            case GameState.GamaSakePhase:
                _Gamestate = GameState.RegisterPhase;
                break;
            case GameState.RegisterPhase:
                _Gamestate = GameState.GoodsSelectPhase;
                break;
            case GameState.ScorePhase:
                break;
        }
    }

    public void SkillStateChange(int num)
    {
        switch (num)
        {
            case 0:
                _SkillState = Skill.NoSkill;
                break;
            case 1:
                _SkillState = Skill.Golden;
                break;
            case 2:
                _SkillState = Skill.NormalLocked;
                break;
            case 3:
                _SkillState = Skill.AddTime;
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
                _Gradestate = Grade.Perfect;
                AnythingData.gradecount.PerfectCount++;
                AmountManagement.Combo++;
                AnythingData.payment.ChangeMoney += Sub;
            }
            else if (Sub >= 1 && Sub <= 500)
            {
                _Gradestate = Grade.Great;
                AnythingData.gradecount.GreatCount++;
                AmountManagement.Combo++;
                AnythingData.payment.ChangeMoney = Sub;
                AnythingData.anotherbonus.TotalChangeCount += Sub;
            }
            else if (Sub >= 501 && Sub <= 1000)
            {
                _Gradestate = Grade.Good;
                AnythingData.gradecount.GoodCount++;
                AmountManagement.Combo++;
                AnythingData.payment.ChangeMoney = Sub;
                AnythingData.anotherbonus.TotalChangeCount += Sub;
            }
            else
            {
                _Gradestate = Grade.Bad;
                AnythingData.gradecount.BadCount++;
                AmountManagement.Combo = 0;
                AnythingData.payment.ChangeMoney = Sub;
                AnythingData.anotherbonus.TotalChangeCount += Sub;
            }
        }
        else
        {
            _Gradestate = Grade.Miss;
            AnythingData.gradecount.MissCount++;
            AmountManagement.Combo = 0;
        }
    }
    Skill GetSkillState()
    {
        return SkillState;
    }

    GamaState GetGamaState()
    {
        return gamastate;
    }
}
