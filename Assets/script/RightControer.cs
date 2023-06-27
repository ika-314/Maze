using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightControer : MonoBehaviour
{
    

    Ray right_flont_ray;
    RaycastHit right_flont_ray_hit;

    Ray left_flont_ray;
    RaycastHit left_flont_ray_hit;

    Ray right_back_ray;
    RaycastHit right_back_ray_hit;

    Ray left_back_ray;
    RaycastHit left_back_ray_hit;


    float ray_dis = 1;

    bool coll = false;
    // Start is called before the first frame update
    void Start()
    {
              
    }

    // Update is called once per frame
    void Update()
    {
        right_flont_ray = new Ray(transform.localPosition + new Vector3(0,0,0.5f), transform.right);
        Debug.DrawRay(transform.localPosition + new Vector3(0, 0, 0.5f), transform.right * ray_dis, Color.blue);

        left_flont_ray = new Ray(transform.localPosition + new Vector3(0, 0, 0.5f), -transform.right);
        Debug.DrawRay(transform.localPosition + new Vector3(0, 0, 0.5f), -transform.right * ray_dis, Color.red);

        right_back_ray = new Ray(transform.localPosition + new Vector3(0, 0, -0.5f), transform.right);
        Debug.DrawRay(transform.localPosition + new Vector3(0, 0, -0.5f), transform.right * ray_dis, Color.blue);

        left_back_ray = new Ray(transform.localPosition + new Vector3(0, 0, -0.5f), -transform.right);
        Debug.DrawRay(transform.localPosition + new Vector3(0, 0, -0.5f), -transform.right * ray_dis, Color.red);

        if (Physics.Raycast(right_flont_ray, out right_flont_ray_hit, ray_dis)&& Physics.Raycast(right_back_ray, out right_back_ray_hit, ray_dis))
        {
        //    if (right_ray_hit.collider.tag == "Wall" && coll == false)
        //    {
        //        transform.position += transform.right * 0.05f;
        //        Debug.Log("a");
        //    }
        //    else if(right_ray_hit.collider.tag == "Wall" && coll)
        //    {
        //        transform.position += transform.forward * 0.05f;
        //        Debug.Log("b");
        //    }
        //    if (right_ray_hit.collider.tag != "Wall")
        //    {
        //        transform.rotation *= Quaternion.Euler(0, 10, 0);
        //        Debug.Log("c");
        //    }
        //}else
        //{
        //    transform.rotation *= Quaternion.Euler(0, 10, 0);
        //    Debug.Log("d");
        }

        if(Physics.Raycast(left_flont_ray,out left_flont_ray_hit, ray_dis)&& Physics.Raycast(left_back_ray,out left_back_ray_hit, ray_dis))
        {

        }
        coll = false;
    }
    public void OnCollisionStay(Collision wall)
    {
        if (wall.gameObject.tag == "Wall")
        {
            coll = true;
        }
    }
}
