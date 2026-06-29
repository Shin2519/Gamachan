using UnityEngine;
using System;
using System.Collections;

public class UIDisplayAmountManagement : MonoBehaviour
{
    Action<bool> Ongaugefull;

    Action<Action<bool>> Ongaugeimagecontrol;

    Func<IEnumerator> OnFinishCountDown;

    Func<StateMashine.Skill> GetSkillState;

    StateMashine.GameState OnGameState;

    [SerializeField] GameUI gameUI;

    [SerializeField, Header("制限時間")]
    float f_timer;

    [SerializeField]
    float f_current = 0;

    [SerializeField]
    int f_combo;
    public float Timer => f_timer;

    bool finish = false;
    public float Current
    {
        get => f_current;
        set
        {
            f_current = Mathf.Clamp(value,0,100);
            if(f_current>=100)
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
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (OnGameState == StateMashine.GameState.StartCountDownPhase) return;
        f_timer -= Time.deltaTime;
        if(f_timer<=4&&!finish)
        {
            StartCoroutine(OnFinishCountDown());
            finish = true;
        }
        if (f_timer < 0) f_timer = 0;
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

    public void AddTimer(float addtime)
    {
        f_timer += addtime;
    }
}
