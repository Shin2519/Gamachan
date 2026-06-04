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

    public float shakecharge
    {
        get => ShakeCharge;

        set
        {
            ShakeCharge = Mathf.Clamp(value,0,100);
        }
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        drag = new DragOperation(MinPos,MaxPos);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameLoopManagement.Instance._Gamestate!=StateMashine.GameState.GamaSakePhase)return;
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
            shakecharge += drag.UpdatePosition(Input.GetWorldPosition(), Time.deltaTime,shakecharge);
            probability.Normal(shakecharge);
        }
    }

    private void TryGrab()
    {
        Vector3 MouceWorldPos = Input.GetWorldPosition();
        RaycastHit2D hit = Physics2D.Raycast(MouceWorldPos, Vector3.zero, Mathf.Infinity, gamalayer);
        if (hit.collider == null) return;
        drag.Begin(hit.collider.transform, MouceWorldPos);
    }
}
