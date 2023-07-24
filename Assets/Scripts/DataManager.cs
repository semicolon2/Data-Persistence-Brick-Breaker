using System.Collections;
using System.Collections.Generic;
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
}
