using UnityEngine;
using UnityEngine.UI;

public class DropMoney : MonoBehaviour
{
    public static DropMoney instance;
    [SerializeField]
    private Somethings_State Speed_State;
    [SerializeField, Header("小銭の種類")]
    private UI Kindofsmallmoney;
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
        if (Amount >= 220)
        {
            Speed_State.speed = Somethings_State.Speed.TooFast;
        }
        else if (Amount>=180)
        {
            Speed_State.speed = Somethings_State.Speed.Fast;
        }
        else if (Amount>=120)
        {
            Speed_State.speed = Somethings_State.Speed.Soso;
        }
        else if(Amount>=70)
        {
            Speed_State.speed = Somethings_State.Speed.Slow;
        }
        else if (Amount<=40)
        {
             Speed_State.speed = Somethings_State.Speed.TooSlow;
        }
        switch (Speed_State.speed)
        {
            case Somethings_State.Speed.TooFast:
                if (Amount >= 220)
                {
                    //500円玉
                    Instantiate(Kindofsmallmoney.Kindofsmallmoney[0], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                }
                else if (Amount >= 200)
                {
                    int rnd = Random.Range(0, 2);
                    if (rnd == 0)
                    {
                        //500円玉
                        Instantiate(Kindofsmallmoney.Kindofsmallmoney[0], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                    }
                    else
                    {
                        //100円玉
                        Instantiate(Kindofsmallmoney.Kindofsmallmoney[1], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                    }
                }
                else
                {
                    //100円玉
                    Instantiate(Kindofsmallmoney.Kindofsmallmoney[1], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                }
                break;
            case Somethings_State.Speed.Fast:
                if (Amount >= 180)
                {
                    //100円玉
                    Instantiate(Kindofsmallmoney.Kindofsmallmoney[1], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                }
                else if (Amount >= 160)
                {
                    int rnd = Random.Range(0, 2);
                    if (rnd == 0)
                    {
                        //100円玉
                        Instantiate(Kindofsmallmoney.Kindofsmallmoney[1], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                    }
                    else
                    {
                        //50円玉
                        Instantiate(Kindofsmallmoney.Kindofsmallmoney[2], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                    }
                }
                else
                {
                    //50円玉
                    Instantiate(Kindofsmallmoney.Kindofsmallmoney[2], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                }
                break;
            case Somethings_State.Speed.Soso:
                if(Amount>=120)
                {
                    //50円玉
                    Instantiate(Kindofsmallmoney.Kindofsmallmoney[2],Gama.transform.position - new Vector3(0.0f,10.0f,0.0f),Quaternion.identity);
                }
                else if(Amount>=110)
                {
                    int rnd = Random.Range(0,2);
                    if(rnd==0)
                    {
                        //50円玉
                        Instantiate(Kindofsmallmoney.Kindofsmallmoney[2], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                    }
                    else
                    {
                        //10円玉
                        Instantiate(Kindofsmallmoney.Kindofsmallmoney[3], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                    }
                }
                else
                {
                    //10円玉
                    Instantiate(Kindofsmallmoney.Kindofsmallmoney[3], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                }
                    break;
            case Somethings_State.Speed.Slow:
                if(Amount>=80)
                {
                    //10円玉
                    Instantiate(Kindofsmallmoney.Kindofsmallmoney[3], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                }
                else if(Amount >= 70)
                {
                    int rnd = Random.Range(0, 2);
                    if (rnd == 0)
                    {
                        //10円玉
                        Instantiate(Kindofsmallmoney.Kindofsmallmoney[3], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                    }
                    else
                    {
                        //5円玉
                        Instantiate(Kindofsmallmoney.Kindofsmallmoney[4], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                    }
                }
                else
                {
                    //5円玉
                    Instantiate(Kindofsmallmoney.Kindofsmallmoney[4], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                }
                    break;
            case Somethings_State.Speed.TooSlow:
                if (Amount <= 40)
                {
                    //5円玉
                    Instantiate(Kindofsmallmoney.Kindofsmallmoney[4], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                }
                else if (Amount <= 20)
                {
                    int rnd = Random.Range(0, 2);
                    if (rnd == 0)
                    {
                        //5円玉
                        Instantiate(Kindofsmallmoney.Kindofsmallmoney[4], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                    }
                    else
                    {
                        //1円玉
                        Instantiate(Kindofsmallmoney.Kindofsmallmoney[5], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                    }
                }
                else
                {
                    //1円玉
                    Instantiate(Kindofsmallmoney.Kindofsmallmoney[5], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                }
                break;
        }

    }
}
