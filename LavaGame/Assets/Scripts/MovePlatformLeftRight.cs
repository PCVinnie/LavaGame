﻿using UnityEngine;
using System.Collections;

public class MovePlatformLeftRight : MonoBehaviour
{

    private bool asPosition = true;
    public float leftPosition = 0.0f;
    public float rightPosition = 0.0f;

    // Update is called once per frame
    void Update()
    {

        if (asPosition == true)
        {
            Vector3 left = Vector3.left;
            transform.Translate(left * Time.deltaTime, Space.World);
            if (transform.position.x < leftPosition)
            {
                asPosition = false;
            }
        }
        if (asPosition == false)
        {
            Vector3 right = Vector3.right;
            transform.Translate(right * Time.deltaTime, Space.World);
            if (transform.position.x > rightPosition)
            {
                asPosition = true;
            }
        }

    }

}
