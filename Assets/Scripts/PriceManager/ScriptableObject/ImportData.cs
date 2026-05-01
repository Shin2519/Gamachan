using UnityEngine;
using UnityEditor;

public class ImportData
{
    [MenuItem("Tools/Import CSV to SO")]
    public static void Import()
    {
        TextAsset csv = AssetDatabase.LoadAssetAtPath<TextAsset>(
            "Assets/Scripts/PriceManager/ScriptableObject/data.csv");

        if (csv == null)
        {
            return;
        }

        string[] lines = csv.text.Split('\n');

        ImageData data = ScriptableObject.CreateInstance<ImageData>();

        data.datapools = new System.Collections.Generic.List<datapool>();

        for (int i = 0; i < lines.Length; i++) 
        {
            if (string.IsNullOrWhiteSpace(lines[i])) continue;

            string[] split = lines[i].Split(',');

            string priceStr = split[0].Replace("\r", "");
            //string imagename = split[1].Replace("\r", "");


            if (!int.TryParse(priceStr, out int price))
            {
                continue;
            }

            //Sprite sprite = Resources.Load<Sprite>("Images/"+imagename);

            datapool dp = new datapool
            {
                //image = sprite,
                price = price
               
            };

            data.datapools.Add(dp);
        }

        string path = "Assets/Scripts/PriceManager/ScriptableObject/ImageData.asset";

        AssetDatabase.DeleteAsset(path);

        AssetDatabase.CreateAsset(data, path);
        AssetDatabase.SaveAssets();

        Debug.Log("インポート完了");
    }
}