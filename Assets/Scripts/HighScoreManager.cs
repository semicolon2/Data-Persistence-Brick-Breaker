using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class HighScoreManager : MonoBehaviour
{
    public GameObject TextPrefab;
    public GameObject Canvas;
    private float nextPostion = -100;
    void Start()
    {
        DataManager.Instance.SortScores();

        int index = 1;
        foreach (DataManager.HighScore highScore in DataManager.Instance.HighScores)
        {
            TMP_Text text = Instantiate(TextPrefab, Canvas.transform.position, transform.rotation).GetComponent<TMP_Text>();
            text.transform.SetParent(Canvas.transform, false);
            text.rectTransform.anchoredPosition = new Vector2(0, nextPostion);
            text.text = $"{index}. {highScore.PlayerName} : {highScore.Score}";
            nextPostion -= 50;
            index++;
        }
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
