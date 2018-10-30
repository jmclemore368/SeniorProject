using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public WeaponSystem weaponSystem;
    public Health health;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public bool pickupItem(int pickupType) {
        switch (pickupType)
        {
            case 0:
                return weaponSystem.PickupAmmo();
            case 1:
                return health.PickupArmor();
            default:
                Debug.LogError("Bad pickup type: " + pickupType);
                break;
        }
        return false;
    }

}
