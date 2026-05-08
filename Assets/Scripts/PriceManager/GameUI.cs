using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : UIManager
{
    private void Start()
    {
        int minuts = Mathf.FloorToInt(gameTimer / 60);
        int seconds = Mathf.FloorToInt(gameTimer % 60);
        timetext.text= string.Format("TIME:" + "{0:D2}:{1:D2}", minuts, seconds);
    }

    void Update()
    {
        base.StartUI(one, two, three, start);
        base.FinishUI(one, two, three, finish);

    }
    private void FixedUpdate()
    { 

        if (StartUI(one, two, three, start))
        {
            base.DownTimer(timetext, stop);
        }
        
        
    }
}
