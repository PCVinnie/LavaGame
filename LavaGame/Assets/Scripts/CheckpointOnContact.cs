using UnityEngine;
using System.Collections;

public class CheckpointOnContact : MonoBehaviour {

    private PlayerController playerController;

    // Use this for initialization
    void Start () {
        GameObject gameControllerObject = GameObject.FindWithTag("Player");
        if (gameControllerObject != null)
        {
            playerController = gameControllerObject.GetComponent<PlayerController>();
        }
        if (playerController == null)
        {
            Debug.Log("Cannot find GameController script");
        }
    }
	
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            Vector3 checkpoint = this.gameObject.transform.position;
            checkpoint.y += 1;
            playerController.NewCheckpoint(checkpoint);
        }
    }
}
