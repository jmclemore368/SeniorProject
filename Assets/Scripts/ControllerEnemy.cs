using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerEnemy : MonoBehaviour {

    UnityEngine.AI.NavMeshAgent agent;
    private Transform player;
    public BehaviorEnemy behavior;

	// Use this for initialization
	void Start () 
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag(Constants.playerTag).transform;
        behavior = GetComponent<BehaviorEnemy>();

	}
	
	// Update is called once per frame
	void Update () 
    {
        if (player == null) {
            transform.LookAt(Vector3.zero);
            agent.isStopped = true;
            behavior.playPose();
        }
        else {
            transform.LookAt(player); 
            agent.SetDestination(player.position);
            behavior.playAttack();
        }
	}
}
