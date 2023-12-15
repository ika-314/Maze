using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class goalScenets : MonoBehaviour
{

    public Text Firsttext, secondtext, thirdtext, fourthtext;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(MazeData.firsttext.text == null)
        {

        }
        else if(MazeData.firsttext.text != null)
        {
            Firsttext.text = MazeData.firsttext.text;
        }
        if(MazeData.secondtext.text == null)
        {

        }
        else if(MazeData.secondtext.text != null)
        {
            secondtext.text = MazeData.secondtext.text;
        }
        fourthtext.text = MazeData.fourthtext.text;
    }
}
