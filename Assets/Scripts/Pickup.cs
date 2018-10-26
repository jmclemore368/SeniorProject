using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.GetComponent<Player>() != null
          && collider.gameObject.tag == "Player")
        {
            if (collider.gameObject.GetComponent<Player>().pickupAmmo())
                Destroy(gameObject);
        }
    }

}
