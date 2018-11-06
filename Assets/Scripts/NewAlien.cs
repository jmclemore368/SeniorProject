using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewAlien : MonoBehaviour {
    
    public int firingRange; // How far the alien must be before shooting its gun
    public float firingRate; // How fast the alien can fire its gun
    private float timeLastFired;
    UnityEngine.AI.NavMeshAgent agent; // Ref to the NavMesh Agent component ******
    private Transform player; // Ref to the player which the alien tries to find ******
    public Animator alien; // For playing animations
    public GameObject weapon; // To fire weapon

    private Health health;

    private string[] getHitAnimations = { "hitRight", "hitLeft"};

	// Use this for initialization
	void Start () {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        health = GetComponent<Health>();
	}
	
	// Update is called once per frame
	void Update () {
        if (player != null) {
            transform.LookAt(player); // Alien faces player
            agent.SetDestination(player.position); // Alien uses Nav Mesh to find player

            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            bool alienIsWithinFiringRange = distanceToPlayer < firingRange;
            float timeSinceLastFired = Time.time - timeLastFired;
            bool alienCanFireAgain = timeSinceLastFired > firingRate;

            if (alienIsWithinFiringRange && alienCanFireAgain)
            {
                timeLastFired = Time.time;
                fire();
            }
        }
        else {
            agent.isStopped = true;
            transform.LookAt(Vector3.zero);
            alien.Play("pose");
        }
	}

    private void fire()
    {
        weapon.GetComponent<Weapon>().AIFiring();
        alien.Play("fire");
    }

    void getHit()
    {
        // pick & play a random anim from the array,
        // excluding anim at index 0
        int n = Random.Range(1, getHitAnimations.Length);
        string randomAnim = getHitAnimations[n];

        alien.Play(randomAnim);

        // move picked sound to index 0 so it's not picked next time
        getHitAnimations[n] = getHitAnimations[0];
        getHitAnimations[0] = randomAnim;
    }
}
