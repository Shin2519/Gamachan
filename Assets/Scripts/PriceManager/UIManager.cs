using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static ProbabilityManager;

public class UIManager : MonoBehaviour
{
    [SerializeField] protected GameObject goodscanvas;

    public float gameTimer;
    protected int startTimer = 2;
    [SerializeField] protected TextMeshProUGUI timetext;//時間テキスト

    protected bool stop = true;

    [SerializeField]
    Sprite[] sprites;
    [SerializeField] GameObject image;

    [SerializeField] protected GameObject result;
    public IEnumerator StartTimer()
    {
        Image sprite = image.GetComponent<Image>();

        result.SetActive(false);

        while(startTimer>-1)
        {
            sprite.sprite = sprites[startTimer];
            startTimer--;
            yield return new WaitForSeconds(1);
        }
        yield return null;
        sprite.sprite = sprites[3];
        yield return new WaitForSeconds(1);

        goodscanvas.SetActive(true);
        image.SetActive(false);
        stop = false;
    }
    //タイマーの処理
    public void DownTimer()
    {
        int minuts = Mathf.FloorToInt(gameTimer / 60);
        int seconds = Mathf.FloorToInt(gameTimer % 60);

        if (gameTimer >= -1 && !stop)
        {
            gameTimer -= Time.deltaTime;
        }

        if (gameTimer >= 0 && !stop)
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