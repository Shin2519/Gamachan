using System.Collections.Generic;
using UnityEngine;
using System;
public class ButtonManagement : MonoBehaviour
{
    [SerializeField] GameUI gameUI;

    Action OnGradeJudge;

    Action OnGameStateChange;
    
    StateMashine.GameState OnGameState;
    /// <summary>
    /// 生成されたボタン一つ一つに入っている関数
    /// </summary>
    /// <param name="am"></param>
    public void Money(int am,List<GameObject> l_destroy,int l_changeStateNum)
    {
        if (OnGameState != StateMashine.GameState.GoodsSelectPhase) return;
        switch (l_changeStateNum)
        {
            case 0:
                GameLoopManagement.Instance._SkillState = StateMashine.Skill.NoSkill;
                break;
            case 1:
                GameLoopManagement.Instance._SkillState = StateMashine.Skill.Golden;
                break;
            case 2:
                GameLoopManagement.Instance._SkillState = StateMashine.Skill.NormalLocked;
                break;
            case 3:
                GameLoopManagement.Instance._SkillState = StateMashine.Skill.AddTime;
                break;
        }
        gameUI.TextInRegister(true);
        foreach (var obj in l_destroy)
        {
            Destroy(obj);
        }
        l_destroy.Clear();
        AnythingData.payment.TargetAmount = am;
        gameUI.GoodsCanvas();
        OnGameStateChange();
    }

    /// <summary>
    /// 精算ボタンを押したときにPaymentStatesという構造体の要素の中に値が入り、おつりや評価、コンボ数が表示される
    /// </summary>
    public void TotalInputMoney()
    {
        if (OnGameState != StateMashine.GameState.GamaSakePhase) return;
        if (gameUI.p_OnPaying) return;

        OnGameStateChange();

        OnGradeJudge();

        StartCoroutine(gameUI.AmountDisplay());
    }

    public void SetActionMesod(Action l_gradejudge)
    {
        OnGradeJudge = l_gradejudge;
    }

    public void SetActionMesod_GameState(Action l_gamestatechange)
    {
        OnGameStateChange = l_gamestatechange;
    }

    public void SetGameState(StateMashine.GameState l_gamestate)
    {
        OnGameState = l_gamestate;
    }

    public void SaveNameData()
    {
        string Namedata = gameUI.p_InputNameUGUI.ToString(); 
        for(int i = 0;i < 5;i++)
        {
            if(!PlayerPrefs.HasKey("Name" + (i + 1).ToString()))
            {
                PlayerPrefs.SetString((i + 1).ToString(),Namedata);
                break;
            }
        }
    }
}
