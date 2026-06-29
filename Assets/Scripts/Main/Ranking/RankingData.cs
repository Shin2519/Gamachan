using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
[Serializable]
public class Data
{
    public List<int> Ranking;

    public List<string> PlayerName;

    public List<int> PlayerScore;
}

public class RankingData : MonoBehaviour
{
    string filePath = Application.persistentDataPath + "/playerData.json";

    Data data = new Data();
    string json;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    List<int> Load()
    {
        data = GetData(data);
        return data.PlayerScore;
    }

    void Save_Score(int l_score)
    {
        data = GetData(data);
        data.PlayerScore.Add(l_score);

        json = JsonUtility.ToJson(data);

        File.WriteAllText(filePath, json);
    }

    void Save_Name(string l_name)
    {
        data = GetData(data);
        data.PlayerName.Add(l_name);

        json = JsonUtility.ToJson(data);

        File.WriteAllText(filePath, json);
    }

    Data GetData(Data l_data)
    {
        if (File.Exists(filePath))
        {
            json = File.ReadAllText(filePath);
            l_data = JsonUtility.FromJson<Data>(json);
        }
        return l_data;
    }
}
