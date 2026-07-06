using UnityEngine;
using System.Collections.Generic;
using System;

public class PoolManagement : SingletonMonoBehaviour<PoolManagement>
{
    [SerializeField] UIDisplayAmountManagement AmountManagement;

    [SerializeField] private Coin[] CoinPrefab;

    [SerializeField] private int InitialPoolSize;

    [SerializeField] Transform GamaPos;

    [SerializeField] Vector3 OffSet;

    Func<StateMashine.Skill> OnSkillState;

    private Dictionary<int, ObjectPool<Coin>> Pools = new();
    public void CoinInitialize()
    {
        foreach (var prefab in CoinPrefab)
        {
            int yen = prefab.Yen;
            Pools[yen] = new ObjectPool<Coin>(prefab, InitialPoolSize);
        }
    }
    public void Spawn(int yen)
    {
        if (!Pools.TryGetValue(yen, out var pool))
        {
            Debug.LogWarning($"���z {yen} �̃v�[��������܂���");
            return;
        }

        Coin coin = pool.Get();
        coin.transform.position = GamaPos.position + OffSet;
        coin.Initialize(c => OnCoinReturned(c, pool));
    }

    private void OnCoinReturned(Coin coin, ObjectPool<Coin> pool)
    {
        AudioManager.Instance.PlaySE(AudioManager.Instance.SE[5]);

        pool.Return(coin);
        AddCoinCount(coin.Yen);
        StateMashine.Skill l_skillstate = OnSkillState();
        if (l_skillstate==StateMashine.Skill.NormalLocked) return;
        AmountManagement.Current++;
    }

    private void AddCoinCount(int yen)
    {
        switch (yen)
        {
            case 1: AnythingData.coin.OneYenCoins++; break;
            case 5: AnythingData.coin.FiveYenCoins++; break;
            case 10: AnythingData.coin.TenYenCoins++; break;
            case 50: AnythingData.coin.FiftyYenCoins++; break;
            case 100: AnythingData.coin.OnehundredYenCoins++; break;
            case 500: AnythingData.coin.FivehundredYenCoins++; break;
        }
    }

    public void SetSkillState(Func<StateMashine.Skill> l_skillstate)
    {
        OnSkillState = l_skillstate;
    }
}
