using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    //ゲーム終了のカウントダウン
    public void FinishUI(GameObject one, GameObject two, GameObject three, GameObject finish)
    {
        switch (gameTimer)
        {
            case <= -2:
                
                finish.SetActive(false);
                break;
            case <= 1:
                goodscanvas.SetActive(true);
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
    public IEnumerator StartTimer()
    {
        Image sprite = image.GetComponent<Image>();
    

        while(startTimer>-1)
        {
            sprite.sprite = sprites[startTimer];
            startTimer--;
            yield return new WaitForSeconds(1);
        }
        yield return new WaitForSeconds(1);
        sprite.sprite = sprites[3];
        yield return new WaitForSeconds(1);

        goodscanvas.SetActive(true);
        image.SetActive(false);
        stop = false;
    }

    //ゲーム開始のカウントダウン
    public bool StartUI( GameObject one, GameObject two, GameObject three, GameObject start)
    {
        
        if (startTimer >= 0) return false;

        return true;
    }
    //タイマーの処理
    public void DownTimer()
    {
        int minuts = Mathf.FloorToInt(gameTimer / 60);
        int seconds = Mathf.FloorToInt(gameTimer % 60);

        

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
