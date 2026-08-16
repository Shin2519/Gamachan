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
        AddTime5,
        AddTime7,
        AddTime10,
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
    /// <summary>
    /// それぞれのgameStateの状態の時の処理をさせる関数
    /// </summary>
    /// <param name="l_gamestate"></param>
    void OnGameState(GameState l_gamestate)
    {
        float l_pasttimer = 0;

        switch (gameState)
        {
            case GameState.StartCountDownPhase:
                AnythingData.DataInitialize();
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
            case GameState.GamaSakePhase:
                GameUI.TargetAmountDisplay();
                break;
            case GameState.RegisterPhase:
                AnythingData.AddSpeedBonus(l_pasttimer,AmountManagement.Timer);
                if (gamastate == GamaState.Gold) AnythingData.anotherbonus.GoldenCount++;
                break;
        }
    }
    /// <summary>
    /// それぞれのスキルの状態の時の処理をする関数
    /// </summary>
    /// <param name="l_skillstate"></param>
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
            case Skill.AddTime5:
                skillDetail.AddTime5();
                break;
            case Skill.AddTime7:
                skillDetail.AddTime7();
                break;
            case Skill.AddTime10:
                skillDetail.AddTime10();
                break;

        }
    }
    /// <summary>
    /// bool型の引数のtrue、falseでガマちゃんの状態を変える関数
    /// </summary>
    /// <param name="Change"></param>
    void GamaStateChange(bool Change)
    {
        _Gamastate = Change ? GamaState.Gold : GamaState.Nomal;
    }
    /// <summary>
    /// それぞれのgameStateの時に次の状態に変える関数
    /// </summary>
    void GameStateChange()
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
    /// <summary>
    /// int型の引数の変数の値によってスキルの状態を変える関数
    /// </summary>
    /// <param name="num"></param>
    void SkillStateChange(int num)
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
                _SkillState = Skill.AddTime5;
                break;
            case 4:
                _SkillState = Skill.AddTime7;
                break;
            case 5:
                _SkillState = Skill.AddTime10;
                break;
        }
    }
    /// <summary>
    /// 投入金額から目標金額を引いた差額によって、gradestateの状態を変えたり、それぞれの状態になった回数を数えたりする関数
    /// </summary>
    public void GradeJudge()
    {
        if (AnythingData.payment.InputMoney >= AnythingData.payment.TargetAmount)
        {
            int Sub = AnythingData.payment.InputMoney - AnythingData.payment.TargetAmount;
            if (Sub <= 500)
            {
                AudioManager.Instance.PlaySE(AudioManager.Instance.SE[10]);
                _Gradestate = Grade.Perfect;
                AnythingData.gradecount.PerfectCount++;
                AmountManagement.Combo++;
                AnythingData.payment.ChangeMoney += Sub;
            }
            else if (Sub >= 501 && Sub <= 750)
            {
                AudioManager.Instance.PlaySE(AudioManager.Instance.SE[11]);
                _Gradestate = Grade.Great;
                AnythingData.gradecount.GreatCount++;
                AmountManagement.Combo++;
                AnythingData.payment.ChangeMoney = Sub;
                AnythingData.anotherbonus.TotalChangeCount += Sub;
            }
            else if (Sub >= 751 && Sub <= 1000)
            {
                AudioManager.Instance.PlaySE(AudioManager.Instance.SE[12]);
                _Gradestate = Grade.Good;
                AnythingData.gradecount.GoodCount++;
                AmountManagement.Combo++;
                AnythingData.payment.ChangeMoney = Sub;
                AnythingData.anotherbonus.TotalChangeCount += Sub;
            }
            else
            {
                AudioManager.Instance.PlaySE(AudioManager.Instance.SE[13]);
                _Gradestate = Grade.Bad;
                AnythingData.gradecount.BadCount++;
                AmountManagement.Combo = 0;
                AnythingData.payment.ChangeMoney = Sub;
                AnythingData.anotherbonus.TotalChangeCount += Sub;
            }
        }
        else
        {
            AudioManager.Instance.PlaySE(AudioManager.Instance.SE[15]);
            _Gradestate = Grade.Miss;
            AnythingData.gradecount.MissCount++;
            AmountManagement.Combo = 0;
        }
    }
    /// <summary>
    /// UIDisplayAmountManagementやPoolManagementにスキルの状態を渡す関数
    /// </summary>
    /// <returns></returns>
    Skill GetSkillState()
    {
        return SkillState;
    }
    /// <summary>
    /// GamachanRendererChangeにガマちゃんの状態を渡す変数
    /// </summary>
    /// <returns></returns>
    GamaState GetGamaState()
    {
        return gamastate;
    }
}
