using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string LevelToLoad = "MainLevel";
    public SceneFader sceneFader;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        //SceneManager.LoadScene(LevelToLoad);

        sceneFader.FadeTo(LevelToLoad);     
    }

    public void Quit()
    {
        Application.Quit();
    }
}
