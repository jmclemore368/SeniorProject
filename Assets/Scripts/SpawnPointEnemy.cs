using UnityEngine;

public class SpawnPointEnemy : MonoBehaviour {
    [SerializeField] GameObject[] enemies;
    private int waveNumber;
    private int healthBonus = 0;
    private int healthMultiplier = 100;

	public void SpawnEnemy() {
        waveNumber++;
        healthBonus += healthMultiplier * waveNumber;
        GameObject enemy = Instantiate(enemies[Random.Range(0, enemies.Length)]);
        enemy.transform.position = transform.position;
        Health enemyHealth = enemy.GetComponent<Health>();
        int enemyStartingHealth = (int) enemyHealth.getStartingHealth();
        enemyHealth.SetStartingHealth(enemyStartingHealth + healthBonus);
    }
}
