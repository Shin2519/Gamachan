using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class WalletMove : MonoBehaviour
{
    public static WalletMove Instance;

    [SerializeField]
    EventSystem E_System;
    [SerializeField]
    GraphicRaycaster G_raycast;
    [SerializeField]
    RectTransform ParentCanvas;

    [SerializeField, Header("êUÇÍÇƒÇ¢ÇÈÇ©Ç«Ç§Ç©îªíËÇ∑ÇÈîÕàÕ")]
    private float judge;
    void Awake()
    {
        Instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Drag(GameObject UI_)
    {
        PointerEventData data = new PointerEventData(E_System);
        data.position = playercontroll.MovInput;
        List<RaycastResult> results = new List<RaycastResult>();

        G_raycast.Raycast(data, results);

        if (results.Count > 0)
        {
            UI_ = results[0].gameObject;
        }
        if (UI_ != null)
        {
            bool isSwiping = false;
            bool WasSwiping = false;

            RectTransform ui_Pos = UI_.GetComponent<RectTransform>();

            float Speed = Mathf.Pow(SpeedMath(ui_Pos), 0.5f);

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
                if (UIManagement.instance.Currentgauge >= 100)
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

        RectTransformUtility.ScreenPointToLocalPointInRectangle(ParentCanvas, playercontroll.MovInput, null, out localPoint);

        Vector2 MinPos = new Vector2(-860, 130);
        Vector2 MaxPos = new Vector2(960, 540);

        float Clamped_x = Mathf.Clamp(localPoint.x, MinPos.x, MaxPos.x);

        float Clamped_y = Mathf.Clamp(localPoint.y, MinPos.y, MaxPos.y);

        Vector2 ClampedlocalPoint = new Vector2(Clamped_x, Clamped_y);

        UIPosition.anchoredPosition = ClampedlocalPoint;

        Vector2 AfterPos = UIPosition.anchoredPosition;

        Vector2 Dis = AfterPos - CurrentPos;

        return Dis.magnitude / Time.deltaTime;
    }
}
