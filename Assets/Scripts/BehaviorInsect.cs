using UnityEngine;
using System.Collections;

public class BehaviorInsect : BehaviorEnemy
{
    public Animator enemyAnimator;
    private Transform player;
    private AudioSource source;

    public int attackRange;
    public float attackRate;
    private float lastAttackTime;
    private string[] attackAnimations;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(Constants.playerTag).transform;
        attackAnimations = new string[] { "Walk_Attack", "Walk_Attack2" };
        source = GetComponent<AudioSource>();
    }

    public override void playPose()
    {
        enemyAnimator.Play("Idle");
    }

    public override void playAttack()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        bool enemyIsWithinAttackRange = distanceToPlayer < attackRange;
        float timeSinceLastAttack = Time.time - lastAttackTime;
        bool enemyCanAttackAgain = timeSinceLastAttack > attackRate;

        if (enemyIsWithinAttackRange && enemyCanAttackAgain)
        {
            lastAttackTime = Time.time;
            playAttackHelper();
           
        }
    }

    private void playAttackHelper() {
        int n = Random.Range(1, attackAnimations.Length);
        string randomAnim = attackAnimations[n];
        enemyAnimator.Play(randomAnim);
        attackAnimations[n] = attackAnimations[0];
        attackAnimations[0] = randomAnim;

        source.Play();

        player.gameObject.SendMessageUpwards("ChangeHealth",
                                           new DamageInfo(-50, transform.root.gameObject),
                                           SendMessageOptions.DontRequireReceiver);
    }

    public override void playNextGetHit()
    {
        enemyAnimator.Play("Walk_GetHit");

    }
}
