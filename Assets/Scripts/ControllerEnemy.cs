using UnityEngine;

public class ControllerEnemy : MonoBehaviour {
    UnityEngine.AI.NavMeshAgent agent;
    private Transform player;
    public BehaviorEnemy behavior;

	void Start() {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag(Constants.playerTag).transform;
        behavior = GetComponent<BehaviorEnemy>();
	}
	
	void Update() {
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
