using UnityEngine.UI;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System;

public class playercontroll : MonoBehaviour
{
    public static playercontroll instance;

    [SerializeField]
    float timer;

    [SerializeField, Header("マウスカーソルとなるUI")]
    private Image moucecursor;
    [SerializeField, Header("マウスカーソルの種類")]
    private Sprite[] MouceCursorSprite;
    [SerializeField, Header("クリックしたかどうか")]
    private bool IsInter;

    [SerializeField,Header("振れているかどうか判定する範囲")]
    private float judge;

    [SerializeField,Header("マウスカーソルのポジション")]
    private RectTransform cursor_position;

    public static Vector2 MovInput;

    [SerializeField]
    GameObject cursor;
    [SerializeField] private CountDoune cd;
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
        DontDestroyOnLoad(cursor);
        instance = this;
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
        MouceCursor();
        if (!UIManagement.instance.Finish.activeSelf)
        {
            DragAndDrop();
        }
        if (IsInter)
        {
            moucecursor.sprite = MouceCursorSprite[1];
        }
        else
        {
            moucecursor.sprite = MouceCursorSprite[0];
        }
    }

    private void MouceCursor()
    {
        Vector2 pos;
        pos = MovInput;
        cursor_position.position = pos;
    }

    private void DragAndDrop()//物をつかんで離す
    {
        GameObject ui = null;
        if(IsInter)
        {
            timer--;
            if(timer<=0)
            {
                timer = 10;
                WalletMove.Instance.Drag(ui);
            }
        }
        else
        {
            ui = null;
        }
    }
}
