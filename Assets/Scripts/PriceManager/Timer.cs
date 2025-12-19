using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timer;//時間制限用
    [SerializeField] private TextMeshProUGUI timetext;//時間テキスト

    // Update is called once per frame
    void Update()
    {
        int minuts = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);
        timetext.text = string.Format("TIME:" +"{0:D2}:{1:D2}", minuts, seconds);

        if (10 < timer && timer < 30)
        {
            timetext.color = new Color32(255, 128, 0, 255);
        }
        else if (timer < 10)
        {
            timetext.color = new Color32(255, 0, 0, 255);
        }

        if (timer <= 0)
        {
            Debug.Log("gameover");
        }

        

    }
    private void FixedUpdate()
    {
        timer -= Time.fixedDeltaTime;
    }
}
