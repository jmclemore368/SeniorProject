using UnityEngine;

public abstract class BehaviorEnemy : MonoBehaviour {
    public abstract void playPose();
    public abstract void playAttack();
    public abstract void playNextGetHit();
    public abstract bool PlayerIsInLineOfSight();
}
