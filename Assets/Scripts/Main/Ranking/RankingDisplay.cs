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

        for(int i = 0;i < details.Count;i++)
        {
            int rankingnum = i + 1;
            if (details[i].Score.HasValue) RankingText[i].text = rankingnum + "位:" +  details[i].Score.ToString() + details[i].Name.ToString();
        }
    }
}
