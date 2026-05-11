using UnityEngine;

public class FiftyYenPool : MonoBehaviour
{
    Rigidbody2D rigidbody2;

    [SerializeField, Header("èâë¨ìx")]
    float v0_;
    public ObjectPool<FiftyYenPool> FiftyYen { get; set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Gamatyan"))
        {
            return;
        }
        else if (col.gameObject.CompareTag("Tray"))
        {
            FiftyYen.Return(this);
            ProbabilityManager.coin.FiftyYenCoins++;
        }
    }
}
