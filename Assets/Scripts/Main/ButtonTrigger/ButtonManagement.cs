using System.Collections.Generic;
using UnityEngine;

public class ButtonManagement : MonoBehaviour
{
    /// <summary>
    /// 生成されたボタン一つ一つに入っている関数
    /// </summary>
    /// <param name="am"></param>
    public void Money(int am,List<GameObject> l_destroy)
    {
        if (GameLoopManagement.Instance._Gamestate != StateMashine.GameState.GoodsSelectPhase) return;
        GameUI.instance.TextInRegister(true);
        foreach (var obj in l_destroy)
        {
            Destroy(obj);
        }
        l_destroy.Clear();
        ProbabilityManager.AM.TargetAmount = am;
        GameUI.instance.GoodsCanvas();
        GameLoopManagement.Instance._Gamestate = StateMashine.GameState.GamaSakePhase;
    }

    /// <summary>
    /// 精算ボタンを押したときにPaymentStatesという構造体の要素の中に値が入り、おつりや評価、コンボ数が表示される
    /// </summary>
    public void TotalInputMoney()
    {
        if (GameLoopManagement.Instance._Gamestate != StateMashine.GameState.GamaSakePhase) return;
        if (GameUI.instance.p_OnPaying) return;
        ProbabilityManager.AM.ChangeMoney = ProbabilityManager.TotalMoney(ProbabilityManager.coin);

        ChooseGoods.Instance.p_grade = ProbabilityManager.GradeJudge();

        StartCoroutine(GameUI.instance.AmountDisplay());
    }

    public void SaveNameData()
    {
        //string Namedata = GameUI.instance.p_InputNameUGUI.ToString();
        string Namedata = InputName.instance.inputField.ToString();

        for (int i = 0;i < 5;i++)
        {
            if(!PlayerPrefs.HasKey("Name" + (i + 1).ToString()))
            {
                PlayerPrefs.SetString((i + 1).ToString(),Namedata);
                break;
            }
        }
    }
}
