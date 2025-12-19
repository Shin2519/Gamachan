using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    [SerializeField, Header("マウスカーソルとなるUI")]
    private Image moucecursor;
    [SerializeField, Header("マウスカーソルの種類")]
    private Sprite[] MouceCursorSprite;
    [SerializeField, Header("クリックしたかどうか")]
    private bool IsInter;
    [SerializeField] private CountDoune cd;
    void OnInteract(InputValue val)
    {
        IsInter = val.isPressed;
    }

    void Awake()
    {
        moucecursor = GetComponent<Image>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moucecursor.sprite = MouceCursorSprite[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(!UIManagement.instance.Finish.activeSelf||cd.countdoun)
        {
            playercontroll.instance.DragAndDrop(IsInter);
        }
        if(IsInter)
        {
            moucecursor.sprite = MouceCursorSprite[1];
        }
        else
        {
            moucecursor.sprite = MouceCursorSprite[0];
        }
    }
}
