using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_Player_Move : MonoBehaviour
{
    float playerSpeed = 1;
    float playerRotation = 90;
    Rigidbody player_rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        player_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position += transform.forward * playerSpeed;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position += transform.forward* -playerSpeed;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.rotation *= Quaternion.Euler(0, playerRotation, 0);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.rotation *= Quaternion.Euler(0, -playerRotation, 0);
        }
    }
}
