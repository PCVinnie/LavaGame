using UnityEngine;
using System.Collections;

public class DestroyByGround : MonoBehaviour {

    public GameObject explosion;

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
            Instantiate(explosion, other.transform.position, other.transform.rotation);
            StartCoroutine(gameController.PlayerLostLife());
            //gameController.GameOver();

            //gameController.addScore(scoreValue);
            //Destroy(gameObject);
            
            //Destroy(other.gameObject);
        }
    }
}
