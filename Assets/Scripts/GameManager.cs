using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool gameOver = false;
    public bool started = false;

    void Awake()
    {
        if (instance == null) instance = this;
    }

    public void GameStart()
    {
        UIManager.instance.GameStart();
        ScoreManager.instance.StartScore();
        started = true;
        gameOver = false;
    }

    public void GameOver()
    {
        UIManager.instance.GameOver();
        ScoreManager.instance.StopScore();
        started = false;
        gameOver = true;
    }
}
