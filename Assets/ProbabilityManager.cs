using UnityEngine;

public class ProbabilityManager : MonoBehaviour
{
    public static ProbabilityManager instance;

    void Awake()
    {
        instance = this;
    }
    public void Normal(float Shakespeed)
    {
        int rnd = Random.Range(0, 100);
        if (rnd >= 0 && rnd <= 49)
        {
            DropMoney.instance.KindofMoney(Shakespeed);
        }
        else
        {

        }
        Debug.Log(rnd);
    }
    public void Gold(float Shakespeed)
    {
        int rnd = Random.Range(0, 100);
        if (rnd >= 0 && rnd <= 59)
        {
            DropMoney.instance.KindofMoney(Shakespeed);
        }
        else
        {

        }
        Debug.Log(rnd);
    }
}
