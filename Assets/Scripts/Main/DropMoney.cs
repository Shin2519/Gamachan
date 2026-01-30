using UnityEngine;
using UnityEngine.UI;

public class DropMoney : MonoBehaviour
{
    public static DropMoney instance;
    [SerializeField]
    private Somethings_State Speed_State;
    [SerializeField]
    SendData send_data;
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
                    for(int i = 0;i < send_data.Money.Count;i++)
                    {
                        if (send_data.Money[i].gameObject.name=="500yen(Clone)"&&!send_data.Money[i].activeInHierarchy)
                        {
                            send_data.Money[i].SetActive(true);
                            send_data.Money[i].transform.position = Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f);
                            return;
                        }
                    }
                    //500円玉
                    GameObject obj = Instantiate(Kindofsmallmoney.Kindofsmallmoney[0], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                    send_data.Money.Add(obj);
                }
                else if (Amount >= 200)
                {
                    int rnd = Random.Range(0, 2);
                    if (rnd == 0)
                    {
                        for (int i = 0; i < send_data.Money.Count; i++)
                        {
                            if (send_data.Money[i].gameObject.name == "500yen(Clone)" && !send_data.Money[i].activeInHierarchy)
                            {
                                send_data.Money[i].SetActive(true);
                                send_data.Money[i].transform.position = Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f);
                                return;
                            }
                        }
                        //500円玉
                        GameObject obj = Instantiate(Kindofsmallmoney.Kindofsmallmoney[0], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                        send_data.Money.Add(obj);
                    }
                    else
                    {
                        for (int i = 0; i < send_data.Money.Count; i++)
                        {
                            if (send_data.Money[i].gameObject.name == "100yen(Clone)" && !send_data.Money[i].activeInHierarchy)
                            {
                                send_data.Money[i].SetActive(true);
                                send_data.Money[i].transform.position = Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f);
                                return;
                            }
                        }
                        //100円玉
                        GameObject obj = Instantiate(Kindofsmallmoney.Kindofsmallmoney[1], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                        send_data.Money.Add(obj);
                    }
                }
                else
                {
                    for (int i = 0; i < send_data.Money.Count; i++)
                    {
                        if (send_data.Money[i].gameObject.name == "100yen(Clone)" && !send_data.Money[i].activeInHierarchy)
                        {
                            send_data.Money[i].SetActive(true);
                            send_data.Money[i].transform.position = Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f);
                            return;
                        }
                    }
                    //100円玉
                    GameObject obj = Instantiate(Kindofsmallmoney.Kindofsmallmoney[1], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                    send_data.Money.Add(obj);
                }
                break;
            case Somethings_State.Speed.Fast:
                if (Amount >= 180)
                {
                    for (int i = 0; i < send_data.Money.Count; i++)
                    {
                        if (send_data.Money[i].gameObject.name == "100yen(Clone)" && !send_data.Money[i].activeInHierarchy)
                        {
                            send_data.Money[i].SetActive(true);
                            send_data.Money[i].transform.position = Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f);
                            return;
                        }
                    }
                    //100円玉
                    GameObject obj = Instantiate(Kindofsmallmoney.Kindofsmallmoney[1], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                    send_data.Money.Add(obj);
                }
                else if (Amount >= 160)
                {
                    int rnd = Random.Range(0, 2);
                    if (rnd == 0)
                    {
                        for (int i = 0; i < send_data.Money.Count; i++)
                        {
                            if (send_data.Money[i].gameObject.name == "100yen(Clone)" && !send_data.Money[i].activeInHierarchy)
                            {
                                send_data.Money[i].SetActive(true);
                                send_data.Money[i].transform.position = Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f);
                                return;
                            }
                        }
                        //100円玉
                        GameObject obj = Instantiate(Kindofsmallmoney.Kindofsmallmoney[1], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                        send_data.Money.Add(obj);
                    }
                    else
                    {
                        for (int i = 0; i < send_data.Money.Count; i++)
                        {
                            if (send_data.Money[i].gameObject.name == "50yen(Clone)" && !send_data.Money[i].activeInHierarchy)
                            {
                                send_data.Money[i].SetActive(true);
                                send_data.Money[i].transform.position = Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f);
                                return;
                            }
                        }
                        //50円玉
                        GameObject obj = Instantiate(Kindofsmallmoney.Kindofsmallmoney[2], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                        send_data.Money.Add(obj);
                    }
                }
                else
                {
                    for (int i = 0; i < send_data.Money.Count; i++)
                    {
                        if (send_data.Money[i].gameObject.name == "50yen(Clone)" && !send_data.Money[i].activeInHierarchy)
                        {
                            send_data.Money[i].SetActive(true);
                            send_data.Money[i].transform.position = Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f);
                            return;
                        }
                    }
                    //50円玉
                    GameObject obj = Instantiate(Kindofsmallmoney.Kindofsmallmoney[2], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                    send_data.Money.Add(obj);
                }
                break;
            case Somethings_State.Speed.Soso:
                if(Amount>=120)
                {
                    for (int i = 0; i < send_data.Money.Count; i++)
                    {
                        if (send_data.Money[i].gameObject.name == "50yen(Clone)" && !send_data.Money[i].activeInHierarchy)
                        {
                            send_data.Money[i].SetActive(true);
                            send_data.Money[i].transform.position = Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f);
                            return;
                        }
                    }
                    //50円玉
                    GameObject obj = Instantiate(Kindofsmallmoney.Kindofsmallmoney[2], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                    send_data.Money.Add(obj);
                }
                else if(Amount>=110)
                {
                    int rnd = Random.Range(0,2);
                    if(rnd==0)
                    {
                        for (int i = 0; i < send_data.Money.Count; i++)
                        {
                            if (send_data.Money[i].gameObject.name == "50yen(Clone)" && !send_data.Money[i].activeInHierarchy)
                            {
                                send_data.Money[i].SetActive(true);
                                send_data.Money[i].transform.position = Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f);
                                return;
                            }
                        }
                        //50円玉
                        GameObject obj = Instantiate(Kindofsmallmoney.Kindofsmallmoney[2], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                        send_data.Money.Add(obj);
                    }
                    else
                    {
                        for (int i = 0; i < send_data.Money.Count; i++)
                        {
                            if (send_data.Money[i].gameObject.name == "10yen(Clone)" && !send_data.Money[i].activeInHierarchy)
                            {
                                send_data.Money[i].SetActive(true);
                                send_data.Money[i].transform.position = Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f);
                                return;
                            }
                        }
                        //10円玉
                        GameObject obj = Instantiate(Kindofsmallmoney.Kindofsmallmoney[3], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                        send_data.Money.Add(obj);
                    }
                }
                else
                {
                    for (int i = 0; i < send_data.Money.Count; i++)
                    {
                        if (send_data.Money[i].gameObject.name == "10yen(Clone)" && !send_data.Money[i].activeInHierarchy)
                        {
                            send_data.Money[i].SetActive(true);
                            send_data.Money[i].transform.position = Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f);
                            return;
                        }
                    }
                    //10円玉
                    GameObject obj = Instantiate(Kindofsmallmoney.Kindofsmallmoney[3], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                    send_data.Money.Add(obj);
                }
                    break;
            case Somethings_State.Speed.Slow:
                if(Amount>=80)
                {
                    for (int i = 0; i < send_data.Money.Count; i++)
                    {
                        if (send_data.Money[i].gameObject.name == "10yen(Clone)" && !send_data.Money[i].activeInHierarchy)
                        {
                            send_data.Money[i].SetActive(true);
                            send_data.Money[i].transform.position = Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f);
                            return;
                        }
                    }
                    //10円玉
                    GameObject obj = Instantiate(Kindofsmallmoney.Kindofsmallmoney[3], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                    send_data.Money.Add(obj);
                }
                else if(Amount >= 70)
                {
                    int rnd = Random.Range(0, 2);
                    if (rnd == 0)
                    {
                        for (int i = 0; i < send_data.Money.Count; i++)
                        {
                            if (send_data.Money[i].gameObject.name == "10yen(Clone)" && !send_data.Money[i].activeInHierarchy)
                            {
                                send_data.Money[i].SetActive(true);
                                send_data.Money[i].transform.position = Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f);
                                return;
                            }
                        }
                        //10円玉
                        GameObject obj = Instantiate(Kindofsmallmoney.Kindofsmallmoney[3], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                        send_data.Money.Add(obj);
                    }
                    else
                    {
                        for (int i = 0; i < send_data.Money.Count; i++)
                        {
                            if (send_data.Money[i].gameObject.name == "5yen(Clone)" && !send_data.Money[i].activeInHierarchy)
                            {
                                send_data.Money[i].SetActive(true);
                                send_data.Money[i].transform.position = Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f);
                                return;
                            }
                        }
                        //5円玉
                        GameObject obj = Instantiate(Kindofsmallmoney.Kindofsmallmoney[4], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                        send_data.Money.Add(obj);
                    }
                }
                else
                {
                    for (int i = 0; i < send_data.Money.Count; i++)
                    {
                        if (send_data.Money[i].gameObject.name == "5yen(Clone)" && !send_data.Money[i].activeInHierarchy)
                        {
                            send_data.Money[i].SetActive(true);
                            send_data.Money[i].transform.position = Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f);
                            return;
                        }
                    }
                    //5円玉
                    GameObject obj = Instantiate(Kindofsmallmoney.Kindofsmallmoney[4], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                    send_data.Money.Add(obj);
                }
                    break;
            case Somethings_State.Speed.TooSlow:
                if (Amount <= 40)
                {
                    for (int i = 0; i < send_data.Money.Count; i++)
                    {
                        if (send_data.Money[i].gameObject.name == "5yen(Clone)" && !send_data.Money[i].activeInHierarchy)
                        {
                            send_data.Money[i].SetActive(true);
                            send_data.Money[i].transform.position = Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f);
                            return;
                        }
                    }
                    //5円玉
                    GameObject obj = Instantiate(Kindofsmallmoney.Kindofsmallmoney[4], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                    send_data.Money.Add(obj);
                }
                else if (Amount <= 20)
                {
                    int rnd = Random.Range(0, 2);
                    if (rnd == 0)
                    {
                        for (int i = 0; i < send_data.Money.Count; i++)
                        {
                            if (send_data.Money[i].gameObject.name == "5yen(Clone)" && !send_data.Money[i].activeInHierarchy)
                            {
                                send_data.Money[i].SetActive(true);
                                send_data.Money[i].transform.position = Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f);
                                return;
                            }
                        }
                        //5円玉
                        GameObject obj = Instantiate(Kindofsmallmoney.Kindofsmallmoney[4], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                        send_data.Money.Add(obj);
                    }
                    else
                    {
                        for (int i = 0; i < send_data.Money.Count; i++)
                        {
                            if (send_data.Money[i].gameObject.name == "1yen(Clone)" && !send_data.Money[i].activeInHierarchy)
                            {
                                send_data.Money[i].SetActive(true);
                                send_data.Money[i].transform.position = Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f);
                                return;
                            }
                        }
                        //1円玉
                        GameObject obj = Instantiate(Kindofsmallmoney.Kindofsmallmoney[5], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                        send_data.Money.Add(obj);
                    }
                }
                else
                {
                    for (int i = 0; i < send_data.Money.Count; i++)
                    {
                        if (send_data.Money[i].gameObject.name == "1yen(Clone)" && !send_data.Money[i].activeInHierarchy)
                        {
                            send_data.Money[i].SetActive(true);
                            send_data.Money[i].transform.position = Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f);
                            return;
                        }
                    }
                    //1円玉
                    GameObject obj = Instantiate(Kindofsmallmoney.Kindofsmallmoney[5], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
                    send_data.Money.Add(obj);
                }
                break;
        }

    }
}
