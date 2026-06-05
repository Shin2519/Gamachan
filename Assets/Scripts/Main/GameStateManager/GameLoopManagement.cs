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
}
public class GameLoopManagement : MonoBehaviour
{
    public static GameLoopManagement Instance;
    [SerializeField]
    GamaChanControll Gamachan;

    [SerializeField]
    KindOfSprite GamaSprite;

    [SerializeField,Header("ゲームの流れ")]
    GameState gameState;

    [SerializeField]
    Skill SkillState;

    [SerializeField]
    GamaState gamastate;

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
            switch(gamastate)
            {
                case GamaState.Nomal:
                    Gamachan.p_GamachanRenderer= GamaSprite.GamaChange(gamastate);
                    break;
                case GamaState.Gold:
                    Gamachan.p_GamachanRenderer = GamaSprite.GamaChange(gamastate);
                    break;
            }
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
    }
    void OnGameState(GameState l_gamestate)
    {
        switch (l_gamestate)
        {
            case GameState.StartCountDownPhase:
                StartCoroutine(GameUI.instance.StartTimer());
                break;
            case GameState.GoodsSelectPhase:
                ChooseGoods.Instance.SpriteAndAmountChange();
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
                skillDetail.Golden(UIDisplayAmountManagement.instance.Current);
                break;
            case Skill.NormalLocked:
                skillDetail.NormalLocked();
                break;
            case Skill.AddTime:
                skillDetail.AddTime(UIDisplayAmountManagement.instance.Timer);
                break;
        }
    }
    public void GamaStateChange(bool Change)
    {
        gamastate = Change ? GamaState.Gold : GamaState.Nomal;
    }
}
