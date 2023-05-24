using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class text : MonoBehaviour
{
    
    public Slider n_height;
    public Slider n_width;
    public Button fps;
    public Button Dyu;
    public Text height_text;
    public Text width_text;
    public static Slider h_value;
    public static Slider w_value;

    // Start is called before the first frame update
    void Start()
    {
        
        h_value = n_height.GetComponent<Slider>();
        w_value = n_width.GetComponent<Slider>();
        width_text = width_text.GetComponent<Text>();
        height_text = height_text.GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void Fps()
    {
        SceneManager.LoadScene("Main");
    }
    　public void dyu()
    {
        SceneManager.LoadScene("main2");
    }
    public void height()
    {
        height_text.text =h_value.value.ToString();
        MazeData.Instance.m_height = (int)h_value.value;        
    }
    public void width()
    {
        width_text.text = w_value.value.ToString();
        MazeData.Instance.m_width = (int)w_value.value;
    }
}
