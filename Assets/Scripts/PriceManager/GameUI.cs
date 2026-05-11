using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI inputamounttext;


    [SerializeField] protected GameObject goodscanvas;

    public float gameTimer;
    
    [SerializeField] protected TextMeshProUGUI timetext;//時間テキスト

    protected bool stop = true;

    private bool finishstop = true;
    [SerializeField] Sprite[] startsprites;
    [SerializeField] Sprite[] finishsprites;

    [SerializeField] GameObject image;

    [SerializeField] private GameObject resultpanel;
    private void Start()
    {
        int minuts = Mathf.FloorToInt(gameTimer / 60);
        int seconds = Mathf.FloorToInt(gameTimer % 60);
        timetext.text= string.Format("TIME:" + "{0:D2}:{1:D2}", minuts, seconds);

        goodscanvas.SetActive(false);

        StartCoroutine(StartTimer());

        resultpanel.SetActive(false);
    }
    IEnumerator StartTimer()
    {
        Image sprite = image.GetComponent<Image>();
        int startTimer = 2;
        while (startTimer > -1)
        {
            sprite.sprite = startsprites[startTimer];
            startTimer--;
            yield return new WaitForSeconds(1);
        }
        sprite.sprite = startsprites[3];
        yield return new WaitForSeconds(1);

        goodscanvas.SetActive(true);
        image.SetActive(false);
        stop = false;
    }

    IEnumerator FinishTimer()
    {
        finishstop = false;
        Image sprite = image.GetComponent<Image>();
        int timer = 2;
        image.SetActive(true);
        while(timer > -1)
        {
            sprite.sprite = finishsprites[timer];
            timer--;
            yield return new WaitForSeconds(1);
        }
        sprite.sprite = finishsprites[3];
        
        yield return new WaitForSeconds(1);
        image.SetActive(false);
        resultpanel.SetActive(true);
    }

    void Update()
    {
        inputamounttext.text = ProbabilityManager.TotalMoney(ProbabilityManager.coin).ToString() + "円";
        if (gameTimer <= 4 && finishstop) StartCoroutine(FinishTimer());
    }
    private void FixedUpdate()
    {
        int minuts = Mathf.FloorToInt(gameTimer / 60);
        int seconds = Mathf.FloorToInt(gameTimer % 60);
        if (gameTimer == 3) StartCoroutine(FinishTimer());
        if (gameTimer > 0 && !stop)
        {
            timetext.text = string.Format("TIME:" + "{0:D2}:{1:D2}", minuts, seconds);
            gameTimer -= Time.fixedDeltaTime;
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
