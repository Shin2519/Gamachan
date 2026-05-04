using UnityEngine;

public class FivehundredYenPool : MonoBehaviour
{
    Rigidbody2D rigidbody2;

    [SerializeField, Header("èâë¨ìx")]
    float v0_;
    public ObjectPool<FivehundredYenPool> FivehundredYen { get; set; }
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
        int num = col.gameObject.GetComponent<PoolManagement>().Tray_;
        if (num == 1)
        {
            FivehundredYen.Return(this);
            ProbabilityManager.coin.FivehundredYenCoins++;
        }
    }
}
