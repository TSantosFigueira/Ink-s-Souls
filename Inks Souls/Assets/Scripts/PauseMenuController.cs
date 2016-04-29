using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour {

    public GameObject PauseUI;
    public GameObject PauseButton;
  
    private bool paused = false;

    void Start() {

        PauseUI.SetActive(false);

    }

    public void Pause() {
        
        paused = !paused;

 
        if (paused) {

            PauseUI.SetActive(true);
            PauseButton.SetActive(false);
            Time.timeScale = 0;

        }

        if (!paused) {

            PauseUI.SetActive(false);
            PauseButton.SetActive(true);
            Time.timeScale = 1;

        }

    }

    public void Restart() {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartMenu");
    }

}
