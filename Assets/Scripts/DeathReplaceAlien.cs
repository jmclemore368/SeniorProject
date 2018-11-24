using System.Collections;
using UnityEngine;

public class DeathReplaceAlien : MonoBehaviour {
    public Animator enemyAnimator;
    private float deathAnimationLength = 3.85f;

	void Start() {
        enemyAnimator.Play("dead");
        GameController.RemoveEnemy();
        StartCoroutine("DestroyAlien");
	}
	
    IEnumerator DestroyAlien() {
        yield return new WaitForSeconds(deathAnimationLength);
        Destroy(gameObject);
    }
}
