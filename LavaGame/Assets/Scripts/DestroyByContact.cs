using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

    public int scoreValue;
    private GameController gameController;

    // Use this for initialization
    void Start () {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find GameController script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //gameController.GameOver();

            gameController.addScore(scoreValue);
            Destroy(gameObject);
        }
    }
}
