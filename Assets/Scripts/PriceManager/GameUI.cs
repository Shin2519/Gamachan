using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class GameUI : MonoBehaviour
{
    public static GameUI instance;

    [SerializeField] private TextMeshProUGUI inputamounttext;

    [SerializeField] private GameObject goodscanvas;

    [SerializeField] private GameObject Register;

    [SerializeField] private GameObject timetext;//時間テキスト

    public float gameTimer;

    TextMeshProUGUI f_timetext_ugui;
    [SerializeField]
    Sprite[] startsprites;
    [SerializeField]
    Sprite[] finishsprites;
    [SerializeField] GameObject image;
    bool finish = true;

    [SerializeField] private GameObject result;
    [SerializeField] private GameObject ui;


    void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        int minuts = Mathf.FloorToInt(gameTimer / 60);
        int seconds = Mathf.FloorToInt(gameTimer % 60);
        f_timetext_ugui = timetext.GetComponent<TextMeshProUGUI>();
        f_timetext_ugui.text = string.Format("TIME:" + "{0:D2}:{1:D2}", minuts, seconds);

        goodscanvas.SetActive(false);

        StartCoroutine(StartTimer());

    }

    void Update()
    {
        inputamounttext.text = ProbabilityManager.TotalMoney(ProbabilityManager.coin).ToString() + "円";

        if (gameTimer <= 4 && finish) StartCoroutine(FinnishTimer());
        
    }
    private void FixedUpdate()
    {
        //int minuts = Mathf.FloorToInt(gameTimer / 60);
        //int seconds = Mathf.FloorToInt(gameTimer % 60);

        //if (gameTimer >= -1 && !stop)
        //{
        //    gameTimer -= Time.deltaTime;
        //}

        //if (gameTimer >= 0 && !stop)
        //{
        //    f_timetext_ugui = timetext.GetComponent<TextMeshProUGUI>();
        //    f_timetext_ugui.text = string.Format("TIME:" + "{0:D2}:{1:D2}", minuts, seconds);
        //}
        //if (10 < gameTimer && gameTimer <= 30)
        //{
        //    timetext.color = new Color32(255, 128, 0, 255);//オレンジ
        //}
        //else if (gameTimer <= 10)
        //{
        //    timetext.color = new Color32(255, 0, 0, 255);//赤
        //}
    }
    public IEnumerator StartTimer()
    {
        StartSetActive(false);
        int startTimer = 2;

        Image sprite = image.GetComponent<Image>();

        result.SetActive(false);

        while (startTimer > -1)
        {
            sprite.sprite = startsprites[startTimer];
            startTimer--;
            yield return new WaitForSeconds(1);
        }
        yield return null;
        sprite.sprite = startsprites[3];
        yield return new WaitForSeconds(1);
        
        goodscanvas.SetActive(true);
        image.SetActive(false);
        GameLoopManagement.Instance._Gamestate = StateMashine.GameState.GoodsSelectPhase;
        StartSetActive(true);
    }

    public IEnumerator FinnishTimer()
    {
        finish = false;
        Image sprite = image.GetComponent<Image>();
        int finishTimer = 2;
        image.SetActive(true);
        while (finishTimer > -1)
        {
            sprite.sprite = finishsprites[finishTimer];
            finishTimer--;
            yield return new WaitForSeconds(1);
        }
        sprite.sprite = finishsprites[3];
        
        yield return new WaitForSeconds(1);
        image.SetActive(false);        
        ui.SetActive(false);
        image.SetActive(false);
        ScoreCalculator.Instance.CalculateChallenge(ProbabilityManager.gradecount, ChooseGoods.Instance.Combo, ProbabilityManager.coin, ProbabilityManager.AM);
        result.SetActive(true);
    }
    void StartSetActive(bool l_active)
    {
        timetext.SetActive(l_active);
        goodscanvas.SetActive(l_active);
    }



}
