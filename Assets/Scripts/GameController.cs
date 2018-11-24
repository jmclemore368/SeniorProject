using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    [SerializeField] SpawnPointEnemy[] spawnPointEnemies;

    private static GameController singleton;

    public GameUI gameUI;
    public GameObject player;
    public GameObject space;
    public GameObject gameOverPanel;

    private int enemiesLeft = 0;
    private int waveCountdown = 30;
    private bool isGameOver = false;
    private int waveNumber = 1;

    public void OnGUI() {
        if (isGameOver && Cursor.visible == false) {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void Start() {
        singleton = this;
        Time.timeScale = 1;
        StartCoroutine("updateWaveTimer");
        gameUI.SetWaveNumberText(waveNumber);
        SpawnEnemies();
    }

    private void SpawnEnemies() {
        foreach (SpawnPointEnemy spawnPointEnemy in spawnPointEnemies) {
            spawnPointEnemy.SpawnEnemy();
            enemiesLeft++;
        }
        gameUI.SetEnemyText(enemiesLeft);
    }

    private IEnumerator updateWaveTimer() {
        while (!isGameOver) {
            yield return new WaitForSeconds(1f);
            waveCountdown--;
            gameUI.SetWaveText(waveCountdown);
            if (waveCountdown == 0) {
                SpawnEnemies();
                waveCountdown = 30;
                gameUI.ShowNewWaveText();
                gameUI.SetWaveNumberText(++waveNumber);
            }
        }
    }

    public static void RemoveEnemy()
    {
        singleton.enemiesLeft--;
        singleton.gameUI.SetEnemyText(singleton.enemiesLeft);
        if (singleton.enemiesLeft == 0)
            singleton.gameUI.ShowWaveClearText();
    }

    public void RestartGame() {
        SceneManager.LoadScene(Constants.mainGameSceneName);
        gameOverPanel.SetActive(true);
    }

    public void Exit() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else 
            Application.Quit();
        #endif
    }

    public void MainMenu(){
        SceneManager.LoadScene(Constants.mainMenuSceneName);
    }

    public void GameOver() {
        isGameOver = true;
        //Time.timeScale = 0; pauses the game, but now main menu won't load anim
        gameOverPanel.SetActive(true);
        space.SetActive(true);
        disableUIComponents();
        playGameOverMusic();
    }

    private void disableUIComponents() {
        gameUI.DisableWarmupText();
        gameUI.DisableBottomLeftBar();
        gameUI.DisableTopLeftBar();
        gameUI.DisableTopRightBar();
        gameUI.DisableWaveClear();
        gameUI.DisableNewWave();
    }

    private void playGameOverMusic() {
        stopAllSound();
        space.GetComponent<AudioSource>().Play();
    }

    private void stopAllSound() {
        AudioSource[] allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioSource in allAudioSources) 
            audioSource.Stop();
    }
}
