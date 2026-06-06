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

    static int[] RankingScore = new int[5];
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
            profile.PlayerName = PlayerPrefs.GetString((i + 1).ToString(),string.Empty);

            profile.PlayerScore = PlayerPrefs.GetInt((i + 1).ToString(),0);

            RankingProfiles.Add(profile);
        }
    }
    public static int RankingJudge(int New_Score)
    {
        int rankingNum =0;
        for (int i = 0;i < RankingScore.Length;i++)
        {
                rankingNum = i + 1;
            if(!PlayerPrefs.HasKey(string.Format("Score{1}", rankingNum)))
            {
                PlayerPrefs.SetInt(string.Format( "Score{1}" , rankingNum),New_Score);
                break;
            }
        }

        

        for(int i = 0;i < RankingScore.Length;i++)
        {
            rankingNum = i + 1;
            RankingScore[i] = PlayerPrefs.GetInt(string.Format("Score{1}", rankingNum));
        }

        if (RankingScore[5]<=New_Score)
        {
            rankingNum = 5;
            PlayerPrefs.SetInt(string.Format("Score{1}", rankingNum), New_Score);
        }
        return rankingNum;
    }
}
