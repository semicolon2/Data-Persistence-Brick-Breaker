using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string PlayerName;

    [System.Serializable]
    public struct HighScore
    {
        public string PlayerName;
        public int Score;
        public HighScore(string playerName, int score)
        {
            PlayerName = playerName;
            Score = score;
        }

    }
    public List<HighScore> HighScores;

    [System.Serializable]
    class SaveData
    {
        public List<HighScore> HighScores;
    }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public HighScore GetBestScore()
    {
        if (HighScores == null || HighScores.Count <= 0)
        {
            return new HighScore();
        }
        else
        {
            SortScores();
            return HighScores[0];
        }
    }

    public void SortScores()
    {
        HighScores.Sort((HighScore x, HighScore y) => x.Score < y.Score ? 1 : -1);
    }

    public void AddScore(int score)
    {
        HighScores.Add(new HighScore(PlayerName, score));
        SortScores();
        if (HighScores.Count > 6)
        {
            HighScores.RemoveAt(6);
        }
    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.HighScores = HighScores;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            HighScores = data.HighScores;
        }
    }
}
