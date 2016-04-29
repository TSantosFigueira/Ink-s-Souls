using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float jetpackForce = 75.0f;
    public float forwardMovementSpeed = 3.0f;

    private bool dead = false;

    private uint coins = 0;
    private int highestScore = 0; // mudar aqui caso seja necessário acessar de outra classe

    public Texture2D coinIconTexture;

    public GUIStyle restartButtonStyle;

    void Start ()
    {
        //Recupera o high score do sistema
        highestScore = PlayerPrefs.GetInt("highScore", 0);
        Debug.Log(highestScore);
    }

    void FixedUpdate() {
        bool jetpackActive = Input.GetButton("Fire1");

        jetpackActive = jetpackActive && !dead;

        if (jetpackActive) {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jetpackForce));
        }

        if (!dead) {
            Vector2 newVelocity = GetComponent<Rigidbody2D>().velocity;
            newVelocity.x = forwardMovementSpeed;
            GetComponent<Rigidbody2D>().velocity = newVelocity;
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.CompareTag("Coins"))
            CollectCoin(collider);
        else
            HitByEnemy(collider);
    }

    void HitByEnemy(Collider2D enemyCollider) {
        dead = true;
    }

    void CollectCoin(Collider2D coinCollider) {
        coins++;

        // Salva o score mais alto no sistema. 
        if(coins > highestScore)
        {
            PlayerPrefs.SetInt("highScore", (int) coins);
        }

        Destroy(coinCollider.gameObject);
    }

    void DisplayCoinsCount() {
        Rect coinIconRect = new Rect(10, 10, 32, 32);
        GUI.DrawTexture(coinIconRect, coinIconTexture);

        GUIStyle style = new GUIStyle();
        style.fontSize = 30;
        style.fontStyle = FontStyle.Bold;
        style.normal.textColor = Color.yellow;

        Rect labelRect = new Rect(coinIconRect.xMax, coinIconRect.y, 60, 32);
        GUI.Label(labelRect, coins.ToString(), style);
    }

    void OnGUI() {
        DisplayCoinsCount();
        DisplayRestartButton();
		DisplayMenuButton ();
    }

    void DisplayRestartButton() {
        if (dead /*&& grounded*/)
        {
            Rect buttonRect = new Rect(Screen.width * 0.35f, Screen.height * 0.45f, Screen.width * 0.30f, Screen.height * 0.1f);
            if (GUI.Button(buttonRect, "Tap to restart!"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            };
        }
    }

	void DisplayMenuButton() {
		if (dead /*&& grounded*/)
		{
			Rect buttonRect = new Rect(Screen.width * 0.60f, Screen.height * 0.60f, Screen.width * 0.45f, Screen.height * 0.1f);
			if (GUI.Button(buttonRect, "Tap to Menu!"))
			{
				SceneManager.LoadScene("StartMenu");
			};
		}
	}
}
