using StateMashine;
using Statestate;
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

    public GameState _Gamestate { get => gameState; set { gameState = value; } }

    void Awake()
    {
        Instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameState = GameState.StartCountDownPhase;
    }

    // Update is called once per frame
    void Update()
    {
        switch (gameState)
        {
            case GameState.StartCountDownPhase:
                StartCoroutine(GameUI.instance.StartTimer());
                break;
            case GameState.GoodsSelectPhase:
                break;
            case GameState.GamaSakePhase:
                break;
            case GameState.RegisterPhase:
                break;
            case GameState.ScorePhase:
                break;
        }
    }
}
