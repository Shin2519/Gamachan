using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WalletMove : MonoBehaviour
{
    public static WalletMove Instance;

    [SerializeField]
    Camera _camera;

    [SerializeField]
    ProbabilityManager probability = new ProbabilityManager();
    public GameObject gama;
    [SerializeField, Header("êUÇÍÇƒÇ¢ÇÈÇ©Ç«Ç§Ç©îªíËÇ∑ÇÈîÕàÕ"),Range(0,50)]
    private float judge;

    [SerializeField]
    LayerMask gamalayer;
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

    //public void Drag()
    //{
    //    GameObject UI_ = null;
    //    PointerEventData data = new PointerEventData(E_System);
    //    data.position = playercontroll.MovInput;
    //    List<RaycastResult> results = new List<RaycastResult>();

    //    if(playercontroll.Past_Result.Count>=1)
    //    {
    //        results = playercontroll.Past_Result;
    //        UI_ = results[0].gameObject;
    //    }
    //    if(results.Count==0)
    //    {
    //        if (G_raycast == null) return;
    //        G_raycast.Raycast(data, results);

    //        if (results.Count > 0)
    //        {
    //            UI_ = results[0].gameObject;
    //            if (playercontroll.Past_Result.Count == 0 && results[0].gameObject.GetComponent<UnityEngine.UI.Button>()==null) 
    //                playercontroll.Past_Result.Add(results[0]);
    //        }
    //    }
    //    if (UI_ != null)
    //    {
    //        bool isSwiping = false;
    //        bool WasSwiping = false;

    //        RectTransform ui_Pos = UI_.GetComponent<RectTransform>();

    //        float Speed = Mathf.Pow(SpeedMath(ui_Pos), 0.5f);

    //        if (Speed > judge)
    //        {
    //            isSwiping = true;
    //        }
    //        else if (Speed < 0.1f)
    //        {
    //            isSwiping = false;
    //        }
    //        if (!WasSwiping && isSwiping)
    //        {
    //            if (UIManagement.uimanagement.Currentgauge >= 100)
    //            {
    //                probability.Gold(Speed);
    //            }
    //            else
    //            {
    //                probability.Normal(Speed);
    //            }
    //        }
    //        WasSwiping = isSwiping;
    //    }
    //}

    public void Drag2()
    {
        bool IsSwiping = false;

        bool WasSwiping = false;

        Vector2 CurrntPos = new Vector2();

        Vector2 AfterPos = new Vector2();

        Vector3 input = new Vector3(playercontroll.MovInput.x,playercontroll.MovInput.y,Camera.main.nearClipPlane);

        Vector2 MouceWorldPos = Camera.main.WorldToScreenPoint(input);

        if(gama==null)
        {
            RaycastHit2D hit = Physics2D.Raycast(MouceWorldPos, Vector2.zero, gamalayer);
            gama = hit.collider.gameObject;

            CurrntPos = gama.transform.position;
        }
        gama.transform.position = input;

        AfterPos = gama.transform.position;

        float Dis = (AfterPos - CurrntPos).magnitude;
        Debug.Log(Dis);
        float Speed = Mathf.Pow(Dis,0.5f);

        if(Speed > judge)
        {

        }
    }
    //private float SpeedMath(RectTransform UIPosition)
    //{
    //    Vector2 CurrentPos = UIPosition.anchoredPosition;

    //    Vector2 localPoint;

    //    RectTransformUtility.ScreenPointToLocalPointInRectangle(ParentCanvas, playercontroll.MovInput, null, out localPoint);

    //    Vector2 MinPos = new Vector2(-860, 130);
    //    Vector2 MaxPos = new Vector2(960, 540);

    //    float Clamped_x = Mathf.Clamp(localPoint.x, MinPos.x, MaxPos.x);

    //    float Clamped_y = Mathf.Clamp(localPoint.y, MinPos.y, MaxPos.y);

    //    Vector2 ClampedlocalPoint = new Vector2(Clamped_x, Clamped_y);

    //    UIPosition.anchoredPosition = ClampedlocalPoint;

    //    Vector2 AfterPos = UIPosition.anchoredPosition;

    //    Vector2 Dis = AfterPos - CurrentPos;

    //    return Dis.magnitude / Time.deltaTime;
    //}
}
