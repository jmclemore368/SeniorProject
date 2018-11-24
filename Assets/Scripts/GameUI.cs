using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

    [SerializeField] private Text reserveText;
    [SerializeField] private Text ammoText;
    [SerializeField] private Text healthText;
    [SerializeField] private Text armorText;
    [SerializeField] private Text waveNumberText;
    [SerializeField] private Text pickupText;
    [SerializeField] private Text waveText;
    [SerializeField] private Text enemyText;
    [SerializeField] private Text waveClearText;
    [SerializeField] private Text newWaveText;
    [SerializeField] private Text warmupText;
    [SerializeField] private GameObject bottomLeftBar;
    [SerializeField] private GameObject topRightBar;
    [SerializeField] private GameObject topLeftBar;
    [SerializeField] Player player;
    private int messageTimeLength = 3; 

	void Start() {
        int playerArmor = (int) player.health.getArmor();
        int playerHealth = (int) player.health.getStartingHealth();
        SetArmorText(playerArmor);
        SetHealthText(playerHealth);
	}
	
    public void SetArmorText(int armor) {
        armorText.text = "Armor: " + armor;
    }

    public void SetHealthText(int health) {
        healthText.text = "Health: " + health;
    }

    public void SetAmmoText(int ammo) {
        ammoText.text = "Ammo: " + ammo;
    }

    public void SetAmmoText(string ammo) {
        ammoText.text = ammo;
    }

    public void SetReserveText(string reserve) {
        reserveText.text = reserve;
    }

    public void SetWaveNumberText(int waveNumber) {
        waveNumberText.text = "" + waveNumber;
    }

    public void SetWaveText(int time) {
        waveText.text = "Next Wave: " + time;
    }

    public void SetEnemyText(int enemies) {
        enemyText.text = "Enemies: " + enemies;
    }
    public void ShowWaveClearText() {
        waveClearText.GetComponent<Text>().enabled = true;
        StartCoroutine("hideWaveClearText");
    }
    IEnumerator hideWaveClearText() {
        yield return new WaitForSeconds(messageTimeLength);
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
        waveClearText.enabled = false;
    }

    public void DisableNewWave() {
        newWaveText.enabled = false;
    }

    public void SetWarmupText(int percentage) {
        warmupText.text = percentage + "%";
    }

    public void SetPickUpText(string text) {
        pickupText.GetComponent<Text>().enabled = true;
        pickupText.text = text;
        StopCoroutine("hidePickupText");
        StartCoroutine("hidePickupText");
    }

    IEnumerator hidePickupText() {
        yield return new WaitForSeconds(messageTimeLength);
        pickupText.GetComponent<Text>().enabled = false;
    }

    public void ShowNewWaveText() {
        StartCoroutine("hideNewWaveText");
        newWaveText.GetComponent<Text>().enabled = true;
    }

    IEnumerator hideNewWaveText() {
        yield return new WaitForSeconds(messageTimeLength);
        newWaveText.GetComponent<Text>().enabled = false;
    }
}
