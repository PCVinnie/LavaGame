using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour
{

    // Use this for initialization

    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
