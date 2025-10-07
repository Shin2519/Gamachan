using UnityEngine.UI;
using UnityEngine;
using UnityEngine.InputSystem;

public class playercontroll : MonoBehaviour
{
    public static playercontroll instance;
    [SerializeField]
    GameObject cube;
    [SerializeField]
    private float Speed;
    [SerializeField,Header("マウスカーソルとなるUI")]
    private Image moucecursor;
    [SerializeField,Header("マウスカーソルの種類")]
    private Sprite[] MouceCursorSprite;
    [SerializeField,Header("マウスカーソルのポジション")]
    private RectTransform cursor_position;
    [SerializeField,Header("カーソルを動かしたときに代入される入力ベクトル")]
    Vector2 MovInput;
    [SerializeField,Header("クリックしたかどうか")]
    private bool IsInter;
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
        Cursor.visible = false;//マウスカーソルを非表示にする
        moucecursor.sprite = MouceCursorSprite[0];
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
            moucecursor.sprite = MouceCursorSprite[1];
            Ray ray = Camera.main.ScreenPointToRay(MovInput);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject Cube = hit.collider.gameObject;
            }
        }
        else
        {
            moucecursor.sprite = MouceCursorSprite[0];
        }
    }
}
