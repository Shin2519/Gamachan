using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoodsTimer : MonoBehaviour
{
    [SerializeField] float timer;//時間制限用
    [SerializeField] private TextMeshProUGUI timetext;//時間テキスト

    [SerializeField] GameObject one;
    [SerializeField] GameObject two;
    [SerializeField] GameObject three;
    public bool stop;
    [SerializeField] GameObject goods;
    private void Start()
    {
        stop = false;
        one.SetActive(false);
        two.SetActive(false);
        three.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (30>= timer && timer >10)
        {
            timetext.color = new Color32(255, 128, 0, 255);//オレンジ
        }
        else if (timer <= 10)
        {
            timetext.color = new Color32(255, 0, 0, 255);//赤
        }



        if (!stop)
        {
            if (timer < 4 && timer >= 3)
            {
                three.SetActive(true);
            }
            else if (timer < 3 && timer >= 2)
            {
                three.SetActive(false);
                two.SetActive(true);
            }
            else if (timer < 2 && timer >= 1)
            {
                two.SetActive(false);
                one.SetActive(true);
            }
            else if (timer < 1 && timer >= 0)
            {
                one.SetActive(false);
                UIManagement.instance.Finishistrue();
            }
            else if (timer <= -2)
            {
                SceneManager.LoadScene("Resultpanel");
            }
        }

        

    }
    private void FixedUpdate()
    {
        int minuts = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);

        if (goods.activeSelf)
        {
            timer -= Time.fixedDeltaTime;
        }

        if (timer>0&&!stop)
        {
            timetext.text = string.Format("TIME:" + "{0:D2}:{1:D2}", minuts, seconds);
        }
        
    }
    private void OnEnable()
    {
        timer = 30.0f;
    }
}
