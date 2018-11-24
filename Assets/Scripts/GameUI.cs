﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

    [SerializeField]
    private Text reserveText;
    [SerializeField]
    private Text ammoText;
    [SerializeField]
    private Text healthText;
    [SerializeField]
    private Text armorText;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text pickupText;
    [SerializeField]
    private Text waveText;
    [SerializeField]
    private Text enemyText;
    [SerializeField]
    private Text waveClearText;
    [SerializeField]
    private Text newWaveText;
    [SerializeField]
    private Text warmupText;
    [SerializeField]
    private GameObject bottomLeftBar;
    [SerializeField]
    private GameObject topRightBar;
    [SerializeField]
    private GameObject topLeftBar;


    [SerializeField]
    Player player;



	// Use this for initialization
	void Start () {
        SetArmorText((int) player.health.getArmor());
        SetHealthText((int) player.health.startingHealth);
	}
	
    public void SetArmorText(int armor)
    {
        armorText.text = "Armor: " + armor;
    }
    public void SetHealthText(int health)
    {
        healthText.text = "Health: " + health;
    }
    public void SetAmmoText(int ammo)
    {
        ammoText.text = "Ammo: " + ammo;
    }
    public void SetAmmoText(string ammo)
    {
        ammoText.text = ammo;
    }
    public void SetReserveText(string reserve)
    {
        reserveText.text = reserve;
    }
    public void SetScoreText(int score)
    {
        scoreText.text = "" + score;
    }
    public void SetWaveText(int time)
    {
        waveText.text = "Next Wave: " + time;
    }
    public void SetEnemyText(int enemies)
    {
        enemyText.text = "Enemies: " + enemies;
    }

    public void ShowWaveClearBonus()
    {
        waveClearText.GetComponent<Text>().enabled = true;
        StartCoroutine("hideWaveClearBonus");
    }
    IEnumerator hideWaveClearBonus()
    {
        yield return new WaitForSeconds(4);
        waveClearText.GetComponent<Text>().enabled = false;
    }

    public void EnableWarmupText() {
        warmupText.GetComponent<Text>().enabled = true;
    }

    public void DisableWarmupText() {
        warmupText.GetComponent<Text>().enabled = false;
    }

    public void DisableBottomLeftBar() {
        bottomLeftBar.GetComponent<Image>().enabled = false;
        healthText.GetComponent<Text>().enabled = false;
        armorText.GetComponent<Text>().enabled = false;
        reserveText.GetComponent<Text>().enabled = false;
        ammoText.GetComponent<Text>().enabled = false;
    }

    public void DisableTopRightBar() {
        topRightBar.GetComponent<Image>().enabled = false;
        enemyText.GetComponent<Text>().enabled = false;
    }

    public void DisableTopLeftBar() {
        topLeftBar.GetComponent<Image>().enabled = false;
        waveText.GetComponent<Text>().enabled = false;
    }

    public void DisableWaveClear() {
        // Need to disable whole game object as may be in co-routine
        waveClearText.enabled = false;
    }

    public void DisableNewWave()
    {
        // Need to disable whole game object as may be in co-routine
        newWaveText.enabled = false;
    }



    public void SetWarmupText(int percentage) {
        warmupText.text = percentage + "%";
    }

    public void SetPickUpText(string text)
    {
        pickupText.GetComponent<Text>().enabled = true;
        Debug.Log("setting" + text);
        pickupText.text = text;
        // Restart the Coroutine so it doesn’t end early
        StopCoroutine("hidePickupText");
        StartCoroutine("hidePickupText");
    }


    IEnumerator hidePickupText()
    {
        yield return new WaitForSeconds(4);
        pickupText.GetComponent<Text>().enabled = false;
    }
    public void ShowNewWaveText()
    {
        StartCoroutine("hideNewWaveText");
        newWaveText.GetComponent<Text>().enabled = true;
    }
    IEnumerator hideNewWaveText()
    {
        yield return new WaitForSeconds(4);
        newWaveText.GetComponent<Text>().enabled = false;
    }
}
