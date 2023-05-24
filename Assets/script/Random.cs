using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random : MonoBehaviour
{
    float playerSpeed　= 3;
   
    void Update()
    {
        //ランダムくん動き
        transform.position += new Vector3((int)UnityEngine.Random.Range(-playerSpeed, playerSpeed) * Time.deltaTime, 0, (int)UnityEngine.Random.Range(-playerSpeed, playerSpeed) * Time.deltaTime);

    }
}
