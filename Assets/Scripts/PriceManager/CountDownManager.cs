using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class CountDownManager : MonoBehaviour
{
    [SerializeField] protected GameObject one;
    [SerializeField] protected GameObject two;
    [SerializeField] protected GameObject three;
    [SerializeField] protected GameObject finish;
    [SerializeField] protected GameObject start;


    [SerializeField] protected float gameTimer;
    protected float startTimer = 4;



    [SerializeField] protected TextMeshProUGUI timetext;//時間テキスト


    [SerializeField] protected GameObject countdown;
    protected bool stop;

    
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

    public bool StartUI( GameObject one, GameObject two, GameObject three, GameObject start)
    {
        if (startTimer >= 0) startTimer -= Time.deltaTime;

        switch (startTimer)
        {
            case < 0:
                start.SetActive(false);
                break;
            case < 1:
                one.SetActive(false);
                start.SetActive(true);
                break;
            case < 2:
                two.SetActive(false);
                one.SetActive(true);
                break;
            case < 3:
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
    public void DownTimer(GameObject countdown, TextMeshProUGUI timetext, bool stop)
    {
        int minuts = Mathf.FloorToInt(gameTimer / 60);
        int seconds = Mathf.FloorToInt(gameTimer % 60);
        if (!countdown.activeSelf)
        {
            gameTimer -= Time.fixedDeltaTime;
        }

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
}
