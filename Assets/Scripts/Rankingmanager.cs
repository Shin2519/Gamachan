using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//仮アタッチの場合オブジェクトマネージャーに



public class RankingManager : MonoBehaviour
{
    public static RankingManager Instance;

    public List<RankEntry> challengeRanking = new List<RankEntry>();
    public List<RankEntry> timeLimitRanking = new List<RankEntry>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadRanking();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(string mode, string name, int score)
    {
        RankEntry entry = new RankEntry { playerName = name, score = score };

        if (mode == "Challenge")
        {
            challengeRanking.Add(entry);
            challengeRanking = challengeRanking
                .OrderByDescending(e => e.score)
                .Take(5).ToList();
        }
        else if (mode == "TimeLimit")
        {
            timeLimitRanking.Add(entry);
            timeLimitRanking = timeLimitRanking
                .OrderByDescending(e => e.score)
                .Take(5).ToList();
        }

        SaveRanking();
    }

    public void SaveRanking()
    {
        // チャレンジモード
        for (int i = 0; i < challengeRanking.Count; i++)
        {
            PlayerPrefs.SetString("ChallengeName" + i, challengeRanking[i].playerName);
            PlayerPrefs.SetInt("ChallengeScore" + i, challengeRanking[i].score);
        }

        // タイムリミットモード
        for (int i = 0; i < timeLimitRanking.Count; i++)
        {
            PlayerPrefs.SetString("TimeLimitName" + i, timeLimitRanking[i].playerName);
            PlayerPrefs.SetInt("TimeLimitScore" + i, timeLimitRanking[i].score);
        }

        PlayerPrefs.Save();
    }

    public void LoadRanking()
    {
        challengeRanking.Clear();
        timeLimitRanking.Clear();

        for (int i = 0; i < 5; i++)
        {
            if (PlayerPrefs.HasKey("ChallengeName" + i))
            {
                challengeRanking.Add(new RankEntry
                {
                    playerName = PlayerPrefs.GetString("ChallengeName" + i),
                    score = PlayerPrefs.GetInt("ChallengeScore" + i)
                });
            }

            if (PlayerPrefs.HasKey("TimeLimitName" + i))
            {
                timeLimitRanking.Add(new RankEntry
                {
                    playerName = PlayerPrefs.GetString("TimeLimitName" + i),
                    score = PlayerPrefs.GetInt("TimeLimitScore" + i)
                });
            }
        }
    }
}
