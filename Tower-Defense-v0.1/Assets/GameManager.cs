using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool isGameEnded;
    public GameObject gameOverUi;
    public string nextLevel = "Level02";
    public int nextLeveToUnloc = 2;

    public SceneFader sceneFader;

    // Start is called before the first frame update
    void Start()
    {
        // at the beggining of each scene, the game is not over
        isGameEnded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameEnded)
        {
            return;
        }

        if (PlayerStats.playerLives <= 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        isGameEnded = true;
        // shows the game over ui
        gameOverUi.SetActive(true);
    }

    public void LevelWin()
    {
        // End level.. Transition to new level, or show score scene.
        Debug.Log("Level 1 completed");

        PlayerPrefs.SetInt("levelReached", nextLeveToUnloc);

        sceneFader.FadeTo(nextLevel);
    }
}
