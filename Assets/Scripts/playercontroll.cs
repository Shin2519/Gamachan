using UnityEngine.UI;
using UnityEngine;
using UnityEngine.InputSystem;

public class playercontroll : MonoBehaviour
{
    public static playercontroll instance;
    [SerializeField]
    GameObject cube;
    [SerializeField]
    private Image moucecursor;
    [SerializeField,Header("マウスカーソルの種類")]
    private Sprite[] moucecursorSprite;
    [SerializeField]
    private RectTransform cursor_position;
    [SerializeField]
    Vector2 MovInput;
    [SerializeField]
    private bool IsInter;
    public Vector2 MoucePos => MovInput;
    private void OnMove(InputValue val)
    {
        MovInput = val.Get<Vector2>();
    }

    void OnInteract(InputValue val)
    {
        IsInter = val.isPressed;
    }

    void Awake()
    {
        instance = this;
        moucecursor = GetComponent<Image>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
        moucecursor.sprite = moucecursorSprite[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos;
        pos = MovInput;
        cursor_position.position = pos;
        Vector3 CurrentPos = cube.transform.position;
        if(IsInter)
        {
            moucecursor.sprite = moucecursorSprite[1];
            Ray ray = Camera.main.ScreenPointToRay(MovInput);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit))
            {
                Vector3 TargetPos = new Vector3(MovInput.x, MovInput.y, -50.0f);
                cube.transform.position = TargetPos;
                Vector3 DisPos = TargetPos - CurrentPos;
            }
        }
        else
        {
            moucecursor.sprite = moucecursorSprite[0];
        }
    }
}
