using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public class RankingDisplay : MonoBehaviour
{
    struct RankingProfile
    { 
        public string PlayerName;

        public int PlayerScore;
    }

    RankingProfile profile;

    List<RankingProfile> RankingProfiles = new List<RankingProfile>();

    [SerializeField]
    Text[] RankingText;

    void Awake()
    {
        RankingDataGet();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerProfileDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayerProfileDisplay()
    {
        for(int i = 0;i < RankingText.Length;i++)
        {
            RankingText[i].text = RankingProfiles[i].PlayerName + RankingProfiles[i].PlayerScore;
        }
    }

    void RankingDataGet()
    {
        for(int i = 0;i < 5;i++)
        {
            profile.PlayerName = PlayerPrefs.GetString((i + 1).ToString(),"");

            profile.PlayerScore = PlayerPrefs.GetInt((i + 1).ToString(),0);

            RankingProfiles.Add(profile);
        }
    }

    public static int RankingJudge(int New_Score)
    {
        int RankingNum =0;
        for (int i = 0;i < 5;i++)
        {
            if(!PlayerPrefs.HasKey("Score" + (i + 1).ToString()))
            {
                RankingNum = i + 1;
                PlayerPrefs.SetInt("Score" + RankingNum.ToString(),New_Score);
                break;
            }
        }

        List<int> RankingScore = new List<int>();

        for(int i = 0;i < 5;i++)
        {
            RankingScore.Add(PlayerPrefs.GetInt("Score" + (i + 1).ToString()));
        }

        if (RankingScore[5]<=New_Score)
        {
            RankingNum = 5;
            PlayerPrefs.SetInt("Score" + RankingNum.ToString(), New_Score);
        }
        return RankingNum;
    }
}
