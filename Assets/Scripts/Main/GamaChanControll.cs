using UnityEngine;
using UnityEngine.InputSystem;

public class GamaChanControll : SingletonMonoBehaviour<GamaChanControll>
{
    [SerializeField, Header("クリックしたかどうか")]
    private bool IsInter;
    Vector2 MovInput;
    [SerializeField]
    private Vector2 HotSpot;
    Texture2D currentCursor;
    [SerializeField, Range(0, 999)] 
    float timer;
    [SerializeField] 
    private UI mouse;
    [SerializeField]
    ProbabilityManager probability = new();
    DragOperation drag;
    [SerializeField, Header("振れているかどうか判定する範囲"), Range(0, 20)]
    private float judge;
    [SerializeField]
    LayerMask gamalayer;
    [SerializeField]
    Vector2 MinPos;
    [SerializeField]
    Vector2 MaxPos;
    private Camera Cam;
    void OnMove(InputValue val) => MovInput = val.Get<Vector2>();
    void OnInteract(InputValue val)
    {
        IsInter = val.isPressed;
        if (IsInter) TryGrab();
        else drag.End();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        drag = new DragOperation(MinPos,MaxPos,judge);
        Cam = Camera.main;
        currentCursor = mouse.mouse[0];
        Cursor.SetCursor(currentCursor, HotSpot, CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(MovInput);
        UpdateCursor();
        if (drag.IsActive)
        {
            float? swipeSpeed = drag.UpdatePosition(PointerWorld(), Time.deltaTime);
            if (swipeSpeed.HasValue) probability.Normal(swipeSpeed.Value);
        }
    }
    void UpdateCursor()
    {
        Texture2D nextCursor = IsInter ? mouse.mouse[1] : mouse.mouse[0];

        // カーソルが変わる時だけ SetCursor を呼ぶ
        if (currentCursor != nextCursor)
        {
            Cursor.SetCursor(nextCursor, HotSpot, CursorMode.Auto);
            currentCursor = nextCursor;
        }
    }

    private Vector3 PointerWorld()
    {
        Vector3 MouceWorld = new Vector3(MovInput.x, MovInput.y, -Cam.transform.position.z);

        return Cam.ScreenToWorldPoint(MouceWorld);
    }

    private void TryGrab()
    {
        Vector3 MouceWorldPos = PointerWorld();
        RaycastHit2D hit = Physics2D.Raycast(MouceWorldPos, Vector3.zero, Mathf.Infinity, gamalayer);
        if (hit.collider == null) return;
        drag.Begin(hit.collider.transform, MouceWorldPos);
    }
}
