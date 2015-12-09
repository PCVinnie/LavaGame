using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float jump;

    private bool grounded = true;
    private Rigidbody rb;
    
    // Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
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

        if (Input.GetKeyDown("space") && grounded == true)
        {
            movement = new Vector3(moveHorizontal, jump, moveVertical);
            grounded = false;
        }
        else
            movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ice Cube"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
