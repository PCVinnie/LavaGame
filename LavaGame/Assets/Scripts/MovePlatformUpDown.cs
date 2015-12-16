using UnityEngine;
using System.Collections;

public class MovePlatformUpDown : MonoBehaviour
{

    private bool asPosition = true;
    public float upPosition = 0.0f;
    public float downPosition = 0.0f;

    // Update is called once per frame
    void Update()
    {

        if (asPosition == true)
        {
            Vector3 up = Vector3.up;
            transform.Translate(up * Time.deltaTime, Space.World);
            if (transform.position.y > upPosition)
            {
                asPosition = false;
            }
        }
        if (asPosition == false)
        {
            Vector3 down = Vector3.down;
            transform.Translate(down * Time.deltaTime, Space.World);
            if (transform.position.y < downPosition)
            {
                asPosition = true;
            }
        }

    }

}
