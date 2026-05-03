using state;
using UnityEngine;


public class PoolManagement : SingletonMonoBehaviour<PoolManagement>
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
    [SerializeField]
    Transform GamaPos;
    [SerializeField]
    Vector3 OffSet;
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

    public void Money_1()
    {
        OneYenPool One = One_Yen.Get();
        One.transform.position = GamaPos.position + OffSet;
        One.OneYen = One_Yen;
    }
    public void Money_5()
    {
        FiveYenPool Five = Five_Yen.Get();
        Five.transform.position = GamaPos.position + OffSet;
        Five.FiveYen = Five_Yen;
    }
    public void Money_10()
    {
        TenYenPool Ten = Ten_Yen.Get();
        Ten.transform.position = GamaPos.position + OffSet;
        Ten.TenYen = Ten_Yen;
    }
    public void Money_50()
    {
        FiftyYenPool Fifty = Fifty_Yen.Get();
        Fifty.transform.position = GamaPos.position + OffSet;
        Fifty.FiftyYen = Fifty_Yen;
    }
    public void Money_100()
    {
        OnehundredYenPool Onehundred = Onehundred_Yen.Get();
        Onehundred.transform.position = GamaPos.position + OffSet;
        Onehundred.OnehundredYen = Onehundred_Yen;
    }
    public void Money_500()
    {
        FivehundredYenPool Fivehundred = Fivehundred_Yen.Get();
        Fivehundred.transform.position = GamaPos.position + OffSet;
        Fivehundred.FivehundredYen = Fivehundred_Yen;
    }
}
