using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DropMoney : MonoBehaviour
{
    public static DropMoney instance;
    [SerializeField]
    private Somethings_State Speed_State;
    [SerializeField,Header("小銭の種類")]
    private UI Kindofsmallmoney;
    [SerializeField,Header("ガマちゃん")]
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
    IEnumerator Start()
    {
        for (int i = 0; i < 10; i++)
        {
            smallmoney_500[i] = Instantiate(Kindofsmallmoney.Kindofsmallmoney[0],new Vector3(1000.0f, 1000.0f, 0.0f), Quaternion.identity);
            smallmoney_500[i].GetComponent<Collider2D>().enabled = false;
            smallmoney_500[i].SetActive(false);
            yield return null;
            smallmoney_100[i] = Instantiate(Kindofsmallmoney.Kindofsmallmoney[1], new Vector3(1000.0f, 1000.0f, 0.0f), Quaternion.identity);
            smallmoney_100[i].GetComponent<Collider2D>().enabled = false;
            smallmoney_100[i].SetActive(false);
            yield return null;
            smallmoney_50[i] = Instantiate(Kindofsmallmoney.Kindofsmallmoney[2], new Vector3(1000.0f, 1000.0f, 0.0f), Quaternion.identity);
            smallmoney_50[i].GetComponent<Collider2D>().enabled = false;
            smallmoney_50[i].SetActive(false);
            yield return null;
            smallmoney_10[i] = Instantiate(Kindofsmallmoney.Kindofsmallmoney[3], new Vector3(1000.0f, 1000.0f, 0.0f), Quaternion.identity);
            smallmoney_10[i].GetComponent<Collider2D>().enabled = false;
            smallmoney_10[i].SetActive(false);
            yield return null;
            smallmoney_5[i] = Instantiate(Kindofsmallmoney.Kindofsmallmoney[4], new Vector3(1000.0f, 1000.0f, 0.0f), Quaternion.identity);
            smallmoney_5[i].GetComponent<Collider2D>().enabled = false;
            smallmoney_5[i].SetActive(false);
            yield return null;
            smallmoney_1[i] = Instantiate(Kindofsmallmoney.Kindofsmallmoney[5], new Vector3(1000.0f, 1000.0f, 0.0f), Quaternion.identity);
            smallmoney_1[i].GetComponent<Collider2D>().enabled = false;
            smallmoney_1[i].SetActive(false);
            yield return null;
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
                TOOFAST(Amount);
                break;
            case Somethings_State.Speed.Fast:
                FAST(Amount);
                break;
            case Somethings_State.Speed.Soso:
                SOSO(Amount);
                break;
            case Somethings_State.Speed.Slow:
                SLOW(Amount);
                break;
            case Somethings_State.Speed.TooSlow:
                TOOSLOW(Amount);
                break;
        }
    }

    void Money_500()
    {
        for (int i = 0; i < smallmoney_500.Length; i++)
        {
            if (!smallmoney_500[i].activeInHierarchy)
            {
                smallmoney_500[i].SetActive(true);
                smallmoney_500[i].GetComponent<Collider2D>().enabled = true;
                smallmoney_500[i].transform.position = Gama.transform.position - new Vector3(0.0f, -10.0f, 0.0f);
                return;
            }
        }
    }

    void Money_100()
    {
        for (int i = 0; i < smallmoney_100.Length; i++)
        {
            if (!smallmoney_100[i].activeInHierarchy)
            {
                smallmoney_100[i].SetActive(true);
                smallmoney_100[i].GetComponent<Collider2D>().enabled = true;
                smallmoney_100[i].transform.position = Gama.transform.position - new Vector3(0.0f, -10.0f, 0.0f);
                return;
            }
        }
    }

    void Money_50()
    {
        for (int i = 0; i < smallmoney_50.Length; i++)
        {
            if (!smallmoney_50[i].activeInHierarchy)
            {
                smallmoney_50[i].SetActive(true);
                smallmoney_50[i].GetComponent<Collider2D>().enabled = true;
                smallmoney_50[i].transform.position = Gama.transform.position - new Vector3(0.0f, -10.0f, 0.0f);
                return;
            }
        }
    }

    void Money_10()
    {
        for (int i = 0; i < smallmoney_10.Length; i++)
        {
            if (!smallmoney_10[i].activeInHierarchy)
            {
                smallmoney_10[i].SetActive(true);
                smallmoney_10[i].GetComponent<Collider2D>().enabled = true;
                smallmoney_10[i].transform.position = Gama.transform.position - new Vector3(0.0f, -10.0f, 0.0f);
                return;
            }
        }
    }

    void Money_5()
    {
        for (int i = 0; i < smallmoney_5.Length; i++)
        {
            if (!smallmoney_5[i].activeInHierarchy)
            {
                smallmoney_5[i].SetActive(true);
                smallmoney_5[i].GetComponent<Collider2D>().enabled = true;
                smallmoney_5[i].transform.position = Gama.transform.position - new Vector3(0.0f, -10.0f, 0.0f);
                return;
            }
        }
    }

    void Money_1()
    {
        for (int i = 0; i < smallmoney_1.Length; i++)
        {
            if (!smallmoney_1[i].activeInHierarchy)
            {
                smallmoney_1[i].SetActive(true);
                smallmoney_1[i].GetComponent<Collider2D>().enabled = true;
                smallmoney_1[i].transform.position = Gama.transform.position - new Vector3(0.0f, -10.0f, 0.0f);
                return;
            }
        }
    }

    void TOOFAST(float Amount)
    {
        if (Amount >= 220)
        {
            Money_500();
        }
        else if (Amount >= 200)
        {
            int rnd = Random.Range(0, 2);
            if (rnd == 0)
            {
                Money_500();
            }
            else
            {
                Money_100();
            }
        }
        else
        {
            Money_100();
        }
    }

    void FAST(float Amount)
    {
        if (Amount >= 180)
        {
            Money_100();
        }
        else if (Amount >= 160)
        {
            int rnd = Random.Range(0, 2);
            if (rnd == 0)
            {
                Money_100();
            }
            else
            {
                Money_50();
            }
        }
        else
        {
            Money_50();
        }
    }

    void SOSO(float Amount)
    {
        if (Amount >= 120)
        {
            Money_50();
        }
        else if (Amount >= 110)
        {
            int rnd = Random.Range(0, 2);
            if (rnd == 0)
            {
                Money_50();
            }
            else
            {
                Money_10();
            }
        }
        else
        {
            Money_10();
        }
    }

    void SLOW(float Amount)
    {
        if (Amount >= 80)
        {
            Money_10();
        }
        else if (Amount >= 70)
        {
            int rnd = Random.Range(0, 2);
            if (rnd == 0)
            {
                Money_10();
            }
            else
            {
                Money_5();
            }
        }
        else
        {
            Money_5();
        }
    }

    void TOOSLOW(float Amount)
    {
        if (Amount <= 40)
        {
            Money_5();
        }
        else if (Amount <= 20)
        {
            int rnd = Random.Range(0, 2);
            if (rnd == 0)
            {
                Money_5();
            }
            else
            {
                Money_1();
            }
        }
        else
        {
            Money_1();
        }
    }
}
