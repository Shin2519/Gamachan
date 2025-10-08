using UnityEngine.UI;
using UnityEngine;
using UnityEngine.InputSystem;

public class playercontroll : MonoBehaviour
{
    public static playercontroll instance;
    [SerializeField,Header("マウスカーソルのポジション")]
    private RectTransform cursor_position;
    [SerializeField,Header("カーソルを動かしたときに代入される入力ベクトル")]
    Vector2 MovInput;
    GameObject Cube;
    private void OnMove(InputValue val)
    {
        MovInput = val.Get<Vector2>();
    }

    void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;//マウスカーソルを非表示にする
    }

    // Update is called once per frame
    void Update()
    {
        MouceCursor();
    }

    private void MouceCursor()
    {
        Vector2 pos;
        pos = MovInput;
        cursor_position.position = pos;
    }

    public void DragAndDrop(bool IsClick)
    {
        if(IsClick)
        {
            Drag();
        }
        else
        {
            Cube = null;
        } 
    }

    private void Drag()
    {
        Ray ray = Camera.main.ScreenPointToRay(MovInput);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Cube = hit.collider.gameObject;
        }
        if (Cube != null)
        {
            Cube.transform.position = new Vector3(MovInput.x, MovInput.y, -50.0f);
        }
    }
}
