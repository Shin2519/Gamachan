using System.Collections.Generic;
using UnityEngine;

public class GoodsCatalog
{
    private readonly SkillDescripsion descripsion;
    public struct Entry
    {
        public Sprite Sprite;
        public string Description;
        public int Amount;
        public int Number;
    }
    private readonly List<Entry> entries = new List<Entry>();

    public int Count => entries.Count;

    public GoodsCatalog(Goods goods, SkillDescripsion descripsion)
    {
        this.descripsion = descripsion;
        foreach (var genre in goods.Genres)
        {
            foreach (var item in genre.Items)
            {
                int Num = Random.Range(0,6);
                string l_detail = descripsion.GetSkillDetail(Num);
                entries.Add(new Entry{Sprite = item.GoodsSprite,Amount = item.Amount,Number = Num,Description = l_detail});
            }
        }
    }

    public List<Entry> PickRandom(int count)
    {
        List<int> candidates = new List<int>();
        for (int i = 0; i < entries.Count; i++) candidates.Add(i);

        List<Entry> result = new List<Entry>();
        for (int i = 0; i < count; i++)
        {
            if (candidates.Count == 0) break;
            int idx = Random.Range(0, candidates.Count);
            result.Add(entries[candidates[idx]]);
        }
        return result;
    }
}
