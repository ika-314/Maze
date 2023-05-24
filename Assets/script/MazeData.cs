using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MazeData : SingletonMonoBehaviour<MazeData>
{
    //public Transform cameraPosition;
    public int m_width = 18;
    public int m_height = 18;
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
        //transform.position = cameraPosition.position;        
    }
}
