using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public class RankingDisplay : MonoBehaviour
{
    [SerializeField]
    Text[] RankingScoreText;

    [SerializeField]
    Text[] RankingNameText;

    void OnEnable()
    {
        ScoreAndNameDisplay();
    }
    void OnDisable()
    {
        
    }
    void ScoreAndNameDisplay()
    {
        List<DataDetail> details = RankingData.Load_DataAmount();

        var sort_details = details.OrderByDescending(x => x.Score).ToList();

        Debug.Log(sort_details);

        for(int i = 0;i < details.Count;i++)
        {
            int rankingnum = i + 1;
            RankingScoreText[i].text = rankingnum + "位:" + sort_details[i].Score.ToString();
            RankingNameText[i].text = sort_details[i].Name.ToString();
        }
    }
}
