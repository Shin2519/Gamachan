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
    [SerializeField,Header("�}�E�X�J�[�\���ƂȂ�UI")]
    private Image moucecursor;
    [SerializeField,Header("�}�E�X�J�[�\���̎��")]
    private Sprite[] MouceCursorSprite;
    [SerializeField,Header("�}�E�X�J�[�\���̃|�W�V����")]
    private RectTransform cursor_position;
    [SerializeField,Header("�J�[�\���𓮂������Ƃ��ɑ���������̓x�N�g��")]
    Vector2 MovInput;
    [SerializeField,Header("�N���b�N�������ǂ���")]
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
        Cursor.visible = false;//�}�E�X�J�[�\�����\���ɂ���
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
