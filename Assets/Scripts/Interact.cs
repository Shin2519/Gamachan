using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    [SerializeField, Header("�}�E�X�J�[�\���ƂȂ�UI")]
    private Image moucecursor;
    [SerializeField, Header("�}�E�X�J�[�\���̎��")]
    private Sprite[] MouceCursorSprite;
    [SerializeField, Header("�N���b�N�������ǂ���")]
    private bool IsInter;
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
        playercontroll.instance.DragAndDrop(IsInter);
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
