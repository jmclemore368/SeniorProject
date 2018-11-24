using UnityEngine;

public class BehaviorAlien : BehaviorEnemy {
    public Animator enemyAnimator;
    public GameObject weapon;
    private Transform player;

    public int attackRange;
    public float attackRate;
    private float lastAttackTime;
    private string[] getHitAnimations;

    private float losDistance = 9999.0f;

    void Start () {
        player = GameObject.FindGameObjectWithTag(Constants.playerTag).transform;
        getHitAnimations = new string[]{ "hitRight", "hitLeft" };
    }

    public override void playPose() {
        enemyAnimator.Play("pose");
    }

	public override void playAttack() {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        bool enemyIsWithinAttackRange = distanceToPlayer < attackRange;
        float timeSinceLastAttack = Time.time - lastAttackTime;
        bool enemyCanAttackAgain = timeSinceLastAttack > attackRate;
        bool enemyCanSeePlayer = PlayerIsInLineOfSight();
        if (enemyIsWithinAttackRange && enemyCanAttackAgain && enemyCanSeePlayer) {
            lastAttackTime = Time.time;
            weapon.GetComponent<Weapon>().AIFiring();
            enemyAnimator.Play("fire");
        }
	}

    public override void playNextGetHit() {
        int n = Random.Range(1, getHitAnimations.Length);
        string randomAnim = getHitAnimations[n];
        enemyAnimator.Play(randomAnim);
        getHitAnimations[n] = getHitAnimations[0];
        getHitAnimations[0] = randomAnim;
    }

    public override bool PlayerIsInLineOfSight() {
        Vector3 direction = player.position - transform.position;
        Ray ray = new Ray(transform.position, direction);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, losDistance))
            if (hit.transform == player)
                return true;
        return false;
    }

}
