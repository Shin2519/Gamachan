using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
public struct RankingProfile
{
    public int Ranking;

    public string PlayerName;

    public int PlayerScore;
}

[Serializable]
public class Data
{
    public List<RankingProfile> RankingProfiles;
}

public class RankingData : MonoBehaviour
{
    string filePath = Application.persistentDataPath + "/playerData.json";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    List<RankingProfile> Load()
    {
        Data json = new Data();
        if(File.Exists(filePath))
        {
            json = JsonUtility.FromJson<Data>(filePath);
        }
        return json.RankingProfiles;
    }

    void Save()
    {
        Data json = new Data();
        if (File.Exists(filePath))
        {
            json = JsonUtility.FromJson<Data>(filePath);
        }
    }
}
