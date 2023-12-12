using System.Collections;
using UnityEngine;
using System;
using System.Collections.Generic;

public class Random : MonoBehaviour
{
    public enum Direction
    {
        LEFT,
        RIGHT,
        FOWARD,
        BACK,
    }
    Direction direction;

    float playerSpeed　= 3;


    Ray right_ray;
    RaycastHit right_ray_hit;

    Ray foward_ray;
    RaycastHit foward_ray_hit;

    Ray back_ray;
    RaycastHit back_ray_hit;

    Ray left_ray;
    RaycastHit left_ray_hit;

    float ray_dis = 1f;
    int i = 0;

    List<Direction> hitList = new List<Direction>();



    void Update()
    {

        right_ray = new Ray(transform.localPosition, transform.right);
        Debug.DrawRay(transform.localPosition , transform.right * ray_dis, Color.blue);

        foward_ray = new Ray(transform.localPosition, transform.forward);
        Debug.DrawRay(transform.localPosition , transform.forward * ray_dis, Color.yellow);

        back_ray = new Ray(transform.localPosition, -transform.forward);
        Debug.DrawRay(transform.localPosition , transform.forward * -ray_dis, Color.green);

        left_ray = new Ray(transform.localPosition , -transform.right);
        Debug.DrawRay(transform.localPosition , transform.right * -ray_dis, Color.red);
        //ランダムくん動き
        // transform.position += new Vector3((int)UnityEngine.Random.Range(-playerSpeed, playerSpeed) * Time.deltaTime, 0, (int)UnityEngine.Random.Range(-playerSpeed, playerSpeed) * Time.deltaTime);

        Invoke("Sarch", 0.33f);
    }

    public void Sarch()
    {
        /*
        if (!Physics.Raycast(right_ray, out right_ray_hit, ray_dis) && right_ray_hit.collider.gameObject.tag != "Wall")
        {
            
            hitList.Add(Direction.RIGHT);
        }*/

        if (!Physics.Raycast(right_ray, out right_ray_hit, ray_dis))
        {
            hitList.Add(Direction.RIGHT);
        }
        if (!Physics.Raycast(left_ray, out left_ray_hit, ray_dis))
        {
            hitList.Add(Direction.LEFT);
        }
        if (!Physics.Raycast(back_ray, out back_ray_hit, ray_dis))
        {
            hitList.Add(Direction.BACK);
        }
        if (!Physics.Raycast(foward_ray, out foward_ray_hit, ray_dis))
        {
            hitList.Add(Direction.FOWARD);
        }

        System.Random rnd = new System.Random();
        int randIndex = rnd.Next(hitList.Count);
        direction = hitList[randIndex];

        Move(direction);

        //Invoke("stopFowrd", 0.33f);

    }

    private void Move(Direction direction)
    {
        if(direction == Direction.LEFT)
        {
            transform.position += new Vector3(-1, 0, 0);
        }
        if (direction == Direction.BACK)
        {
            transform.position += new Vector3(0, 0, -1);
        }
        if (direction == Direction.FOWARD)
        {
            transform.position += new Vector3(0, 0, 1);
        }
        if (direction == Direction.RIGHT)
        {
            transform.position += new Vector3(1, 0, 0);
        }

    }
}
