using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLoop : MonoBehaviour
{
    public static bool paused = false;
    public GameTime timeElapsed;
    public GameScore score;
    public WeaponSpawner[] ws;
    public BackgroundSpawner[] bs;
    public GameObject pauseMenu;
    public Text pauseScore, pausePoints, pauseTime, pauseHeader;
    public Button resume, upgrades;
    private bool start;
    private int weaponSpawnInterval;
    private int cloudSpawnTime, obstacleSpawnTime, specialSpawnTime;
    private float nextCloudSpawn, nextObstacleSpawn, nextSpecialSpawn;
    private int lastTime;
    private int lastAddTime;
    private int ballCount = 1;
    void Start()
    {
        start = true;
        Time.timeScale = 1;
        lastTime = 0;
        lastAddTime = 0;
        paused = false;
        weaponSpawnInterval = GameManager.manager.weaponSpawnInterval;
        cloudSpawnTime = 10;
        obstacleSpawnTime = 5;
        specialSpawnTime = 3;
        nextCloudSpawn = Time.time + cloudSpawnTime;
        nextObstacleSpawn = Time.time + obstacleSpawnTime;
        nextSpecialSpawn = Time.time + specialSpawnTime;
    }

    void Update()
    {
        int currentTime = (int)Time.timeSinceLevelLoad;
        if (lastTime < currentTime){
            timeElapsed.updateTime(currentTime - lastTime);
            lastTime = currentTime;
        }

        if (currentTime % weaponSpawnInterval == 0 && lastAddTime != currentTime && ballCount < GameManager.manager.maxBallAmount) {
            ballCount++;
            lastAddTime = currentTime;
            ws[0].SpawnWeapon();
        } else if (start){
            ws[0].SpawnWeapon();
            start = false;
        }

        if (Time.time > nextCloudSpawn){
            nextCloudSpawn += Random.Range(1, cloudSpawnTime);
            bs[0].SpawnBackgroundObject();
        }

        if (Time.time > nextObstacleSpawn){
            nextObstacleSpawn +=Random.Range(1, obstacleSpawnTime);
            bs[1].SpawnBackgroundObject();
        }

        if (Time.time > nextSpecialSpawn){
            nextSpecialSpawn += specialSpawnTime;
            if (Random.Range(0, 100) < 10) ws[1].SpawnSpecial();
        }
    }

    public void Pause(){
        Time.timeScale = 0;
        paused = true;
        pauseScore.text = "Points: " + score.score;
        pausePoints.text = "Total Points: " + GameManager.manager.points;
        pauseMenu.SetActive(true);
    }

    public void EndGame(){
        Time.timeScale = 0;
        paused = true;
        resume.gameObject.SetActive(false);
        upgrades.gameObject.SetActive(true);
        GameManager.manager.points += score.score;
        pauseScore.text = "Points: " + score.score;
        pausePoints.text = "Total Points: " + GameManager.manager.points;
        pauseHeader.text = "GAME OVER";
        pauseMenu.transform.GetChild(pauseMenu.transform.childCount-1).gameObject.SetActive(false);
        pauseMenu.SetActive(true);
        GameManager.manager.Save();
    }

    public void Menu(){
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void Upgrades(){
        SceneManager.LoadScene("Upgrades", LoadSceneMode.Single);
    }

    public void PlayAgain(){
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void Unpause(){
        Time.timeScale = 1;
        paused = false;
        pauseMenu.SetActive(false);
    }
}
