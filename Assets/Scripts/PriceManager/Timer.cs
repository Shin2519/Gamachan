using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MasterCode
{
    //public static Timer Instance;

    [SerializeField] private TextMeshProUGUI timetext;//時間テキスト
    [SerializeField] GameObject one;
    [SerializeField] GameObject two;
    [SerializeField] GameObject three;
    [SerializeField] GameObject finish;

    [SerializeField] GameObject countdown;
    [SerializeField] GameObject resultpanel;
    public bool stop;



    //private void Awake()
    //{
    //    Instance = this;
    //}
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
        base.DownTimer(countdown, timetext,stop);
    }
}
