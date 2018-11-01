using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    public int type;

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
            if (collider.gameObject.GetComponent<Player>().pickupItem(type)) {
                GetComponentInParent<PickupSpawner>().didPickup();
                Destroy(gameObject);
            }
        }
    }
}
