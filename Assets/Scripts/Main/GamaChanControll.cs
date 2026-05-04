using State;
using UnityEngine;
using UnityEngine.InputSystem;

public class GamaChanControll : MonoBehaviour
{
    [SerializeField, Header("クリックしたかどうか")]
    private bool IsInter;
    [SerializeField]
    bool IsLight;
    Vector2 MovInput;
    [SerializeField] 
    private Vector2 HotSpot;
    Texture2D currentCursor;
    [SerializeField, Range(0, 999)] float timer;
    [SerializeField] private UI mouse;
    [SerializeField]
    ProbabilityManager probability = new ProbabilityManager();
    GameObject gama;
    [SerializeField, Header("振れているかどうか判定する範囲"), Range(0, 20)]
    private float judge;
    [SerializeField]
    LayerMask gamalayer;

    bool IsSwiping = false;

    bool WasSwiping = false;

    Vector3 CurrentPos = new Vector3();

    Vector3 AfterPos = new Vector3();
    private void OnMove(InputValue val)
    {
        MovInput = val.Get<Vector2>();
    }

    void OnInteract(InputValue val)
    {
        IsInter = val.isPressed;
    }
    void OnInteractL(InputValue val)
    {
        IsLight = val.isPressed;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentCursor = mouse.mouse[0];
        Cursor.SetCursor(currentCursor, HotSpot, CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCursor();
        DragAndDrop();
        if(IsLight)
        {
            GameObject LightHand = GameObject.Find("hand");
            GameObject TargetPos = GameObject.Find("TargetPosition");
            if(LightHand != null)
            {
                LightHand.SetActive(true);
                Vector3 Pos = (TargetPos.transform.position - LightHand.transform.position);
                if (Pos.x <= 2.5f) return;
                Vector3 Tar_P = Pos.normalized;
                LightHand.transform.position = Tar_P * 2;
            }
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

    private void DragAndDrop()
    {
        if(IsInter)
        {
            Vector3 MousePos = new Vector3(MovInput.x,MovInput.y,-Camera.main.transform.position.z);

            Vector3 MouceWorldPos = Camera.main.ScreenToWorldPoint(MousePos);
            if (gama == null)
            {
                RaycastHit2D hit = Physics2D.Raycast(MouceWorldPos, Vector2.zero, Mathf.Infinity, gamalayer);
                if (hit)
                {
                    gama = hit.collider.gameObject;
                }
                else
                {
                    gama = null;
                }
            }
            CurrentPos = gama.transform.position;
            gama.transform.position = MouceWorldPos;

            AfterPos = gama.transform.position;

            float Dis = (AfterPos - CurrentPos).sqrMagnitude;
            float Speed = Dis;
            if (Speed > judge)
            {
                IsSwiping = true;
            }
            else
            {
                IsSwiping = false;
            }
            if (!WasSwiping && IsSwiping)
            {
                Debug.Log(Speed);
                probability.Normal(Speed);
            }
            WasSwiping = IsSwiping;
        }
        else
        {
            gama = null;
        }
    }
}
