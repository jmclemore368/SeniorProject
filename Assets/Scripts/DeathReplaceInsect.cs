using System.Collections;
using UnityEngine;

public class DeathReplaceInsect : MonoBehaviour
{
    public Animator enemyAnimator;

    // Use this for initialization
    void Start()
    {
        enemyAnimator.Play("Dead");
        GameController.RemoveEnemy();
        StartCoroutine("DestroyInsect");

    }

    IEnumerator DestroyInsect()
    {
        yield return new WaitForSeconds(2.5f);
        Destroy(gameObject);
    }
}
