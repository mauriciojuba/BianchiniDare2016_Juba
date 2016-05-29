using UnityEngine;
using System.Collections;

public class AI_CommonEnemy : MonoBehaviour {

	NavMeshAgent agent;
	public  float      speed;
	public  float      rotSpeed;
	float      timer;
	Vector3    dir;
    EnemyRadar Eye;
    GameObject Player;


	private delegate void AIDelegate();
	private AIDelegate state;

	void Start () {
        Player = GameObject.Find("Player");
		state = new AIDelegate(Patroling);
		agent = GetComponent<NavMeshAgent>();
        Eye = GetComponentInChildren<EnemyRadar>();
		agent.SetDestination(Waypoints[currentWaypoint].position);
	}

	void Update () {
		state();
	}

    #region Patrol
    public Transform[] Waypoints;
	int currentWaypoint;
	public float distanceToChangeWaypoint;

	void Patroling(){
		if(agent.remainingDistance >= distanceToChangeWaypoint){
			agent.SetDestination(Waypoints[currentWaypoint].position);
		}
		else{
			if(currentWaypoint==Waypoints.Length) currentWaypoint = 0;
            else currentWaypoint++;
            agent.SetDestination(Waypoints[currentWaypoint].position);
		}

        if (Eye.onRadar)
        {
            DangerUI.Instance.onDanger();
            countToReturnPatroling = 0;
            state = new AIDelegate(Chasing);
        }
    }
    #endregion
    #region Chase
    float distanceToStopChasing = 7;
    float distanceToAttack = 3;
    void Chasing(){
        if (agent.remainingDistance <= distanceToStopChasing)
        {
            if(agent.remainingDistance <= distanceToAttack)
            {
                state = new AIDelegate(Attacking);
            }
            else agent.SetDestination(Player.transform.position);
        }
        else state = new AIDelegate(Searching);
    }
    #endregion
    #region Search
    float returnToPatrol = 3;
    float countToReturnPatroling = 0;
    void Searching(){
        countToReturnPatroling += Time.deltaTime;
        if(countToReturnPatroling >= returnToPatrol)
        {
            state = new AIDelegate(Patroling);
        }
        if (Eye.onRadar)
        {
            DangerUI.Instance.onDanger();
            countToReturnPatroling = 0;
            state = new AIDelegate(Chasing);
        }
    }
    #endregion
    #region Attack
    float distanceToStopAttacking = 7;
    void Attacking(){
        if (Vector3.Distance(Player.transform.position,transform.position)<=distanceToStopAttacking)
        {
            transform.LookAt(new Vector3(Player.transform.position.x, transform.position.y, Player.transform.position.z));
        }
        else
        {
            DangerUI.Instance.NotDanger();
            state = new AIDelegate(Searching);
        }

	}
    #endregion
}
