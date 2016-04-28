using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

    public Canvas exitCanvas;
    public Button playButton;
    public Button exitButton;

    void Awake()
    {
        exitCanvas.enabled = false;
    }

    // Pega os componentes necessários; Evita erros caso algum componente errado tenha sido passado;
    void start()
    {
        exitCanvas = exitCanvas.GetComponent<Canvas>();
        playButton = playButton.GetComponent<Button>();
        exitButton = exitButton.GetComponent<Button>();
    }

    //Carrega a primeira fase
	public void playGame()
    {
        SceneManager.LoadScene("Game");
    }

    // O botão sair foi pressionado
    public void exitGame()
    {
        exitCanvas.enabled = true;
        playButton.enabled = false;
        exitButton.enabled = false;
    }

    // Na confirmação de saída, o botão "Não" foi pressionado
    public void noPressed()
    {
        exitCanvas.enabled = false;
        playButton.enabled = true;
        exitButton.enabled = true;
    }

    // Na confirmação de saída, o botão "Sim" foi pressionado
    public void yesPressed()
    {
        Application.Quit();
    }

    public void about()
    {
       // SceneManager.LoadScene("Sobre");
    }
}
