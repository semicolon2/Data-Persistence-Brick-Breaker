using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    public TMP_InputField NameInput;
    public TMP_Text HighScoreText;

    void Start()
    {
        DataManager.Instance.Load();
        DataManager.HighScore bestScore = DataManager.Instance.GetBestScore();
        if (bestScore.PlayerName == null)
        {
            return;
        }
        else
        {
            HighScoreText.text = $"High Score : {bestScore.PlayerName} : {bestScore.Score}";
        }

    }
    public void StartGameButton()
    {
        DataManager.Instance.PlayerName = NameInput.text;
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
