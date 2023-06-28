using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightControer : MonoBehaviour
{
    

    Ray right_flont_ray;
    RaycastHit right_flont_ray_hit;

    Ray foward_right_ray;
    RaycastHit foward_right_ray_hit;

    Ray right_back_ray;
    RaycastHit right_back_ray_hit;

    Ray foward_left_ray;
    RaycastHit foward_left_ray_hit;


    float ray_dis = 1;

    bool isGoing = false;
    bool istuan = true;
    // Start is called before the first frame update
    void Start()
    {
              
    }
     
    // Update is called once per frame
    void Update()
    {
        right_flont_ray = new Ray(transform.localPosition + transform.forward * 0.4f, transform.right);
        Debug.DrawRay(transform.localPosition + transform.forward * 0.4f, transform.right * ray_dis, Color.blue);

        foward_right_ray = new Ray(transform.localPosition + transform.right * 0.4f, -transform.forward);
        Debug.DrawRay(transform.localPosition + transform.right * 0.4f, transform.forward * ray_dis, Color.yellow);

        right_back_ray = new Ray(transform.localPosition - transform.forward * 0.4f, transform.right);
        Debug.DrawRay(transform.localPosition - transform.forward * 0.4f, transform.right * ray_dis, Color.green);

        foward_left_ray = new Ray(transform.localPosition - transform.right * 0.4f, transform.forward);
        Debug.DrawRay(transform.localPosition - transform.right * 0.4f, transform.forward * ray_dis, Color.red);





        if (!Physics.Raycast(right_flont_ray, out right_flont_ray_hit, ray_dis)&& !Physics.Raycast(right_back_ray, out right_back_ray_hit, ray_dis))
        {
            if (istuan)
            {
                istuan = false;
                turn(1);
            }
        }
        else if(!Physics.Raycast(foward_right_ray,out foward_right_ray_hit, ray_dis)&& !Physics.Raycast(foward_left_ray,out foward_left_ray_hit, ray_dis))
        {
            if (istuan)
            {
                istuan = false;
                turn(-1);
            }
        }
        
        transform.position += transform.forward * 3 *Time.deltaTime;
        
        
    }

    public void turn(int side)
    {
       
        transform.rotation *= Quaternion.Euler(0, 90 * side, 0);
        isGoing = true;
        Invoke("stopFowrd", 1);

        /*
        if (isGoing)
        {
            Debug.Log("stop");
            transform.position += transform.forward * 3 * Time.deltaTime;
        }

        

    }
    void stopFowrd()
    {
        isGoing = false;
        istuan = true;
    }

    
}
