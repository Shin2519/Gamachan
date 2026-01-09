using UnityEngine.UI;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEditorInternal;
using System;

public class playercontroll : MonoBehaviour
{
    public static playercontroll instance;

    [SerializeField]
    float timer;

    [SerializeField,Header("振れているかどうか判定する範囲")]
    private float judge;

    [SerializeField,Header("マウスカーソルのポジション")]
    private RectTransform cursor_position;

    [SerializeField,Header("カーソルを動かしたときに代入される入力ベクトル")]
    Vector2 MovInput;

    Vector2 MinPos = new Vector2(-860,130);
    Vector2 MaxPos = new Vector2(960,540);

    Vector2 AfterPos;
    [SerializeField]
    EventSystem E_System;
    [SerializeField]
    GraphicRaycaster G_raycast;
    [SerializeField]
    RectTransform ParentCanvas;

    [SerializeField]
    GameObject cursor;
    GameObject ui;
    private void OnMove(InputValue val)
    {
        MovInput = val.Get<Vector2>();
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
            timer--;
            if(timer<=0)
            {
                timer = 10;
                Drag();
            }
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
            bool isSwiping = false;
            bool WasSwiping = false;

            RectTransform ui_Pos = ui.GetComponent<RectTransform>();

            float Speed = Mathf.Pow(SpeedMath(ui_Pos),0.5f);

            if (Speed > judge)
            {
                isSwiping = true;
            }
            else if (Speed < 0.1f)
            {
                isSwiping = false;
            }
            if (!WasSwiping && isSwiping)
            {
                if(UIManagement.instance.Currentgauge>=100)
                {
                    ProbabilityManager.instance.Gold(Speed);
                }
                else
                {
                    ProbabilityManager.instance.Normal(Speed);
                } 
            }
            WasSwiping = isSwiping;
        }
    }
    private float SpeedMath(RectTransform UIPosition)
    {
        Vector2 CurrentPos = UIPosition.anchoredPosition;

        Vector2 localPoint;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(ParentCanvas, MovInput, null, out localPoint);

        float Clamped_x = Mathf.Clamp(localPoint.x, MinPos.x, MaxPos.x);

        float Clamped_y = Mathf.Clamp(localPoint.y, MinPos.y, MaxPos.y);

        Vector2 ClampedlocalPoint = new Vector2(Clamped_x,Clamped_y);

        UIPosition.anchoredPosition = ClampedlocalPoint;

        AfterPos = UIPosition.anchoredPosition;

        Vector2 Dis = AfterPos - CurrentPos;

        return Dis.magnitude/Time.deltaTime;
    }
}
