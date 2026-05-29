using UnityEngine;

public class GamaChanControll : SingletonMonoBehaviour<GamaChanControll>
{
    [SerializeField] MouseInputProvider Input;
    
    [SerializeField] ProbabilityManager probability = new();

    DragOperation drag;

    [SerializeField, Header("触れているか"), Range(0, 20)]
    private float judge;

    [SerializeField] LayerMask gamalayer;

    [SerializeField] Vector2 MinPos;

    [SerializeField] Vector2 MaxPos;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        drag = new DragOperation(MinPos,MaxPos,judge);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameLoopManagement.Instance._Gamestate!=StateMashine.GameState.GamaSakePhase)return;
        HandleDrag();
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
        }
        
        if (drag.IsActive)
        {
            float? swipeSpeed = drag.UpdatePosition(Input.GetWorldPosition(), Time.deltaTime);
            if (swipeSpeed.HasValue)
            {
                Debug.Log(swipeSpeed);
                probability.Normal(swipeSpeed.Value);
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
}
