using UnityEngine;

public class coinPossetter : MonoBehaviour
{
    public static coinPossetter instance;

    private void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    public void CoinSet(RectTransform targetPos)
    {
        GameObject Coin = GameObject.FindGameObjectWithTag("Coin");
        RectTransform Coin_Pos = Coin.GetComponent<RectTransform>();
        Coin_Pos = targetPos;
        Coin_Pos = null;
    }
}
