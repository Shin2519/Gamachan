using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DropMoney : MonoBehaviour
{
    public static DropMoney instance;
    [SerializeField]
    private Somethings_State Speed_State;
    [SerializeField, Header("小銭の種類")]
    private UI Kindofsmallmoney;
    [SerializeField, Header("ガマちゃん")]
    private GameObject Gama;

    GameObject[] smallmoney_500 = new GameObject[20];
    GameObject[] smallmoney_100 = new GameObject[20];
    GameObject[] smallmoney_50 = new GameObject[20];
    GameObject[] smallmoney_10 = new GameObject[20];
    GameObject[] smallmoney_5 = new GameObject[20];
    GameObject[] smallmoney_1 = new GameObject[20];
    void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i = 0;i < 20;i++)
        {
            smallmoney_500[i] = Instantiate(Kindofsmallmoney.Kindofsmallmoney[0], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
            smallmoney_500[i].SetActive(false);
            smallmoney_100[i] = Instantiate(Kindofsmallmoney.Kindofsmallmoney[1], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
            smallmoney_100[i].SetActive(false);
            smallmoney_50[i] = Instantiate(Kindofsmallmoney.Kindofsmallmoney[2], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
            smallmoney_50[i].SetActive(false);
            smallmoney_10[i] = Instantiate(Kindofsmallmoney.Kindofsmallmoney[3], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
            smallmoney_10[i].SetActive(false);
            smallmoney_5[i] = Instantiate(Kindofsmallmoney.Kindofsmallmoney[4], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
            smallmoney_5[i].SetActive(false);
            smallmoney_1[i] = Instantiate(Kindofsmallmoney.Kindofsmallmoney[5], Gama.transform.position - new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
            smallmoney_1[i].SetActive(false);
        }
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
                    for (int i = 0;i < 20;i++)
                    {
                        if (!smallmoney_500[i].activeInHierarchy)
                        {
                            smallmoney_500[i].SetActive(true);
                            smallmoney_500[i].transform.position = Gama.transform.position - new Vector3(0.0f,-10.0f,0.0f);
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                else if (Amount >= 200)
                {
                    int rnd = Random.Range(0, 2);
                    if (rnd == 0)
                    {
                        //500円玉
                        for (int i = 0; i < 20; i++)
                        {
                            if (!smallmoney_500[i].activeInHierarchy)
                            {
                                smallmoney_500[i].SetActive(true);
                                smallmoney_500[i].transform.position = Gama.transform.position - new Vector3(0.0f, -10.0f, 0.0f);

                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                    else
                    {
                        //100円玉
                        for (int i = 0; i < 20; i++)
                        {
                            if (!smallmoney_100[i].activeInHierarchy)
                            {
                                smallmoney_100[i].SetActive(true);
                                smallmoney_100[i].transform.position = Gama.transform.position - new Vector3(0.0f, -10.0f, 0.0f);

                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                }
                else
                {
                    //100円玉
                    for (int i = 0; i < 20; i++)
                    {
                        if (!smallmoney_100[i].activeInHierarchy)
                        {
                            smallmoney_100[i].SetActive(true);
                            smallmoney_100[i].transform.position = Gama.transform.position - new Vector3(0.0f, -10.0f, 0.0f);
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                break;
            case Somethings_State.Speed.Fast:
                if (Amount >= 180)
                {
                    //100円玉
                    for (int i = 0; i < 20; i++)
                    {
                        if (!smallmoney_100[i].activeInHierarchy)
                        {
                            smallmoney_100[i].SetActive(true);
                            smallmoney_100[i].transform.position = Gama.transform.position - new Vector3(0.0f, -10.0f, 0.0f);
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                else if (Amount >= 160)
                {
                    int rnd = Random.Range(0, 2);
                    if (rnd == 0)
                    {
                        //100円玉
                        for (int i = 0; i < 20; i++)
                        {
                            if (!smallmoney_100[i].activeInHierarchy)
                            {
                                smallmoney_100[i].SetActive(true);
                                smallmoney_100[i].transform.position = Gama.transform.position - new Vector3(0.0f, -10.0f, 0.0f);
                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                    else
                    {
                        //50円玉
                        for (int i = 0; i < 20; i++)
                        {
                            if (!smallmoney_50[i].activeInHierarchy)
                            {
                                smallmoney_50[i].SetActive(true);
                                smallmoney_50[i].transform.position = Gama.transform.position - new Vector3(0.0f, -10.0f, 0.0f);
                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                }
                else
                {
                    //50円玉
                    for (int i = 0; i < 20; i++)
                    {
                        if (!smallmoney_50[i].activeInHierarchy)
                        {
                            smallmoney_50[i].SetActive(true);
                            smallmoney_50[i].transform.position = Gama.transform.position - new Vector3(0.0f, -10.0f, 0.0f);
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                break;
            case Somethings_State.Speed.Soso:
                if(Amount>=120)
                {
                    //50円玉
                    for (int i = 0; i < 20; i++)
                    {
                        if (!smallmoney_50[i].activeInHierarchy)
                        {
                            smallmoney_50[i].SetActive(true);
                            smallmoney_50[i].transform.position = Gama.transform.position - new Vector3(0.0f, -10.0f, 0.0f);
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                else if(Amount>=110)
                {
                    int rnd = Random.Range(0,2);
                    if(rnd==0)
                    {
                        //50円玉
                        for (int i = 0; i < 20; i++)
                        {
                            if (!smallmoney_50[i].activeInHierarchy)
                            {
                                smallmoney_50[i].SetActive(true);
                                smallmoney_50[i].transform.position = Gama.transform.position - new Vector3(0.0f, -10.0f, 0.0f);
                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                    else
                    {
                        //10円玉
                        for (int i = 0; i < 20; i++)
                        {
                            if (!smallmoney_10[i].activeInHierarchy)
                            {
                                smallmoney_10[i].SetActive(true);
                                smallmoney_10[i].transform.position = Gama.transform.position - new Vector3(0.0f, -10.0f, 0.0f);
                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                }
                else
                {
                    //10円玉
                    for (int i = 0; i < 20; i++)
                    {
                        if (!smallmoney_10[i].activeInHierarchy)
                        {
                            smallmoney_10[i].SetActive(true);
                            smallmoney_10[i].transform.position = Gama.transform.position - new Vector3(0.0f, -10.0f, 0.0f);
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                    break;
            case Somethings_State.Speed.Slow:
                if(Amount>=80)
                {
                    //10円玉
                    for (int i = 0; i < 20; i++)
                    {
                        if (!smallmoney_10[i].activeInHierarchy)
                        {
                            smallmoney_10[i].SetActive(true);
                            smallmoney_10[i].transform.position = Gama.transform.position - new Vector3(0.0f, -10.0f, 0.0f);
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                else if(Amount >= 70)
                {
                    int rnd = Random.Range(0, 2);
                    if (rnd == 0)
                    {
                        //10円玉
                        for (int i = 0; i < 20; i++)
                        {
                            if (!smallmoney_10[i].activeInHierarchy)
                            {
                                smallmoney_10[i].SetActive(true);
                                smallmoney_10[i].transform.position = Gama.transform.position - new Vector3(0.0f, -10.0f, 0.0f);
                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                    else
                    {
                        //5円玉
                        for (int i = 0; i < 20; i++)
                        {
                            if (!smallmoney_5[i].activeInHierarchy)
                            {
                                smallmoney_5[i].SetActive(true);
                                smallmoney_5[i].transform.position = Gama.transform.position - new Vector3(0.0f, -10.0f, 0.0f);
                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                }
                else
                {
                    //5円玉
                    for (int i = 0; i < 20; i++)
                    {
                        if (!smallmoney_5[i].activeInHierarchy)
                        {
                            smallmoney_5[i].SetActive(true);
                            smallmoney_5[i].transform.position = Gama.transform.position - new Vector3(0.0f, -10.0f, 0.0f);
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                    break;
            case Somethings_State.Speed.TooSlow:
                if (Amount <= 40)
                {
                    //5円玉
                    for (int i = 0; i < 20; i++)
                    {
                        if (!smallmoney_5[i].activeInHierarchy)
                        {
                            smallmoney_5[i].SetActive(true);
                            smallmoney_5[i].transform.position = Gama.transform.position - new Vector3(0.0f, -10.0f, 0.0f);
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                else if (Amount <= 20)
                {
                    int rnd = Random.Range(0, 2);
                    if (rnd == 0)
                    {
                        //5円玉
                        for (int i = 0; i < 20; i++)
                        {
                            if (!smallmoney_5[i].activeInHierarchy)
                            {
                                smallmoney_5[i].SetActive(true);
                                smallmoney_5[i].transform.position = Gama.transform.position - new Vector3(0.0f, -10.0f, 0.0f);
                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                    else
                    {
                        //1円玉
                        for (int i = 0; i < 20; i++)
                        {
                            if (!smallmoney_1[i].activeInHierarchy)
                            {
                                smallmoney_1[i].SetActive(true);
                                smallmoney_1[i].transform.position = Gama.transform.position - new Vector3(0.0f, -10.0f, 0.0f);
                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                }
                else
                {
                    //1円玉
                    for (int i = 0; i < 20; i++)
                    {
                        if (!smallmoney_1[i].activeInHierarchy)
                        {
                            smallmoney_1[i].SetActive(true);
                            smallmoney_1[i].transform.position = Gama.transform.position - new Vector3(0.0f, -10.0f, 0.0f);
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                break;
        }

    }
}
