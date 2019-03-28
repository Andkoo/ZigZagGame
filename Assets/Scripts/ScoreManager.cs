using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score = 0;
    public int highScore = 0;

    void Awake()
    {
        if (instance == null) instance = this;
    }

    void Start()
    {
        score = 0;
    }

    public void IncrementScore()
    {
        score += 1;
        UIManager.instance.UpdateScores();
    }

    public void IncrementScore(int amount)
    {
        score += amount;
        UIManager.instance.UpdateScores();
    }

    public void StartScore()
    {
        InvokeRepeating("IncrementScore", 0.1f, 0.1f);
    }

    public void StopScore()
    {
        CancelInvoke("IncrementScore");

        if (PlayerPrefs.HasKey("highScore"))
        {
            if (score > PlayerPrefs.GetInt("highScore"))
            {
                PlayerPrefs.SetInt("highScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("highScore", score);
        }
    }
}
