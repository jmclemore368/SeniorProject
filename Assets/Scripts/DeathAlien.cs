using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAlien : MonoBehaviour {

    public Animator alien; // For playing animations

	// Use this for initialization
	void Start () {
        alien.Play("dead");
        GameController.RemoveEnemy();
        StartCoroutine("DestroyAlien");

	}
	
    IEnumerator DestroyAlien()
    {
        yield return new WaitForSeconds(3.85f);
        Destroy(gameObject);
    }
}
