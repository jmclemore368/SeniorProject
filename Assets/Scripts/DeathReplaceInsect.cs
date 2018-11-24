using System.Collections;
using UnityEngine;

public class DeathReplaceInsect : MonoBehaviour {
    public Animator enemyAnimator;
    private float deathAnimationLength = 2.5f;

    void Start() {
        enemyAnimator.Play("Dead");
        GameController.RemoveEnemy();
        StartCoroutine("DestroyInsect");
    }

    IEnumerator DestroyInsect() {
        yield return new WaitForSeconds(deathAnimationLength);
        Destroy(gameObject);
    }
}
