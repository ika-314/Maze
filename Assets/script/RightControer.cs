using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightControer : MonoBehaviour
{
    Rigidbody main_rigidbody;
    GameObject a;
    // Start is called before the first frame update
    void Start()
    {
        a = gameObject.transform.parent.gameObject;
        main_rigidbody = a.GetComponent<Rigidbody>();       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerStay(Collider wall)
    {
        if (wall.gameObject.name == "wall")
        {
            main_rigidbody.velocity  += new Vector3(0, 0, 1)*Time.deltaTime;
        }
        else if (wall.gameObject == null || wall.gameObject.name != "wall")
        {
            a.transform.rotation *= Quaternion.Euler(0, 20, 0);
            
        }
    }
}
