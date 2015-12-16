using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;

    private bool Follow;
    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position;
        Follow = true;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if(Follow)
            transform.position = player.transform.position + offset;
    }

    public void SetFollow(bool follow)
    {
        Follow = follow;
    }
}
