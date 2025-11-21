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
    [SerializeField, Header("親にするキャンバス")]
    private GameObject parentcanvas;
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
                    GameObject coin = Instantiate(Mny[0]);
                    coin.transform.SetParent(parentcanvas.transform, false);
                    GameObject child = coin;
                    child.transform.position = Gama.transform.position;
                }
                else if(Amount>=120)
                {
                    int rnd = Random.Range(0,2);
                    if(rnd==0)
                    {
                        //500円玉
                        GameObject coin = Instantiate(Mny[0]);
                        coin.transform.SetParent(parentcanvas.transform,false);
                        GameObject child = coin;
                        child.transform.position = Gama.transform.position;
                    }
                    else
                    {
                        //100円玉
                        GameObject coin = Instantiate(Mny[1]);
                        coin.transform.SetParent(parentcanvas.transform, false);
                        GameObject child = coin;
                        child.transform.position = Gama.transform.position;
                    }
                }
                else
                {
                    //100円玉
                    GameObject coin = Instantiate(Mny[1]);
                    coin.transform.SetParent(parentcanvas.transform, false);
                    GameObject child = coin;
                    child.transform.position = Gama.transform.position;
                }
                    break;
            case Speed.Soso:
                if(Amount>=80)
                {
                    //100円玉
                    GameObject coin = Instantiate(Mny[1]);
                    coin.transform.SetParent(parentcanvas.transform, false);
                    GameObject child = coin;
                    child.transform.position = Gama.transform.position;

                    Debug.Log(Speed.Soso);
                }
                else if(Amount >= 70)
                {
                    int rnd = Random.Range(0, 2);
                    if (rnd == 0)
                    {
                        //100円玉
                        GameObject coin = Instantiate(Mny[1]);
                        coin.transform.SetParent(parentcanvas.transform, false);
                        GameObject child = coin;
                        child.transform.position = Gama.transform.position;
                    }
                    else
                    {
                        //50円玉
                        GameObject coin = Instantiate(Mny[2]);
                        coin.transform.SetParent(parentcanvas.transform, false);
                        GameObject child = coin;
                        child.transform.position = Gama.transform.position;
                    }
                }
                else
                {
                    GameObject coin = Instantiate(Mny[2]);
                    coin.transform.SetParent(parentcanvas.transform, false);
                    GameObject child = coin;
                    child.transform.position = Gama.transform.position;
                }
                    break;
            case Speed.Slow:
                if (Amount <= 20)
                {
                    //100円玉
                    GameObject coin = Instantiate(Mny[2]);
                    coin.transform.SetParent(parentcanvas.transform, false);
                    GameObject child = coin;
                    child.transform.position = Gama.transform.position;
                }
                else if (Amount <= 10)
                {
                    int rnd = Random.Range(0, 2);
                    if (rnd == 0)
                    {
                        //100円玉
                        GameObject coin = Instantiate(Mny[2]);
                        coin.transform.SetParent(parentcanvas.transform, false);
                        GameObject child = coin;
                        child.transform.position = Gama.transform.position;
                    }
                    else
                    {
                        //50円玉
                        GameObject coin = Instantiate(Mny[3]);
                        coin.transform.SetParent(parentcanvas.transform, false);
                        GameObject child = coin;
                        child.transform.position = Gama.transform.position;
                    }
                }
                else if(Amount <= 5)
                {
                    GameObject coin = Instantiate(Mny[3]);
                    coin.transform.SetParent(parentcanvas.transform, false);
                    GameObject child = coin;
                    child.transform.position = Gama.transform.position;
                }
                break;
        }

    }
}
