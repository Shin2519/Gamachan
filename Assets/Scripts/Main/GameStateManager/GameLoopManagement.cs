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
}
public class GameLoopManagement : MonoBehaviour
{
    public static GameLoopManagement Instance;
    [SerializeField,Header("ƒQ[ƒ€‚Ì—¬‚ê")]
    GameState gameState;

    public GameState _Gamestate 
    { 
        get => gameState; 
        set 
        {
            if (gameState == value) return;

            gameState = value;

            OnStateEnter(gameState);
        } 
    }
    void Awake()
    {
        Instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameState = GameState.StartCountDownPhase;
    }
    void OnStateEnter(GameState l_gamestate)
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
}
