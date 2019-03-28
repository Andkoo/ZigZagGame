using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject tapText;
    [SerializeField] GameObject scoreInGame;
    [SerializeField] List<Text> scoreTexts;
    [SerializeField] List<Text> highScoreTexts;

    void Awake()
    {
        if (instance == null) instance = this;
    }

    public void GameStart()
    {
        tapText.SetActive(false);
        startPanel.GetComponent<Animator>().Play("FadeUp");
        scoreInGame.SetActive(true);
    }

    public void UpdateScores()
    {
        foreach (Text i in scoreTexts)
        {
            i.text = ScoreManager.instance.score.ToString();
        }
    }

    public void GameOver()
    {
        scoreInGame.SetActive(false);
        gameOverPanel.SetActive(true);

        foreach (Text i in highScoreTexts)
        {
            if (PlayerPrefs.HasKey("highScore"))
            {
                i.text = ScoreManager.instance.score.ToString();
            }
            else
            {
                i.text = "0";
            }
        }
    }

    public void GameRestart()
    {
        SceneManager.LoadScene("Level1");
    }
}
