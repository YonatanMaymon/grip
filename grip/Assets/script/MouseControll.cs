using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControll : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false; // Hide the mouse cursor
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
        
    }

}
