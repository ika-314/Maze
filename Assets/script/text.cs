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
    public Button mode;
    public Text height_text;
    public Text width_text;
    public static Slider h_value;
    public static Slider w_value;
    public Text mode_text;

    int i = 0;


    // Start is called before the first frame update
    void Start()
    {
        
        h_value = n_height.GetComponent<Slider>();
        w_value = n_width.GetComponent<Slider>();
        width_text = width_text.GetComponent<Text>();
        height_text = height_text.GetComponent<Text>();
        mode_text = mode_text.GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        if(i == 0)
        {
            mode_text.text = "難易度：イージー";
            w_value.value = 11;
            h_value.value = 11;


        }else if(i == 1)
        {
            mode_text.text = "難易度：ノーマル";
            w_value.value = 33;
            h_value.value = 33;
        }else if(i == 2)
        {
            mode_text.text = "難易度：ハード";
            w_value.value = 75;
            h_value.value = 75;
        }else if(i == 3)
        {
            mode_text.text = "難易度：フリー";
        }
    }

     public void Fps()
    {
        SceneManager.LoadScene("Main");
    }
    　public void dyu()
    {
        SceneManager.LoadScene("Main3D");
    }
      public void Mode()
    {
         if(i < 3)
        {
            i++;
        }
        else
        {
            i = 0;
        }
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
