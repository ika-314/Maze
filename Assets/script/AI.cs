using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI: MonoBehaviour
{
	Vector3 goal;
	NavMeshAgent a;

	void Awake()
	{ 
		a = GetComponent<NavMeshAgent>();
	}
    private void Start()
    {		
		goal = new Vector3(-MazeData.Instance.startPosition.x, MazeData.Instance.startPosition.y, -MazeData.Instance.startPosition.z);
		a.speed = 4f;

	}
	void Update()
	{
		a.SetDestination(goal);
	}

}