using System;
using System.Collections.Generic;
using System.Linq;
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
    static string filePath = Application.persistentDataPath + "/RankingData.json";

    static string json;
    public static List<DataDetail> Load_DataAmount()
    {
        Data data = new Data();

        data = GetData(data);

        return data.datadetails;
    }

    public static void Save_Score(int l_score,GameObject l_setactive)
    {
        Data data = new Data();

        data = GetData(data);

        if(data.datadetails.Count > 5&&l_score > data.datadetails[4].Score)
        {
            AudioManager.Instance.PlaySE(AudioManager.Instance.SE[16]);

            data.datadetails.Add(new DataDetail { Score = l_score, Name = string.Empty });

            l_setactive.SetActive(true);

            var sort_details = data.datadetails.OrderByDescending(x => x.Score).Take(5).ToList();

            data.datadetails = sort_details;
        }
        else
        {
            AudioManager.Instance.PlaySE(AudioManager.Instance.SE[16]);

            data.datadetails.Add(new DataDetail { Score = l_score, Name = string.Empty });

            l_setactive.SetActive(true);

            var sort_details = data.datadetails.OrderByDescending(x => x.Score).ToList();

            data.datadetails = sort_details;
        }

        json = JsonUtility.ToJson(data);

        File.WriteAllText(filePath, json);
    }

    public static void Save_Name(string l_name)
    {
        Data data = new Data();

        data = GetData(data);

        AudioManager.Instance.PlaySE(AudioManager.Instance.SE[16]);

        if (data.datadetails.Count > 0)
        {
            data.datadetails[data.datadetails.Count - 1].Name = l_name;
        }

        json = JsonUtility.ToJson(data);

        File.WriteAllText(filePath, json);
    }
    static Data GetData(Data l_data)
    {
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
