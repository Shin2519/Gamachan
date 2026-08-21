using UnityEngine;
using System;
using System.Collections;

public class UIDisplayAmountManagement : MonoBehaviour
{
    const int Min_ComboCount = 3;

    const float Max_Gauge = 100;

    Action<bool> Ongaugefull;

    Action<Action<bool>> Ongaugeimagecontrol;

    Action<float,float> OnGaugeUpdate;

    Action OnTimerDisplay;

    Func<IEnumerator> OnFinishCountDown;

    Func<StateMashine.Skill> GetSkillState;

    StateMashine.GameState OnGameState;

    [SerializeField] GameUI gameUI;

    [SerializeField, Header("制限時間")]
    float f_timer;

    [SerializeField]
    float f_current = 0;

    Coroutine finishCountDownCoroutine;
    [SerializeField]
    int f_combo;
    public float Timer
    {
        get => f_timer;
        set
        {
            if (OnGameState == StateMashine.GameState.StartCountDownPhase) return;
            f_timer = Mathf.Max(value,0);
            OnTimerDisplay();
            if (f_timer <= 4 && !finish)
            {
                finishCountDownCoroutine = StartCoroutine(OnFinishCountDown());
                finish = true;
            }
        }
    }

    bool finish = false;

    /// <summary>
    /// ゲージ管理
    /// </summary>
    public float Current
    {
        get => f_current;
        set
        {
            f_current = Mathf.Clamp(value,0,Max_Gauge);
            OnGaugeUpdate(value, Max_Gauge);
            if(f_current>= Max_Gauge)
            {
                Ongaugefull(true);
                StateMashine.Skill OnSkillState = GetSkillState();
                if (OnSkillState == StateMashine.Skill.Golden) return;
                Ongaugeimagecontrol(Ongaugefull);
            }
        }
    }

    public int Combo
    {
        get => f_combo;

        set
        {
            f_combo = value;
            if(f_combo>=Min_ComboCount) AnythingData.AddComboBonus(f_combo);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Timer -= Time.deltaTime;
    }

    public void SetActionMesod_bool(Action<bool> l_changestate)
    {
        Ongaugefull = l_changestate;
    }
    public void SetActionMesod(Action<Action<bool>> l_imagecontrol)
    {
        Ongaugeimagecontrol = l_imagecontrol;
    }

    public void SetFuncMesod(Func<IEnumerator> l_finishtimer)
    {
        OnFinishCountDown = l_finishtimer;
    }

    public void SetGameState(StateMashine.GameState l_gamestate)
    {
        OnGameState = l_gamestate;
    }
    public void SetSkillState(Func<StateMashine.Skill> l_skillstate)
    {
        GetSkillState = l_skillstate;
    }

    public void SetActionMethod_Gauge(Action<float,float> l_gaugeupdate)
    {
        OnGaugeUpdate = l_gaugeupdate;
    }

    public void SetActionMethod_Timer(Action l_timerdisplay)
    {
        OnTimerDisplay = l_timerdisplay;
    }

    public void AddTimer(float addtime)
    {
        f_timer += addtime;
        if (f_timer > 4 && finish)
        {
            if (finishCountDownCoroutine != null)
            {
                StopCoroutine(finishCountDownCoroutine);
                finishCountDownCoroutine = null;
            }

            finish = false;
            gameUI.CancelFinishTimer();
        }

        OnTimerDisplay();
        StartCoroutine(gameUI.PlusTimeText(addtime));
    }

    public void MinusTimer(float time)
    {
        f_timer -= time;
        StartCoroutine(gameUI.MinusTimeText(time));
    }

}
