using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public class RankingDisplay : MonoBehaviour
{
    [SerializeField]
    Text[] RankingScoreText;

    [SerializeField]
    Text[] RankingNameText;

    void Start()
    {
        ScoreAndNameDisplay();
    }
    void ScoreAndNameDisplay()
    {
        List<DataDetail> details = RankingData.Load_DataAmount();

        for(int i = 0;i < details.Count;i++)
        {
            int rankingnum = i + 1;
            RankingScoreText[i].text = rankingnum + "位:" + details[i].Score.ToString();
            RankingNameText[i].text = details[i].Name.ToString();
        }
    }
}
