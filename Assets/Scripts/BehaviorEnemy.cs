using UnityEngine;
using System.Collections;

public abstract class BehaviorEnemy : MonoBehaviour
{
    public abstract void playPose();
    public abstract void playAttack();
    public abstract void playNextGetHit();
}
