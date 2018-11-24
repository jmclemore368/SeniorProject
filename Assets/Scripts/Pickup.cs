using UnityEngine;

public class Pickup : MonoBehaviour {
    public int type;

    void OnTriggerEnter(Collider collider_) {
        Player player = collider_.gameObject.GetComponent<Player>();
        if (player != null) {
            bool pickedUpItem = player.pickupItem(type);
            if (pickedUpItem) {
                GetComponentInParent<SpawnPointPickup>().startRespawnTimer();
                Destroy(gameObject);
            }
        }
    }
}
