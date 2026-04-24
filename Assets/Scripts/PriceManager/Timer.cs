using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : CountDownManager
{
    //public static Timer Instance;

   


    private void Start()
    {
        stop = false;
        one.SetActive(false);
        two.SetActive(false);
        three.SetActive(false);
        finish.SetActive(false);

    }

    void Update()
    {
        base.CountDownUI(one, two, three, finish);
    }
    private void FixedUpdate()
    {
        gameTimer -= Time.deltaTime;
        base.DownTimer(countdown, timetext,stop);
    }
}
