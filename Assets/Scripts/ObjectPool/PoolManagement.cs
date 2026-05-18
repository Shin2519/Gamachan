using UnityEngine;
using System.Collections.Generic;

public class PoolManagement : SingletonMonoBehaviour<PoolManagement>
{
    [SerializeField]
    private Coin[] CoinPrefab;

    [SerializeField]
    private int InitialPoolSize;
    [SerializeField]
    Transform GamaPos;
    [SerializeField]
    Vector3 OffSet;

    private Dictionary<int, ObjectPool<Coin>> Pools = new();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (var prefab in CoinPrefab)
        {
            int yen = prefab.Yen;
            Pools[yen] = new ObjectPool<Coin>(prefab, InitialPoolSize);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn(int yen)
    {
        if (!Pools.TryGetValue(yen, out var pool))
        {
            Debug.LogWarning($"‹àŠz {yen} ‚Ìƒv[ƒ‹‚ª‚ ‚è‚Ü‚¹‚ñ");
            return;
        }

        Coin coin = pool.Get();
        coin.transform.position = GamaPos.position + OffSet;
        coin.Initialize(c => OnCoinReturned(c, pool));
    }

    private void OnCoinReturned(Coin coin, ObjectPool<Coin> pool)
    {
        pool.Return(coin);
        AddCoinCount(coin.Yen);
        ProbabilityManager.GaugeAmount = ProbabilityManager.GaugeUp(ProbabilityManager.GaugeAmount);
    }

    private void AddCoinCount(int yen)
    {
        switch (yen)
        {
            case 1: ProbabilityManager.coin.OneYenCoins++; break;
            case 5: ProbabilityManager.coin.FiveYenCoins++; break;
            case 10: ProbabilityManager.coin.TenYenCoins++; break;
            case 50: ProbabilityManager.coin.FiftyYenCoins++; break;
            case 100: ProbabilityManager.coin.OnehundredYenCoins++; break;
            case 500: ProbabilityManager.coin.FivehundredYenCoins++; break;
        }
    }
}
