using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;

    private bool Follow;
    private Vector3 offsetVector;
    private float offset;
    private PlayerController playerController;

    // Use this for initialization
    void Start () {
        GameObject gameControllerObject = GameObject.FindWithTag("Player");
        if (gameControllerObject != null)
        {
            playerController = gameControllerObject.GetComponent<PlayerController>();
        }
        if (player == null)
        {
            Debug.Log("Cannot find player script");
        }

        offsetVector = transform.position - player.transform.position;
        offset = offsetVector.z;
        Follow = true;
        transform.LookAt(player.transform.position);
    }
	
	// Update is called once per frame
	void LateUpdate () {
        if (Follow)
        {
            int rotation = 0;
            if (Input.GetKeyDown("r"))
            {
                rotation = -90;
                playerController.changeControlsForCamera(90);
                if(offsetVector.z == offset)
                {
                    offsetVector.x = -offset;
                    offsetVector.z = 0;
                }
                else if(offsetVector.x == offset)
                {
                    offsetVector.z = offset;
                    offsetVector.x = 0;
                }
                else if(offsetVector.z == -offset)
                {
                    offsetVector.x = offset;
                    offsetVector.z = 0;
                }
                else if(offsetVector.x == -offset)
                {
                    offsetVector.z = -offset;
                    offsetVector.x = 0;
                }
            }
            transform.position = player.transform.position + offsetVector;
            transform.RotateAround(player.transform.position, new Vector3(0.0f, 1.0f, 0.0f), rotation);
        }
    }

    public void SetFollow(bool follow)
    {
        Follow = follow;
    }
}
