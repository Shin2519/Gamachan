using UnityEngine.UI;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class playercontroll : MonoBehaviour
{
    public static playercontroll instance;

    [SerializeField,Header("�}�E�X�J�[�\���̃|�W�V����")]
    private RectTransform cursor_position;
    [SerializeField,Header("�J�[�\���𓮂������Ƃ��ɑ���������̓x�N�g��")]
    Vector2 MovInput;
    [SerializeField]
    private EventSystem E_System;
    [SerializeField,Header("���肷�郌�C���[")]
    private LayerMask layer;
    string layername;
    [SerializeField]
    GraphicRaycaster G_raycas;
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

    public void DragAndDrop(bool IsClick)//��������ŗ���
    {
        if(IsClick)
        {
            Drag();
        }
        else
        {
            
        } 
    }

    private void Drag()
    {
        PointerEventData data = new PointerEventData(E_System);
        data.position = MovInput;
        List<RaycastResult> results = new List<RaycastResult>();
        G_raycas.Raycast(data, results);
        foreach(var result in results)
        {
            result.gameObject.transform.position = data.position;
        }
    }
}
