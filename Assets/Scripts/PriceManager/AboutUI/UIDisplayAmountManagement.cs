using UnityEngine;

public class UIDisplayAmountManagement : MonoBehaviour
{
    public static UIDisplayAmountManagement instance;
    [SerializeField]
    GamaChanControll gamacont;
    [SerializeField, Header("制限時間")]
    float f_timer;
    [SerializeField]
    float f_current = 0;
    public float Timer => f_timer;
    public float Current
    {
        get => f_current;
        set
        {
            f_current = Mathf.Clamp(value,0,100);
            if(value>=100)
            {
                GameUI.instance.GaugeImageControl();
                GameLoopManagement.Instance.GamaStateChange(true);
            }
        }
    }
    void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameLoopManagement.Instance._Gamestate==StateMashine.GameState.StartCountDownPhase) return;
        f_timer -= Time.deltaTime;
        if (f_timer < 0) f_timer = 0;
    }
}
