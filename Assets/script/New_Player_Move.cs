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

    [SerializeField]
    GameObject minmap_Camera;

    Transform minCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        player_rigidbody = GetComponent<Rigidbody>();
         minCamera = minmap_Camera.GetComponent<Transform>();

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
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (Physics.Raycast(front_ray, out front_ray_hit, ray_dis))
            {
                if (front_ray_hit.collider.tag != "Wall")
                {
                    transform.position += transform.forward * playerSpeed;
                }
            }
            else
            {
                transform.position += transform.forward * playerSpeed;
            }
        }
        //後ろに動く
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (Physics.Raycast(back_ray, out back_ray_hit, ray_dis))
            {

                if (back_ray_hit.collider.tag != "Wall")
                {
                    transform.position += transform.forward * -playerSpeed;
                }
            }
            else
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
        minCamera.transform.position = new Vector3(transform.position.x, 10, transform.position.z);
    }
}
