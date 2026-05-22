using UnityEngine;

public class TimerManagement : MonoBehaviour
{
    public static TimerManagement instance;
    [SerializeField, Header("§ŒÀŽžŠÔ")]
    float f_timer;
    public float Timer => f_timer;
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
