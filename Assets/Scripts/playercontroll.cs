using UnityEngine.UI;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using NUnit.Framework;

public class playercontroll : MonoBehaviour
{
    public static playercontroll instance;

    [SerializeField,Header("�}�E�X�J�[�\���̃|�W�V����")]
    private RectTransform cursor_position;

    [SerializeField,Header("�J�[�\���𓮂������Ƃ��ɑ���������̓x�N�g��")]
    Vector2 MovInput;

    [SerializeField,Header("����������UI�̃L�����o�X�ɂ���GraphicRaycaster")]
    private GraphicRaycaster G_raycast;

    [SerializeField]
    private EventSystem E_system;

    [SerializeField,Header("����������UI�̐e�ƂȂ��Ă���L�����o�X")]
    private RectTransform ParentCanvas;

    [SerializeField, Header("�K�}�����̕ω�")]
    private Sprite[] Gama;

    GameObject ui;

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
        Cursor.visible = false;//�}�E�X�J�[�\�����\���ɂ���
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
        if (IsClick)
        {
            Drag();
        }
        else
        {
            ui = null;
        } 
    }

    private void Drag()
    {
        PointerEventData data = new PointerEventData(E_system);
        data.position = MovInput;
        List<RaycastResult> results = new List<RaycastResult>();
        G_raycast.Raycast(data, results);
        if (results.Count > 0)
        {
            ui = results[0].gameObject;
            Sprite ui_sp = ui.GetComponent<Sprite>();
        }
        if(ui!=null)
        {
            RectTransform ui_Pos = ui.GetComponent<RectTransform>();
            Vector2 CurrnetPos = ui_Pos.position;
            Vector2 localPos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(ParentCanvas, MovInput, null, out localPos);
            ui_Pos.anchoredPosition = localPos;
            Vector2 AfterPos = ui_Pos.position;
            Vector2 Dis = AfterPos - CurrnetPos;
            Debug.Log(Dis.magnitude);
            if(Dis.magnitude>=0)
            {
                int rnd = Random.Range(0, 2);
                Debug.Log($"{rnd}");
            }
        }
    }
}
