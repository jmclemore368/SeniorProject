﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEquipper : MonoBehaviour {

    public static string activeWeaponType;
    public GameObject pistol;
    public GameObject assaultRifle;
    public GameObject shotgun;
    GameObject activeGun;

	// Use this for initialization
	void Start () {
        activeWeaponType = Constants.Pistol;
        activeGun = pistol;
	}

    private void loadWeapon(GameObject weapon)
    {
        pistol.SetActive(false);
        assaultRifle.SetActive(false);
        shotgun.SetActive(false);
        weapon.SetActive(true);
        activeGun = weapon;
    }

    // Update is called once per frame
    void Update()
    {
        // If not currently firing
        if (!activeGun.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Fire"))
        {
            if (Input.GetKeyDown("1"))
            {
                loadWeapon(pistol);
                activeWeaponType = Constants.Pistol;
            }
            else if (Input.GetKeyDown("2"))
            {
                loadWeapon(assaultRifle);
                activeWeaponType = Constants.AssaultRifle;
            }
            else if (Input.GetKeyDown("3"))
            {
                loadWeapon(shotgun);
                activeWeaponType = Constants.Shotgun;
            }
        }
    }

    public GameObject GetActiveWeapon()
    {
        return activeGun;
    }
}
