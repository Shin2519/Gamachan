using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RankingManager : MonoBehaviour
{
    public static RankingManager Instance;

    public List<RankEntry> challengeRanking = new List<RankEntry>();
    public List<RankEntry> timeLimitRanking = new List<RankEntry>();

    [SerializeField] private Playername pl;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadRanking(); // ★ 起動時に読み込む
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        
    }

    // スコア追加
    public void AddScore(string mode, string name, int score)
    {
        RankEntry entry = new RankEntry { playerName = name, score = score };

        if (mode == "Challenge")
        {
            challengeRanking.Add(entry);

            // ★ 高い順に並べて上位5件だけ残す
            challengeRanking = challengeRanking
                .OrderByDescending(e => e.score)
                .Take(5)
                .ToList();
        }
        else if (mode == "TimeLimit")
        {
            timeLimitRanking.Add(entry);

            // ★ 高い順に並べて上位5件だけ残す
            timeLimitRanking = timeLimitRanking
                .OrderByDescending(e => e.score)
                .Take(5)
                .ToList();
        }

        SaveRanking();
    }

    // 保存
    public void SaveRanking()
    {
        // チャレンジ
        for (int i = 0; i < challengeRanking.Count; i++)
        {
            PlayerPrefs.SetString("ChallengeName" + i, challengeRanking[i].playerName);
            PlayerPrefs.SetInt("ChallengeScore" + i, challengeRanking[i].score);
        }

        // タイムリミット
        for (int i = 0; i < timeLimitRanking.Count; i++)
        {
            PlayerPrefs.SetString("TimeLimitName" + i, timeLimitRanking[i].playerName);
            PlayerPrefs.SetInt("TimeLimitScore" + i, timeLimitRanking[i].score);
        }

        PlayerPrefs.Save();
    }

    // 読み込み
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

        //  読み込み後も必ず高い順に並べる
        challengeRanking = challengeRanking
            .OrderByDescending(e => e.score)
            .ToList();

        timeLimitRanking = timeLimitRanking
            .OrderByDescending(e => e.score)
            .ToList();
    }

    public void ResetRanking()
    {
        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.DeleteKey("ChallengeName" + i);
            PlayerPrefs.DeleteKey("ChallengeScore" + i);
        }

        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.DeleteKey("TimeLimitName" + i);
            PlayerPrefs.DeleteKey("TimeLimitScore" + i);
        }

        PlayerPrefs.Save();

        challengeRanking.Clear();
        timeLimitRanking.Clear();
    }


}
