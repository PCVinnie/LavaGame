using UnityEngine;
using System.Collections;

public class GameMenu : MonoBehaviour {

    public int index = 1;
    private Renderer ren;

    void Start()
    {
        ren = GetComponent<Renderer>();
    }

    void OnMouseEnter() {
        //Change text color
        ren.material.color = Color.red;
    }

    void OnMouseExit() {
        //Change text color
        ren.material.color = Color.white;
    }

    void OnMouseUp() {
        //Mouse and touchscreen
        if (index == 0) {
            //Quit the game
            Application.Quit();
        }
        if (index == 1) {
            //Load level
            Application.LoadLevel(1);
        }
        if (index == 2) {
            //Load level
            Application.LoadLevel(2);
        }
        if (index == 3) {
            //Load level
            Application.LoadLevel(3);
        }
        if (index == 4) {
            //Load level
            Application.LoadLevel(4);
        }
    }

    void Update() {
        // Keyboard
        if (Input.GetKey(KeyCode.Escape)) {
            Application.Quit();
        }
        if (Input.GetKey(KeyCode.Alpha1))
        {
            Application.LoadLevel(1);
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            Application.LoadLevel(2);
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            Application.LoadLevel(3);
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            Application.LoadLevel(4);
        }
    }

}