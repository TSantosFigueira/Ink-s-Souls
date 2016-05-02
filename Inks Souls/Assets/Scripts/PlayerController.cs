using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float jetpackForce = 75.0f;
    public float forwardMovementSpeed = 4.0f;

    Animator animator;

    const int state_iddle = 0;
    const int state_flying = 1;

    int _currentAnimationState = 0;

    public static bool dead = false;
    public static uint coins = 0;

    private int highestScore = 0; // mudar aqui caso seja necessário acessar de outra classe

    public GUIStyle restartButtonStyle;

    void Awake() {

        dead = false;
        coins = 0;   
    }

    void Start() {

        animator = this.GetComponent<Animator>();
        
        //Recupera o high score do sistema
        highestScore = PlayerPrefs.GetInt("highScore", 0);
    }

    void OnCollisionEnter2D (Collision2D coll)
    {
        if (coll.gameObject.name == "floor")
        {
            animator.SetInteger("State", state_iddle);
        }
    }

    void FixedUpdate() {
        bool jetpackActive = Input.GetButton("Fire1");

        jetpackActive = jetpackActive && !dead;

        if (jetpackActive) {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jetpackForce));
        }

        if (!dead) {
            Vector2 newVelocity = GetComponent<Rigidbody2D>().velocity;
            if (coins >= 1500 && coins < 3000)
                forwardMovementSpeed = 5.0f;
            else if (coins >= 3000 && coins < 7000)
                forwardMovementSpeed = 8.0f;
            else if (coins >= 7000)
                forwardMovementSpeed = 10.0f;
             
            newVelocity.x = forwardMovementSpeed;
            GetComponent<Rigidbody2D>().velocity = newVelocity;
        }

        if (Input.GetButton("Fire1"))
        {
            animator.SetInteger("State", state_flying);
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.CompareTag("Coins"))
            CollectCoin(collider);
        else
            HitByEnemy(collider);
    }

    void HitByEnemy(Collider2D enemyCollider) {
        //dead = true;
    }

    void CollectCoin(Collider2D coinCollider) {
        coins+=100;

        // Salva o score mais alto no sistema. 
        if (coins > highestScore)
        {
            PlayerPrefs.SetInt("highScore", (int)coins);
        }

        Destroy(coinCollider.gameObject);
    }
}
