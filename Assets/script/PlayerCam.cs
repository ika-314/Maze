using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotation;
    float yRotation;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            turnRight();
        }

        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
    private void turnRight()
    {
        transform.rotation *= Quaternion.Euler(0, 90, 0);
        orientation.rotation*= Quaternion.Euler(0, 90, 0);
    }   
}
