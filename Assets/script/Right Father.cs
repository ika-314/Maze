using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightFather : MonoBehaviour
{
    GameObject a;
    // Start is called before the first frame update
    void Start()
    {
        a = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        a.transform.position += new Vector3(Mathf.Sin(a.transform.rotation.y), 0, Mathf.Cos(a.transform.rotation.y));
        Debug.Log(Mathf.Sin(a.transform.rotation.y));
        Debug.Log(Mathf.Cos(a.transform.rotation.y));
        Debug.Log(a.transform.rotation);
    }
    private void OnTriggerStay(Collider wall)
    {
       // a.transform.position += new Vector3(Mathf.Sin(a.transform.rotation.y),0,Mathf.Cos(a.transform.rotation.y));
    }
}
