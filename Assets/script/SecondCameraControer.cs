using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondCameraControer : MonoBehaviour
{
    float m_height;
    float m_width;
    // Start is called before the first frame update
    private void Awake()
    {
        m_width = MazeData.Instance.m_width;
        m_height = MazeData.Instance.m_height;
    }
    void Start()
    {

        if (m_height <= m_width * 9 / 16)
        {
            transform.position = new Vector3(transform.position.x, m_width * 9 / 16, transform.position.z);
        }
        else if (m_height > m_width * 9 / 16)
        {
            transform.position = new Vector3(transform.position.x, m_height, transform.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
