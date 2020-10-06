using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int totalScore;
    public Text scoreText;
    public static GameController instance;
    void Start()
    {
        instance = this;
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene("Game");
        }
    }

    public void UpdateScore()
    {
        scoreText.text = totalScore.ToString();
    }
}
