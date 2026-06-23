using UnityEngine;

public class GamaChanControll : MonoBehaviour
{
    [SerializeField] MouseInputProvider Input;
    
    [SerializeField] ProbabilityManager probability = new();

    DragOperation drag;

    [SerializeField] float ShakeCharge;

    [SerializeField] float MoneyTimer;

    [SerializeField] LayerMask gamalayer;

    [SerializeField] Vector2 MinPos;

    [SerializeField] Vector2 MaxPos;

    [SerializeField] SpriteRenderer GamachanRenderer;

    StateMashine.GameState OnGameState;

    public float shakecharge
    {
        get => ShakeCharge;

        set
        {
            ShakeCharge = Mathf.Clamp(value,0,100);
        }
    }

    public Sprite p_GamachanRenderer { set => GamachanRenderer.sprite = value; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        drag = new DragOperation(MinPos,MaxPos);
    }

    // Update is called once per frame
    void Update()
    {
        if(OnGameState!=StateMashine.GameState.GamaSakePhase)return;
        HandleDrag();
        shakecharge -= 2;
    }
    void HandleDrag()
    {
        if (Input.IsPressed && !drag.IsActive)
        {
            TryGrab();
        }
        else if (!Input.IsPressed && drag.IsActive)
        {
            drag.End();
            shakecharge = 0;
        }
        
        if (drag.IsActive)
        {
            MoneyTimer -= Time.deltaTime;
            shakecharge += drag.UpdatePosition(Input.GetWorldPosition(), Time.deltaTime, shakecharge);
            if (MoneyTimer<=0)
            {
                MoneyTimer = 0.2f;
                
                probability.KindofMoney(shakecharge);
            }
        }
    }

    private void TryGrab()
    {
        Vector3 MouceWorldPos = Input.GetWorldPosition();
        RaycastHit2D hit = Physics2D.Raycast(MouceWorldPos, Vector3.zero, Mathf.Infinity, gamalayer);
        if (hit.collider == null) return;
        drag.Begin(hit.collider.transform, MouceWorldPos);
    }

    public void SetGameState(StateMashine.GameState l_gamestate)
    {
        OnGameState = l_gamestate;
    }
}
