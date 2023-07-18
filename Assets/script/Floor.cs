using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Floor : MonoBehaviour
{
    int a = 0;

    void Update()
    {
        if (a == 0)
        {
            GetComponent<NavMeshSurface>().BuildNavMesh();
        }
        a++;
    }
}
