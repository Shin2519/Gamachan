using UnityEngine.UI;
using UnityEngine;
using UnityEngine.InputSystem;

public class playercontroll : MonoBehaviour
{
    [SerializeField]
    GameObject cube;
    Actions action;
    [SerializeField]
    private Image[] moucecursor;
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
    void Awake()
    {
        action = new Actions();
        //action.Player.Interact.performed += Pressed;
    }

    private void OnEnable()
    {
        action.Enable();
    }
    private void OnDisable()
    {
        action.Disable();
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
                
            }
        }
    }

    //private void Pressed(InputAction.CallbackContext cont)
    //{
    //    var Intaract = cont.ReadValue<Vector2>();
    //    Ray ray = Camera.main.ScreenPointToRay(Intaract);
    //    RaycastHit hit;
    //    if(Physics.Raycast(ray,out hit))
    //    {
    //        cube.transform.position = Intaract;
    //    }
    //}
}
