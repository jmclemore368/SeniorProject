using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public WeaponSystem weaponSystem;
    public Health health;

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
