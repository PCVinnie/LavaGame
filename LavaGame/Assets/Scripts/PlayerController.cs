using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float jump;
    public GameObject Spawnpoint;

    private bool grounded = true;
    private Rigidbody rb;
    private int cameraRotation = 0;

    private Vector3 respawn;
    
    // Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.position = Spawnpoint.transform.position;
        respawn = Spawnpoint.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 movement;

        if (!grounded && rb.velocity.y == 0)
        {
            grounded = true;
        }

        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            float remember;

            switch (cameraRotation)
            {
                case 90:
                    remember = moveHorizontal;
                    moveHorizontal = -moveVertical;
                    moveVertical = remember;
                    break;
                case 180:
                    moveHorizontal *= -1;
                    moveVertical *= -1;
                    break;
                case 270:
                    remember = -moveHorizontal;
                    moveHorizontal = moveVertical;
                    moveVertical = remember;
                    break;
            }

            if (Input.GetKey("space") && grounded == true)
            {
                movement = new Vector3(moveHorizontal, jump, moveVertical);
                grounded = false;
            }
            else
                movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            rb.AddForce(movement * speed);
        }
        else
        {
            Input.gyro.enabled = true;
            if (Input.GetMouseButton(0) && grounded == true)
            {
                movement = new Vector3(Input.gyro.rotationRateUnbiased.y, jump, -Input.gyro.rotationRateUnbiased.x );
                //movement = new Vector3(Input.acceleration.x, jump, Input.acceleration.y);
                grounded = false;
            }
            else
            {
                movement = new Vector3(Input.gyro.rotationRateUnbiased.y , 0.0f, -Input.gyro.rotationRateUnbiased.x );
                //movement = new Vector3(Input.acceleration.x, 0.0f, Input.acceleration.y);
            }

            rb.AddForce(movement * speed);
        }
	}

    public void Respawn()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.position = respawn;
    }

    public void NewCheckpoint(Vector3 position)
    {
        respawn = position;
    }

    public void changeControlsForCamera(int cameraRotation)
    {
        this.cameraRotation += cameraRotation;

        if (this.cameraRotation == 360)
            this.cameraRotation = 0;
    }
}
