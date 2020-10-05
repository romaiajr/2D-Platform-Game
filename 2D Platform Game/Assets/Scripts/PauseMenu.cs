using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    public void LoadGame(){
        SceneManager.LoadScene("Game");
    }

    public void LoadAbout(){
        SceneManager.LoadScene("About Us");
    }

    public void QuitGame(){
        Application.Quit();
    }
}
