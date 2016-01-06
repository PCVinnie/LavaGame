using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Text scoreText;
    public Text livesText;
    public int lives;

    private int score;
    private bool gameOver;
    private bool restart;

    private PlayerController player;
    private CameraController camera;


    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("MainCamera");
        if (gameControllerObject != null)
        {
            camera = gameControllerObject.GetComponent<CameraController>();
        }
        if (camera == null)
        {
            Debug.Log("Cannot find Camera script");
        }

        gameControllerObject = GameObject.FindWithTag("Player");
        if (gameControllerObject != null)
        {
            player = gameControllerObject.GetComponent<PlayerController>();
        }
        if (player == null)
        {
            Debug.Log("Cannot find player script");
        }

        gameOver = false;
        restart = false;
        score = 0;
        UpdateScore();
        UpdateLives();
        //StartCoroutine(SpawnWaves());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    public void addLife()
    {
        lives++;
        UpdateLives();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    void UpdateLives()
    {
        livesText.text = "Lives: " + lives;
    }

    public IEnumerator PlayerLostLife()
    {
        camera.SetFollow(false);

        yield return new WaitForSeconds(2);

        lives--;
        UpdateLives();

        if (lives > 0)
        {
            player.Respawn();
            camera.SetFollow(true);
        }
        else
        {

        }
    }

    IEnumerator Wait(float duration)
    {
        //This is a coroutine
        Debug.Log("Start Wait() function. The time is: " + Time.time);
        Debug.Log("Float duration = " + duration);
        yield return new WaitForSeconds(duration);   //Wait
        Debug.Log("End Wait() function and the time is: " + Time.time);
    }

    public void GameOver()
    {
        //gameOverText.text = "Game Over!";
        gameOver = true;
    }
}
