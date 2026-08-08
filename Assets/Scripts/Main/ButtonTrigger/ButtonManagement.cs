using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class ButtonManagement : MonoBehaviour
{
    [SerializeField] GameUI gameUI;

    Action OnGradeJudge;

    Action OnGameStateChange;

    Action<int> OnSkillStateChange;
    
    StateMashine.GameState OnGameState;

    int f_changeStateNum;

    public int p_changeStateNum => f_changeStateNum;

    
    /// <summary>
    /// 生成されたボタン一つ一つに入っている関数
    /// </summary>
    /// <param name="am"></param>
    public void Money(int am,Sprite goodsimage,List<GameObject> l_destroy,int l_changeStateNum)
    {
        if (OnGameState != StateMashine.GameState.GoodsSelectPhase) return;

        AudioManager.Instance.PlaySE(AudioManager.Instance.SE[4]);

        OnSkillStateChange(l_changeStateNum);

        gameUI.rejistergoods.sprite = goodsimage;

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
    public void TotalInputMoney(GameObject sumText)
    {
        if (OnGameState != StateMashine.GameState.GamaSakePhase) return;
        if (gameUI.p_OnPaying) return;

        OnGameStateChange();

        OnGradeJudge();

        StartCoroutine(gameUI.AmountDisplay(sumText));
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

    public void SetActionMesod_SkillState(Action<int> l_skillstatechange)
    {
        OnSkillStateChange = l_skillstatechange;
    }
}
