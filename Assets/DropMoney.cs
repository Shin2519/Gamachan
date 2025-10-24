using UnityEngine;

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
        if(Amount>=100)
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
                    Instantiate(Mny[0]);
                }
                else if(Amount>=120)
                {
                    int rnd = Random.Range(0,2);
                    if(rnd==0)
                    {
                        //500円玉
                    }
                    else
                    {
                        //100円玉
                    }
                }
                else
                {
                    //100円玉
                }
                    break;
            case Speed.Soso:
                if(Amount>=80)
                {
                    //100円玉
                }
                break;
            case Speed.Slow:
                break;
        }

    }
}
