using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUi : MonoBehaviour
{
    public Text roundsText;
    public SceneFader sceneFader;
    public string menuSceneName = "MainMenu";

    private void OnEnable()
    {
        roundsText.text = PlayerStats.roundsSurvived.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Retry()
    {
        // It will restart the current loaded scene
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
        Debug.Log("Go to Menu");
    }
}
