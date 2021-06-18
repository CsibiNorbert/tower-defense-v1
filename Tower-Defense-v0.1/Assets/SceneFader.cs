using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneFader : MonoBehaviour
{
    public Image imageFade;
    public AnimationCurve fadeCurve;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeIn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeTo(string sceneName)
    {
        StartCoroutine(FadeOut(sceneName));
    }

    private IEnumerator FadeIn()
    {
        // Animate img from alpha 1 to slowly 0
        float alpha = 1f;
        while (alpha > 0f)
        {
            // we multply by speed if we want. * 1f
            alpha -= Time.deltaTime;

            float a = fadeCurve.Evaluate(alpha);
            // we just change the alpha
            imageFade.color = new Color(0f, 0f, 0f, a);
            // it means skip to the next frame...wait one frame and continue
            yield return 0;
        }

        // Load a scene if you want after x amount of seconds
    }

    private IEnumerator FadeOut(string sceneName)
    {
        float alpha = 0f;
        while (alpha < 1f)
        {
            alpha += Time.deltaTime;

            float a = fadeCurve.Evaluate(alpha);
            // we just change the alpha
            imageFade.color = new Color(0f, 0f, 0f, a);
            // it means skip to the next frame...wait one frame and continue
            yield return 0;
        }

        // Load scene
        SceneManager.LoadScene(sceneName);
    }
}
