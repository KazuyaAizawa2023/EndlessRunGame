using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class RankingManager : MonoBehaviour
{
    private string filePath;
    private RankingData rankingData;

    void Start()
    {
        filePath = Application.persistentDataPath + "/rankingData.json";
        LoadRankingData();
        DisplayRanking();
    }

    // ランキングデータの読み込み
    void LoadRankingData()
    {
        rankingData = new RankingData(); // 初期化を先に行う

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            rankingData = JsonUtility.FromJson<RankingData>(json);
            // デバッグログで rankingData の値と JSON データを確認
            Debug.Log($"Loaded Ranking Data: {rankingData}");
            Debug.Log($"Loaded JSON Data: {json}");
        }
        else
        {
            Debug.LogError($"Error: JSON file not found at path {filePath}");
        }

        if (rankingData != null)
        {
            // デバッグログでランキングデータを表示
            Debug.Log("Current Ranking:");
            for (int i = 0; i < rankingData.Scores.Count; i++)
            {
                Debug.Log($"{i + 1}. {rankingData.Scores[i]}");
            }
        }
    }

    // ランキングデータの保存
    void SaveRankingData()
    {
        string json = JsonUtility.ToJson(rankingData);
        File.WriteAllText(filePath, json);

        // デバッグログで保存したランキングデータを表示
        Debug.Log("Saved Ranking Data:");
        for (int i = 0; i < rankingData.Scores.Count; i++)
        {
            Debug.Log($"{i + 1}. {rankingData.Scores[i]}");
        }
    }

    // スコアの保存
    public void SaveScore(int score)
    {
        rankingData.Scores.Add(score);
        rankingData.Scores.Sort((a, b) => b.CompareTo(a));
        rankingData.Scores = rankingData.Scores.GetRange(0, Mathf.Min(rankingData.Scores.Count, 3));
        SaveRankingData();
        DisplayRanking();
    }

    // ランキングの表示
    void DisplayRanking()
    {
        Debug.Log("Current Ranking:");
        for (int i = 0; i < rankingData.Scores.Count; i++)
        {
            Debug.Log($"{i + 1}. {rankingData.Scores[i]}");
        }
    }
}
