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
		

	}
	void Update()
	{
		//Debug.Log("X:" + -MazeData.Instance.startPosition.x);
		//Debug.Log("Y:" + MazeData.Instance.startPosition.y);
		//Debug.Log("Z:" + -MazeData.Instance.startPosition.z);
		a.SetDestination(goal);
		//GetComponent<Animator>().SetFloat("Speed", a.velocity.magnitude);

		// 移動量の取得
		//Debug.Log(a.velocity.magnitude);
	}

}