using UnityEngine;
using System.Collections;

public class BeamRotator : MonoBehaviour {

    // Use this for initialization
    void Update()
    {
        transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime);
    }
}
