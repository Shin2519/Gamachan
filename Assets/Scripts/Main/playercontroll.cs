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
    [SerializeField]
    private UI mouse;
    [SerializeField, Header("クリックしたかどうか")]
    private bool IsInter;
    public static Vector2 MovInput;
    [SerializeField]
    private Vector2 HotSpot;

    [SerializeField]
    GameObject cursor;

    public static List<RaycastResult> Past_Result = new List<RaycastResult>();

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
        Cursor.SetCursor(mouse.mouse[0],HotSpot,CursorMode.Auto);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DragAndDrop();
        if (IsInter)
        {
            Cursor.SetCursor(mouse.mouse[1], HotSpot, CursorMode.Auto);
        }
        else
        {
            Cursor.SetCursor(mouse.mouse[0], HotSpot, CursorMode.Auto);
        }
    }
    private void DragAndDrop()//物をつかんで離す
    {
        if(IsInter)
        {
            timer--;
            if(timer<=0)
            {
                timer = 10;
                WalletMove.Instance.Drag();
            }
        }
        else
        {
            Past_Result.Clear();
        }
    }
}
