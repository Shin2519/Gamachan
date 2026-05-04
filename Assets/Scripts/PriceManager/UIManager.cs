using TMPro;
using UnityEngine;
using UnityEngine.UI;


enum state
{
    ExCellent,
    Perfect,
    Great,
    Good,
    Bad,
    First
}


public class UIManager : MonoBehaviour
{
    [SerializeField] protected GameObject one;
    [SerializeField] protected GameObject two;
    [SerializeField] protected GameObject three;
    [SerializeField] protected GameObject finish;
    [SerializeField] protected GameObject start;


    [SerializeField] protected float gameTimer;
    protected float startTimer = 4;



    [SerializeField] protected TextMeshProUGUI timetext;//時間テキスト

    protected bool stop;

    //ゲーム終了のカウントダウン
    public void FinishUI(GameObject one, GameObject two, GameObject three, GameObject finish)
    {
        switch (gameTimer)
        {
            case <= -2:
                finish.SetActive(false);
                break;
            case <= 1:
                one.SetActive(false);
                finish.SetActive(true);
                break;
            case <= 2:
                two.SetActive(false);
                one.SetActive(true);
                break;
            case <= 3:
                three.SetActive(false);
                two.SetActive(true);
                break;
            case <= 4:
                three.SetActive(true);
                break;
        }
    }

    //ゲーム開始のカウントダウン
    public bool StartUI( GameObject one, GameObject two, GameObject three, GameObject start)
    {
        if (startTimer >= -1) startTimer -= Time.deltaTime;

        switch (startTimer)
        {
            case < -1:
                start.SetActive(false);
                break;
            case <= 1:
                one.SetActive(false);
                start.SetActive(true);
                break;
            case <= 2:
                two.SetActive(false);
                one.SetActive(true);
                break;
            case <= 3:
                three.SetActive(false);
                two.SetActive(true);
                break;
            case <= 4:
                three.SetActive(true);
                break;
        }
        if (startTimer >= 0) return false;

        return true;
    }
    //タイマーの処理
    public void DownTimer(TextMeshProUGUI timetext, bool stop)
    {
        int minuts = Mathf.FloorToInt(gameTimer / 60);
        int seconds = Mathf.FloorToInt(gameTimer % 60);

        gameTimer -= Time.fixedDeltaTime;

        if (gameTimer > 0 && !stop)
        {
            timetext.text = string.Format("TIME:" + "{0:D2}:{1:D2}", minuts, seconds);
        }

        if (10 < gameTimer && gameTimer <= 30)
        {
            timetext.color = new Color32(255, 128, 0, 255);//オレンジ
        }
        else if (gameTimer <= 10)
        {
            timetext.color = new Color32(255, 0, 0, 255);//赤
        }
    }



    protected void SetSkill()
    {
        state Jage = state.First;
        switch (Jage)
        {
            case state.First:
                break;
            case state.ExCellent:
                break;
            case state.Perfect:
                break;
            case state.Good:
                break;
            case state.Bad:
                break;
        }

    }
}
