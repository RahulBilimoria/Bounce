using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void PlayGame(){
        GameManager.manager.PlayMusic();
        GameManager.manager.GetUpgradeValues();
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void OpenSkills(){
        SceneManager.LoadScene("Upgrades", LoadSceneMode.Single);
    }

    public void OpenSettings(){
        SceneManager.LoadScene("Settings", LoadSceneMode.Single);
    }

    public void OpenCredits(){
        SceneManager.LoadScene("Credits", LoadSceneMode.Single);
    }

    public void Exit(){
        Application.Quit();
    }
}
