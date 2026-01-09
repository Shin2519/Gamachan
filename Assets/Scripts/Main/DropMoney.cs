using UnityEngine;
using UnityEngine.UI;

public class DropMoney : MonoBehaviour
{
    public static DropMoney instance;
    enum Speed
    {
        TooFast,
        Fast,
        Soso,
        Slow,
        TooSlow
    }
    [SerializeField,Header("速さの判定")]
    private Speed speed;
    [SerializeField, Header("小銭の種類")]
    private GameObject[] Mny;
    [SerializeField, Header("ガマちゃん")]
    private GameObject Gama;
    void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KindofMoney(float Amount)
    {
        if (Amount <= 0) return;
        if (Amount >= 200)
        {
            speed = Speed.TooFast;
        }
        else if (Amount>=160)
        {
            speed = Speed.Fast;
        }
        else if (Amount>=100)
        {
            speed = Speed.Soso;
        }
        else if(Amount>=50)
        {
            speed = Speed.Slow;
        }
        else if (Amount<=20)
        {
             speed=Speed.TooSlow;
        }
        switch (speed)
        {

            case Speed.TooFast:
                if (Amount >= 200)
                {
                    //500円玉
                    Instantiate(Mny[0], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                }
                else if (Amount >= 180)
                {
                    int rnd = Random.Range(0, 2);
                    if (rnd == 0)
                    {
                        //500円玉
                        Instantiate(Mny[0], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                    }
                    else
                    {
                        //100円玉
                        Instantiate(Mny[1], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                    }
                }
                else
                {
                    //100円玉
                    Instantiate(Mny[1], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                }
                break;
            case Speed.Fast:
                if (Amount >= 160)
                {
                    //100円玉
                    Instantiate(Mny[1], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                }
                else if (Amount >= 140)
                {
                    int rnd = Random.Range(0, 2);
                    if (rnd == 0)
                    {
                        //100円玉
                        Instantiate(Mny[1], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                    }
                    else
                    {
                        //50円玉
                        Instantiate(Mny[2], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                    }
                }
                else
                {
                    //50円玉
                    Instantiate(Mny[2], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                }
                break;
            case Speed.Soso:
                if(Amount>=130)
                {
                    //50円玉
                    Instantiate(Mny[2],Gama.transform.position - new Vector3(0.0f,10.0f,0.0f),Quaternion.identity);
                }
                else if(Amount>=120)
                {
                    int rnd = Random.Range(0,2);
                    if(rnd==0)
                    {
                        //50円玉
                        Instantiate(Mny[2], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                    }
                    else
                    {
                        //10円玉
                        Instantiate(Mny[3], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                    }
                }
                else
                {
                    //10円玉
                    Instantiate(Mny[3], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                }
                    break;
            case Speed.Slow:
                if(Amount>=80)
                {
                    //10円玉
                    Instantiate(Mny[3], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                }
                else if(Amount >= 70)
                {
                    int rnd = Random.Range(0, 2);
                    if (rnd == 0)
                    {
                        //10円玉
                        Instantiate(Mny[3], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                    }
                    else
                    {
                        //5円玉
                        Instantiate(Mny[4], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                    }
                }
                else
                {
                    //5円玉
                    Instantiate(Mny[4], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                }
                    break;
            case Speed.TooSlow:
                if (Amount <= 20)
                {
                    //5円玉
                    Instantiate(Mny[4], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                }
                else if (Amount <= 10)
                {
                    int rnd = Random.Range(0, 2);
                    if (rnd == 0)
                    {
                        //5円玉
                        Instantiate(Mny[4], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                    }
                    else
                    {
                        //1円玉
                        Instantiate(Mny[5], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                    }
                }
                else if(Amount <= 5)
                {
                    //1円玉
                    Instantiate(Mny[5], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                }
                break;
        }

    }
}
