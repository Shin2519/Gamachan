using UnityEngine.UI;
using UnityEngine;
using UnityEngine.InputSystem;

public class playercontroll : MonoBehaviour
{
    [SerializeField]
    GameObject cube;
    Actions action;
    [SerializeField]
    private Image moucecursor;
    [SerializeField]
    private RectTransform cursor_position;
    [SerializeField]
    Vector2 MovInput;
    [SerializeField]
    private bool IsInter;
    private void OnMove(InputValue val)
    {
        MovInput = val.Get<Vector2>();
    }

    void OnInteract(InputValue val)
    {
        IsInter = val.isPressed;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos;
        pos = MovInput;
        cursor_position.position = pos;
        if(IsInter)
        {
            Ray ray = Camera.main.ScreenPointToRay(MovInput);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit))
            {
                cube.transform.position = new Vector3(MovInput.x,MovInput.y,-50.0f);
            }
        }
    }
}
