using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_Player_Move : MonoBehaviour
{

    float playerSpeed = 1;  //プレイヤーのスピード
    float playerRotation = 90;  //プレイヤーの回転角度

    Rigidbody player_rigidbody;

    //レイ系
    Ray front_ray;
    RaycastHit front_ray_hit;
    Ray back_ray;
    RaycastHit back_ray_hit;
    float ray_dis = 1;
    
    
    // Start is called before the first frame update
    void Start()
    {
        player_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //前
        front_ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * ray_dis, Color.blue);

        //後ろ
        back_ray = new Ray(transform.position, -transform.forward);
        Debug.DrawRay(transform.position, -transform.forward * ray_dis, Color.black);

        //前動く
        if (!Physics.Raycast(front_ray, out front_ray_hit, ray_dis))
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.position += transform.forward * playerSpeed;
            }
        }
        //後ろに動く
        if(!Physics.Raycast(back_ray, out back_ray_hit, ray_dis))
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                transform.position += transform.forward * -playerSpeed;
            }
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
