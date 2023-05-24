using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControer : MonoBehaviour
{
    float playerSpeed = 3;//プレイヤースピード

    Rigidbody Player_Rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        Player_Rigidbody = GetComponent<Rigidbody>();        
    }
    private void FixedUpdate()
    {
        //プレイヤーの動き
            Player_Rigidbody.position += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * playerSpeed * Time.deltaTime;
        
    }
}
