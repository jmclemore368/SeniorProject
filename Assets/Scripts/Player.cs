using UnityEngine;

public class Player : MonoBehaviour {
    public WeaponSystem weaponSystem;
    public Health health;
    public GameUI gameUI;

    public bool pickupItem(int pickupType) {
        switch (pickupType) {
            case 0:
                return weaponSystem.PickupAmmo();
            case 1:
                return health.PickupArmor();
            case 2:
                return health.PickupHealth();
            default:
                Debug.LogError("Bad pickup type: " + pickupType);
                break;
        }
        return false;
    }

    public void SetPlayerAmmo(string message) {
        gameUI.SetAmmoText(message);
    }
    public void SetPlayerReserve(string message) {
        gameUI.SetReserveText(message);
    }
    public void SetPlayerArmor(int armor) {
        gameUI.SetArmorText(armor); 
    }
    public void SetPlayerHealth(int health) {
        gameUI.SetHealthText(health);
    }
    public void SetPlayerPickup(string message) {
        gameUI.SetPickUpText(message);
    }
}
