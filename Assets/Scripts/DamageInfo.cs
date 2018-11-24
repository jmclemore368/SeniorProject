using UnityEngine;

public class DamageInfo {
    public float amount;
    public GameObject from;

    public DamageInfo(float amount, GameObject from) {
        this.amount = amount;
        this.from = from;
    }
}