using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public GameObject pauseUi;
    public SceneFader sceneFader;
    public string menuSceneName = "MainMenu";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    public void TogglePauseMenu()
    {
        // We invert the state, true false etc by getting the current state of the paused ui
        pauseUi.SetActive(!pauseUi.activeSelf);

        // Freeze time
        if (pauseUi.activeSelf)
        {
            // Timescale is the speed at which the game is running.
            Time.timeScale = 0f;
        } else
        {
            Time.timeScale = 1f;
        }
    }

    public void Retry()
    {
        TogglePauseMenu();
        // Return active scene.
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        TogglePauseMenu();
        sceneFader.FadeTo(menuSceneName);
    }


}
