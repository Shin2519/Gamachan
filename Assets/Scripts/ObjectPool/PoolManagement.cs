using UnityEngine;

public class PoolManagement : MonoBehaviour
{
    [SerializeField]
    OneYenPool OnePrefab;
    [SerializeField]
    FiveYenPool FivePrefab;
    [SerializeField]
    TenYenPool TenPrefab;
    [SerializeField]
    FiftyYenPool FiftyPrefab;
    [SerializeField]
    OnehundredYenPool OnehundredPrefab;
    [SerializeField]
    FivehundredYenPool FivehundredPrefab;
    private ObjectPool<OneYenPool> One_Yen;
    private ObjectPool<FiveYenPool> Five_Yen;
    private ObjectPool<TenYenPool> Ten_Yen;
    private ObjectPool<FiftyYenPool> Fifty_Yen;
    private ObjectPool<OnehundredYenPool> Onehundred_Yen;
    private ObjectPool<FivehundredYenPool> Fivehundred_Yen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        One_Yen = new ObjectPool<OneYenPool>(OnePrefab,10);
        Five_Yen = new ObjectPool<FiveYenPool>(FivePrefab,10);
        Ten_Yen = new ObjectPool<TenYenPool>(TenPrefab,10);
        Fifty_Yen = new ObjectPool<FiftyYenPool>(FiftyPrefab,10);
        Onehundred_Yen = new ObjectPool<OnehundredYenPool>(OnehundredPrefab, 10);
        Fivehundred_Yen = new ObjectPool<FivehundredYenPool>(FivehundredPrefab, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        
    }
}
