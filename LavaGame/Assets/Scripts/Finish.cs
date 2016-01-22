using UnityEngine;
using System.Collections;

public class Finish : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Application.LoadLevel(0);
        }
    }
}
