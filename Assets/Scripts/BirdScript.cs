using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BirdScript : MonoBehaviour
{
    bool birdIsAlive = true;
    float birdStrength = 20;
    public int score = 0;
    [SerializeField] Text scoreText;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject deathSound;
    [SerializeField] GameObject scoreSound;
    [SerializeField] Rigidbody2D myRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || (Input.GetMouseButtonDown(0)) && birdIsAlive))
        {
            myRigidbody.velocity = Vector2.up * birdStrength;
        }
        if (gameObject.transform.position.y >= 24 || gameObject.transform.position.y <= -24)
        {
            birdIsAlive = false;
            gameOverScreen.SetActive(true);
            deathSound.SetActive(true);
            myRigidbody.gravityScale = 250;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Quit");
            Application.Quit();
        }
    }

    void OnTriggerEnter2D()
    {
        score++;
        scoreText.text = score.ToString();
        scoreSound.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        scoreSound.SetActive(false);
    }

    void OnCollisionEnter2D()
    {
        birdIsAlive = false;
        gameOverScreen.SetActive(true);
        deathSound.SetActive(true);
        myRigidbody.gravityScale = 250;
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
