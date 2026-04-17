using UnityEngine.UI;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System;

public class playercontroll : MonoBehaviour
{
    public static playercontroll instance;

    [SerializeField,Range(0,999)] float timer;
    [SerializeField] private UI mouse;
    [SerializeField, Header("クリックしたかどうか")]
    private bool IsInter;
    public static Vector2 MovInput;
    [SerializeField] private Vector2 HotSpot;

    [SerializeField] GameObject cursor;

    public static List<RaycastResult> Past_Result = new List<RaycastResult>();

    [SerializeField] private CountDoune cd;

    // カーソル最適化用
    private Texture2D currentCursor;

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
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        // 初期カーソル設定
        currentCursor = mouse.mouse[0];
        Cursor.SetCursor(currentCursor, HotSpot, CursorMode.Auto);
    }

    void Update()
    {
        UpdateCursor();   // カーソル処理は Update に移動
        DragAndDrop();    // 入力処理も Update に移動
    }

    // カーソル最適化
    private void UpdateCursor()
    {
        Texture2D nextCursor = IsInter ? mouse.mouse[1] : mouse.mouse[0];

        // カーソルが変わる時だけ SetCursor を呼ぶ
        if (currentCursor != nextCursor)
        {
            Cursor.SetCursor(nextCursor, HotSpot, CursorMode.Auto);
            currentCursor = nextCursor;
        }
    }

    private void DragAndDrop()
    {
        GameObject obj = GameObject.Find("InteractManager");
        if (obj == null) return;

        if (IsInter)
        {
            timer--;
            if (timer <= 0)
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
