using UnityEngine;
using System.Collections;

public class AI_CommonEnemy : MonoBehaviour {

	//public  GameObject target;
	NavMeshAgent agent;
	public  float      speed;
	public  float      rotSpeed;
	private float      timer;
	private Vector3    dir;


	private delegate void AIDelegate();
	private AIDelegate state;

	void Start () {
		state = new AIDelegate(Patrolling);
		agent = GetComponent<NavMeshAgent>();
		agent.SetDestination(Waypoints[currentWaypoint].position);
	}

	void Update () {
		Debug.Log(agent.remainingDistance);
		state();
	}

	public Transform[] Waypoints;
	int currentWaypoint;
	public float distanceToChangeWaypoint;


	void Patrolling(){
		if(agent.remainingDistance >= distanceToChangeWaypoint){
			agent.SetDestination(Waypoints[currentWaypoint].position);
		}
		else{
			agent.SetDestination(Waypoints[currentWaypoint].position);
			currentWaypoint++;
			if(currentWaypoint==Waypoints.Length) currentWaypoint = 0;
		}
	}

	void Chasing(){
	}
	void Searching(){
	}
	void Attacking(){
	}
}
