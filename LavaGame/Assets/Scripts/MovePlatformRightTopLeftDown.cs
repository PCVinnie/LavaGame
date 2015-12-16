using UnityEngine;
using System.Collections;

public class MovePlatformRightTopLeftDown : MonoBehaviour {

    private bool asPosition = true;
    private bool asSwitch = true;
    public float upPosition = 0.0f;
    public float downPosition = 0.0f;
    public float rightPosition = 0.0f;
    public float leftPosition = 0.0f;

    // Update is called once per frame
    void Update () {

        if (asPosition == true)
        {
            Vector3 up = Vector3.up;
            transform.Translate(up * Time.deltaTime, Space.World);

            if (asSwitch == true)
            {
                Vector3 right = Vector3.right;
                transform.Translate(right * Time.deltaTime, Space.World);
            }
            if (transform.position.y > upPosition &&
                transform.position.x > rightPosition)
            {
                asPosition = false;
                asSwitch = false;
            }
        }
        if (asPosition == false)
        {
            Vector3 down = Vector3.down;
            transform.Translate(down * Time.deltaTime, Space.World);

            if (asSwitch == false)
            {
                Vector3 left = Vector3.left;
                transform.Translate(left * Time.deltaTime, Space.World);
            }
            if (transform.position.y < downPosition &&
                transform.position.x < leftPosition)
            {
                asPosition = true;
                asSwitch = true;
            }

        }

    }
}
