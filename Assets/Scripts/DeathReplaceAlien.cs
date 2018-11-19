using System.Collections;
using UnityEngine;

public class DeathReplaceAlien : MonoBehaviour 
{
    public Animator enemyAnimator;

	// Use this for initialization
	void Start () 
    {
        enemyAnimator.Play("dead");
        GameController.RemoveEnemy();
        StartCoroutine("DestroyAlien");

	}
	
    IEnumerator DestroyAlien()
    {
        yield return new WaitForSeconds(3.85f);
        Destroy(gameObject);
    }
}
