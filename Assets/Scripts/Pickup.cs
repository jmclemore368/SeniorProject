using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    public int type;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.GetComponent<Player>() != null)
        {
            if (collider.gameObject.GetComponent<Player>().pickupItem(type)) {
                GetComponentInParent<PickupSpawnPoint>().didPickup();
                Destroy(gameObject);
            }
        }
    }
}
