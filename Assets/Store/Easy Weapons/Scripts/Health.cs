/// <summary>
/// Health.cs
/// Author: MutantGopher
/// This is a sample health script.  If you use a different script for health,
/// make sure that it is called "Health".  If it is not, you may need to edit code
/// referencing the Health component from other scripts
/// </summary>

using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
	public bool canDie = true;					// Whether or not this health can die
	
	public float startingHealth = 100.0f;		// The amount of health to start with
	public float maxHealth = 100.0f;			// The maximum amount of health
	private float currentHealth;				// The current ammount of health

	public bool replaceWhenDead = false;		// Whether or not a dead replacement should be instantiated.  (Useful for breaking/shattering/exploding effects)
	public GameObject deadReplacement;			// The prefab to instantiate when this GameObject dies
	public bool makeExplosion = false;			// Whether or not an explosion prefab should be instantiated
	public GameObject explosion;				// The explosion prefab to be instantiated

	public bool isPlayer = false;				// Whether or not this health is the player
	public GameObject deathCam;					// The camera to activate when the player dies

	private bool dead = false;					// Used to make sure the Die() function isn't called twice

    private float armor = 100.0f;
    private float maxArmor = 500.0f;
    public bool PickupArmor()
    {
        if (armor >= maxArmor) {
            return false;
        }
        armor = maxArmor;
        return true;
    }


	private void OnGUI()
	{
        if (isPlayer) {
            GUI.Label(new Rect(10, Screen.height - 80, 100, 20), "Health: " + (int) currentHealth);
            GUI.Label(new Rect(10, Screen.height - 60, 100, 20), "Armor: " + (int) armor);
        }
	}

	// Use this for initialization
	void Start()
	{
		currentHealth = startingHealth;
	}


    public void ChangeHealth(int bonus) {
        currentHealth += bonus;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void ChangeHealth(DamageInfo damageInfo)
	{
        Debug.Log(transform.root + " hit by " + damageInfo.from + " for " + damageInfo.amount);

        // Change the health by the amount specified in the amount variable
        if (armor > 0)
        {
            float diff = armor + damageInfo.amount;
            armor -= Mathf.Min(armor, -damageInfo.amount);
            if (diff < 0)
            {
                currentHealth += diff;
            }
        } else {
            currentHealth += damageInfo.amount;
        }

		// If the health runs out, then Die.
		if (currentHealth <= 0 && !dead && canDie) 
            Die(damageInfo.from);
		// Make sure that the health never exceeds the maximum health
        else if (currentHealth > maxHealth) {
            currentHealth = maxHealth;
        }

        // Play hit animation
        if (currentHealth > 0 && !dead) {
            SendMessageUpwards("getHit", SendMessageOptions.DontRequireReceiver);
        }
	}

    public void Die(GameObject from = null)
	{
        Debug.Log(gameObject + " has died!");

		// This GameObject is officially dead.  This is used to make sure the Die() function isn't called again
		dead = true;

		if (replaceWhenDead)
			Instantiate(deadReplacement, transform.position, transform.rotation);
		if (makeExplosion)
			Instantiate(explosion, transform.position, transform.rotation);


        // Set death cam to the killer
        /* ======
        // Edge case - Kill each other then there is no camera
        // Also pose not always working
        ======= */
        if (from != null && from != GameObject.FindWithTag("Player"))
        {
            deathCam = from.GetComponentInChildren<Camera>().gameObject;
            gameObject.GetComponentInChildren<Weapon>().showCrosshair = false;
        }

		if (isPlayer && deathCam != null)
			deathCam.SetActive(true);

		// Remove this GameObject from the scene
		Destroy(gameObject);
	}
}
