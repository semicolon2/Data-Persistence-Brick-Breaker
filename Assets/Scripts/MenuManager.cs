using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

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

    public InputField NameInput;

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

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void StartGameButton()
    {
        SceneManager.LoadScene(1);
    }

    public void HighScoreButton()
    {
        SceneManager.LoadScene(2);
    }

    public void Quit()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }
}
