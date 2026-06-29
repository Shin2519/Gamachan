using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
[Serializable]
public class DataDetail
{
    public int Score;

    public string Name;
}
[Serializable]
public class Data
{
    public List<DataDetail> datadetails = new List<DataDetail>();
}

public static class RankingData
{
    public static List<DataDetail> Load_DataAmount()
    {
        Data data = new Data();

        data = GetData(data);

        return data.datadetails;
    }

    public static void Save_Score(int l_score)
    {
        string filePath = Application.persistentDataPath + "/RankingData.json";

        string json;

        Data data = new Data();

        data = GetData(data);

        data.datadetails.Add(new DataDetail { Score = l_score,Name = string.Empty});

        json = JsonUtility.ToJson(data);

        File.WriteAllText(filePath, json);
    }

    public static void Save_Name(string l_name)
    {
        string filePath = Application.persistentDataPath + "/RankingData.json";

        string json;

        Data data = new Data();

        data = GetData(data);

        if(data.datadetails.Count > 0)
        {
            data.datadetails[data.datadetails.Count - 1].Name = l_name;
        }

        json = JsonUtility.ToJson(data);

        File.WriteAllText(filePath, json);
    }

    static Data GetData(Data l_data)
    {
        string filePath = Application.persistentDataPath + "/RankingData.json";

        string json;

        if (File.Exists(filePath))
        {
            json = File.ReadAllText(filePath);

            l_data = JsonUtility.FromJson<Data>(json);
        }
        else if(!File.Exists(filePath))
        {
            json = JsonUtility.ToJson(l_data);

            File.WriteAllText(filePath, json);
        }
            return l_data;
    }
}
