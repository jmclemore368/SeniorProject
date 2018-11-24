using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject space;
    public GameObject gameOverPanel;

    private static GameController singleton;
    [SerializeField]
    AlienSpawnPoint[] alienSpawnPoints;
    public int enemiesLeft;

    public GameUI gameUI;
    public GameObject player;
    public int score;
    public int waveCountdown;
    public bool isGameOver;


    public void OnGUI()
    {
        if (isGameOver && Cursor.visible == false)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    public void GameOver()
    {
        isGameOver = true;
        //Time.timeScale = 0; - pauses the game, but now main menu won't load anim
        gameOverPanel.SetActive(true);
        space.SetActive(true);

        // Disable text 
        gameUI.DisableWarmupText();
        gameUI.DisableBottomLeftBar();
        gameUI.DisableTopLeftBar();
        gameUI.DisableTopRightBar();
        gameUI.DisableWaveClear();
        gameUI.DisableNewWave();

        // Stop all sound and play game over music
        stopAllSound();
        space.GetComponent<AudioSource>().Play();
    }

    private void stopAllSound() {
        AudioSource[] allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.Stop();
        }

    }

    public void RestartGame()
    {
        SceneManager.LoadScene("NewMain");
        gameOverPanel.SetActive(true);
    }
    public void Exit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("NewMainMenu");
    }

    void Start()
    {
        Debug.Log("STARTING");
        singleton = this;
        StartCoroutine("increaseScoreEachSecond");
        isGameOver = false;
        Time.timeScale = 1;
        waveCountdown = 30;
        enemiesLeft = 0;
        StartCoroutine("updateWaveTimer");
        SpawnAliens();

    }

    private void SpawnAliens()
    {
        foreach (AlienSpawnPoint alienSpawnPoint in alienSpawnPoints)
        {
            alienSpawnPoint.SpawnAlien();
            enemiesLeft++;
        }
        gameUI.SetEnemyText(enemiesLeft);
    }

    private IEnumerator updateWaveTimer()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(1f);
            waveCountdown--;
            gameUI.SetWaveText(waveCountdown);
            // Spawn next wave and restart count down
            if (waveCountdown == 0)
            {
                SpawnAliens();
                waveCountdown = 30;
                gameUI.ShowNewWaveText();
            }
        }
    }

    public static void RemoveEnemy()
    {
        singleton.enemiesLeft--;
        singleton.gameUI.SetEnemyText(singleton.enemiesLeft);
        // Give player bonus for clearing the wave before timer is done
        if (singleton.enemiesLeft == 0)
        {
            singleton.score += 50;
            singleton.gameUI.ShowWaveClearBonus();
        }
    }

    public void AddAlienKillToScore()
    {
        score += 10;
        gameUI.SetScoreText(score);
    }

    IEnumerator increaseScoreEachSecond()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(1);
            score += 1;
            gameUI.SetScoreText(score);
        }
    }
}
