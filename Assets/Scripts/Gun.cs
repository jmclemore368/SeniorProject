using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    // The speed at which the gun will fire
    public float fireRate;

    // The last time the gun was fired
    protected float lastFireTime;

	// Use this for initialization
	void Start () {
        // Sets last fire time to 15 seconds ago
        // So player can shoot immediately upon playing
        lastFireTime = Time.time - 15;
	}
	
	// Update is called once per frame
    protected virtual void Update()
    {
    }

    protected void Fire()
    {
    }

}
