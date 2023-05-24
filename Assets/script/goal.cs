using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class goal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("a");
        //プレイヤー
        if (collision.gameObject.layer == 1)
        {
            Debug.Log("l");
            SceneManager.LoadScene("Gool");
        }
        
        if(collision.gameObject.layer == 6)
        {
            Debug.Log("B");
            //ランダム
            if (collision.gameObject.name == "Random(Clone)")
            {
                Debug.Log("C");
                MakeMaze.instance.TimerCounter("ランダム");
                
            }
        }
        
    }
    
}
