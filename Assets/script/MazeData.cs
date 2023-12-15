using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MazeData : SingletonMonoBehaviour<MazeData>
{
    //迷路サイズ
    public int m_width = 18;
    public int m_height = 18;

    //スタートポジション
    public Vector3 startPosition;

    //タイマーデータ
    public static Text firsttext, secondtext, thirdtext, fourthtext;
    public static bool player, random, right, AI;
    public float Timer = 0;

    public static MazeData instance;    //関数に外部からアクセス

    int n = 0;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
        player = true;
        random = true;
        right = true;
        AI = true;
    }
 
    void Update()
    {
        startPosition = new Vector3((m_width / 2 - 1) * -1, -0.5f, ((int)m_height / 2 - 1) * -1);
        //リセット
        if (Input.GetKey(KeyCode.R))
        {
            
            SceneManager.LoadScene("START");

        }
    }
    

}
