using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : UIManager
{
    [SerializeField] private TextMeshProUGUI inputamounttext;
    private void Start()
    {
        int minuts = Mathf.FloorToInt(gameTimer / 60);
        int seconds = Mathf.FloorToInt(gameTimer % 60);
        timetext.text= string.Format("TIME:" + "{0:D2}:{1:D2}", minuts, seconds);

        goodscanvas.SetActive(false);

        StartCoroutine(StartTimer());
        
    }

    void Update()
    {
        inputamounttext.text = ProbabilityManager.TotalMoney(ProbabilityManager.coin).ToString() + "‰~";
        if (gameTimer <= 0)
        {
            result.SetActive(true);
            ScoreCalculator.Instance.CalculateChallenge(ProbabilityManager.gradecount, ChooseGoods.Instance.Combo, ProbabilityManager.coin, ProbabilityManager.AM);
            
        }
    }
    private void FixedUpdate()
    {
        DownTimer();
        
    }
}
