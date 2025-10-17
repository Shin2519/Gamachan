using UnityEngine.UI;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class playercontroll : MonoBehaviour
{
    public static playercontroll instance;
    enum STATE 
    { 
        normal,
        shake
    }
    [SerializeField]
    private STATE state;
    [SerializeField,Header("振れているかどうか判定する範囲")]
    private float judge;
    [SerializeField,Header("マウスカーソルのポジション")]
    private RectTransform cursor_position;
    [SerializeField,Header("カーソルを動かしたときに代入される入力ベクトル")]
    Vector2 MovInput;
    [SerializeField]
    private EventSystem E_System;
    [SerializeField]
    GraphicRaycaster G_raycast;
    [SerializeField]
    private RectTransform ParentCanvas;
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
        Cursor.visible = false;//マウスカーソルを非表示にする
        state = STATE.normal;
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

    public void DragAndDrop(bool IsClick)//物をつかんで離す
    {
        if(IsClick)
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
        PointerEventData data = new PointerEventData(E_System);
        data.position = MovInput;
        List<RaycastResult> results = new List<RaycastResult>();
        G_raycast.Raycast(data, results);
        if(results.Count > 0)
        {
            ui = results[0].gameObject;
        }
        if (ui!= null)
        {
            int Count = 1;
            RectTransform ui_Pos = ui.GetComponent<RectTransform>();
            Vector2 CurrentPos = ui_Pos.position;
            Vector2 localPoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(ParentCanvas, MovInput, null, out localPoint);
            ui_Pos.anchoredPosition = localPoint;
            Vector2 AfterPos = ui_Pos.position;
            Vector2 Dis = AfterPos - CurrentPos;
            if(Dis.magnitude > judge&&Count!=0)
            {
                Count = 0;
                state = STATE.shake;
                int rnd = Random.Range(0, 2);
                Debug.Log(rnd);
            }
            else if(Dis.magnitude < 0.1f)
            {
                state = STATE.normal;
            }
        }
        
    }
}
