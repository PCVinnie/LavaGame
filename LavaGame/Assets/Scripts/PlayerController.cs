using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float jump;
    public GameObject Spawnpoint;

    private bool grounded = true;
    private Rigidbody rb;

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

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if(!grounded && rb.velocity.y == 0)
        {
            grounded = true;
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
}
