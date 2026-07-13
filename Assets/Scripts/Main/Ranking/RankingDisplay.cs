using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public class RankingDisplay : MonoBehaviour
{
    [SerializeField]
    Text[] RankingText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ScoreAndNameDisplay();
    }

    void ScoreAndNameDisplay()
    {
        List<DataDetail> details = RankingData.Load_DataAmount();

        var sort_details = details.OrderByDescending(x => x.Score).ToList();

        for(int i = 0;i < details.Count;i++)
        {
            int rankingnum = i + 1;
            RankingText[i].text = rankingnum + "位:" + sort_details[i].Score.ToString() + sort_details[i].Name.ToString();
        }
    }
}
