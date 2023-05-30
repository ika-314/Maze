using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MazeData : SingletonMonoBehaviour<MazeData>
{
    //迷路サイズ
    public int m_width = 18;
    public int m_height = 18;

    //スタートポジション
    public Vector3 startPosition;


    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
