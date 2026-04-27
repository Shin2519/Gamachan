using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : CountDownManager
{


    void Update()
    {
        base.StartUI(one, two, three, start);
        base.FinishUI(one, two, three, finish);

    }
    private void FixedUpdate()
    { 
        

        if (StartUI(one, two, three, start))
        {
            base.DownTimer(countdown, timetext, stop);
        }
        
        
    }
}
