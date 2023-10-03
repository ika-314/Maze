using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class goal : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("a");
        //プレイヤー
        if (collision.gameObject.layer == 1)
        {
            //Debug.Log("l");
            SceneManager.LoadScene("Gool");
        }
        
        if(collision.gameObject.layer == 7)
        {
            Debug.Log("B");
            //ランダム
            if (collision.gameObject.name == "Random(Clone)")
            {
                Debug.Log("C");
                MakeMaze.instance.TimerCounter("ランダム");
                
            }
        }
        if (collision.gameObject.layer == 6)
        {
            Debug.Log("B");
            //ランダム
            if (collision.gameObject.name == "AI(Clone)")
            {
                Debug.Log("C");
                MakeMaze.instance.TimerCounter("AI");

            }
            if(collision.gameObject.name == "Right(Clone)")
            {
                MakeMaze.instance.TimerCounter("Right");
            }
        }

    }
    
}
