using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{

    public GameObject PauseUI;
    public GameObject PauseButton;
    public GameObject GameOverUI;
    public GameObject Hud;

    public Text scoreText;
    public Text highScoreText;

    public Text gameScore;
    public Text gameHighScore;

    private bool paused = false;

    public Texture2D coinIconTexture;


    void Start()
    {
        PauseUI.SetActive(false);
        GameOverUI.SetActive(false);
    }

    void Update()
    {
        gameScore.text = PlayerController.coins.ToString();
        gameHighScore.text = PlayerPrefs.GetInt("highScore").ToString();
    }

    public void Pause()
    {

        paused = !paused;

        if (paused)
        {
            GameOverUI.SetActive(false);
            PauseUI.SetActive(true);
            PauseButton.SetActive(false);
            Time.timeScale = 0;
        }

        if (!paused)
        {

            PauseUI.SetActive(false);
            PauseButton.SetActive(true);
            Time.timeScale = 1;
        }

    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartMenu");
    }

    /*  void DisplayCoinsCount()
      {
          if (PlayerController.dead == false)
          {
              Rect coinIconRect = new Rect(10, 10, 60, 60);
              GUI.DrawTexture(coinIconRect, coinIconTexture);
              GUIStyle style = new GUIStyle();
              style.fontSize = 40;
              style.fontStyle = FontStyle.Bold;
              style.normal.textColor = Color.yellow;

              Rect labelRect = new Rect(coinIconRect.xMax, coinIconRect.y+10, 60, 32);
              GUI.Label(labelRect, PlayerController.coins.ToString(), style);
          }
          else
          {
              Rect coinIconRect = new Rect(500, 250, 60, 60);
              GUI.DrawTexture(coinIconRect, coinIconTexture);
              GUIStyle style = new GUIStyle();
              style.fontSize = 40;
              style.fontStyle = FontStyle.Bold;
              style.normal.textColor = Color.yellow;

              Rect labelRect = new Rect(coinIconRect.xMax, coinIconRect.y + 10, 60, 32);
              GUI.Label(labelRect, PlayerController.coins.ToString(), style);
          }
      } */

    void OnGUI()
    {
        if (!paused)
        {
            //  DisplayCoinsCount();
        }

        if (PlayerController.dead == true)
        {
            GameOverUI.SetActive(true);
            Hud.SetActive(false);
            showScore();
        }
    }

    public void showScore()
    {
        var score = 0;
        scoreText.text = PlayerController.coins.ToString();
        score = PlayerPrefs.GetInt("highScore");
        highScoreText.text = score.ToString();
    }

}
