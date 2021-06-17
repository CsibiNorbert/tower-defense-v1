using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isGameEnded;
    public GameObject gameOverUi;

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
}
