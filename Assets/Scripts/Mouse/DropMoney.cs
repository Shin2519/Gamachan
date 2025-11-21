using UnityEngine;
using UnityEngine.UI;

public class DropMoney : MonoBehaviour
{
    public static DropMoney instance;

    enum Speed
    {
        Fast,
        Soso,
        Slow
    }
    [SerializeField,Header("速さの判定")]
    private Speed speed;
    [SerializeField, Header("小銭の種類")]
    private GameObject[] Mny;
    [SerializeField, Header("ガマちゃん")]
    private Transform Gama;
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
        if (Amount>=100)
        {
            speed = Speed.Fast;
        }
        else if(Amount>=50)
        {
            speed = Speed.Soso;
        }
        else if (Amount<=20)
        {
             speed=Speed.Slow;
        }
        switch (speed)
        {
            case Speed.Fast:
                if(Amount>=130)
                {
                    Instantiate(Mny[0], Gama.position, Quaternion.identity);
                }
                else if(Amount>=120)
                {
                    int rnd = Random.Range(0,2);
                    if(rnd==0)
                    {
                        //500円玉
                        GameObject coin = Instantiate(Mny[0], Gama.position, Quaternion.identity);
                        RectTransform coin_pos = coin.GetComponentInChildren<RectTransform>();
                        coin_pos.position = Gama.position;
                    }
                    else
                    {
                        //100円玉
                        Instantiate(Mny[1], Gama.position, Quaternion.identity);
                    }
                }
                else
                {
                    //100円玉
                    Instantiate(Mny[1], Gama.position, Quaternion.identity);
                }
                    break;
            case Speed.Soso:
                if(Amount>=80)
                {
                    //100円玉
                    Instantiate(Mny[1], Gama.position, Quaternion.identity);
                    Debug.Log(Speed.Soso);
                }
                else if(Amount >= 70)
                {
                    int rnd = Random.Range(0, 2);
                    if (rnd == 0)
                    {
                        //100円玉
                        Instantiate(Mny[1], Gama.position, Quaternion.identity);
                    }
                    else
                    {
                        //50円玉
                        Instantiate(Mny[2], Gama.position, Quaternion.identity);
                    }
                }
                else
                {
                    Instantiate(Mny[2], Gama.position, Quaternion.identity);
                }
                    break;
            case Speed.Slow:
                if (Amount <= 20)
                {
                    //100円玉
                    Instantiate(Mny[2], Gama.position, Quaternion.identity);
                }
                else if (Amount <= 10)
                {
                    int rnd = Random.Range(0, 2);
                    if (rnd == 0)
                    {
                        //100円玉
                        Instantiate(Mny[2], Gama.position, Quaternion.identity);
                    }
                    else
                    {
                        //50円玉
                        Instantiate(Mny[3], Gama.position, Quaternion.identity);
                    }
                }
                else if(Amount <= 5)
                {
                    Instantiate(Mny[3], Gama.position, Quaternion.identity);
                }
                break;
        }

    }
}
