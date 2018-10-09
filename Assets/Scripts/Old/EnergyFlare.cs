using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyFlare : MonoBehaviour {

    public float speed = 30f; // How flast the energy flare travels
    public int damage = 10; // How much damage the energy flare does

	// Use this for initialization
	void Start () {
        StartCoroutine("deathTimer");
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}

    // 3
    IEnumerator deathTimer()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
}
