using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    Coroutine _fadeLoadRoutine;

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void FadedLoadScene(int index, float delay = 0f)
    {
        if (_fadeLoadRoutine != null)
            StopCoroutine(_fadeLoadRoutine);

        _fadeLoadRoutine = StartCoroutine(FadeLoadSceneRoutine(index, delay));
    }

    IEnumerator FadeLoadSceneRoutine(int index, float delay = 0f)
    {
        yield return new WaitForSeconds(delay);

        Fader fader = GameManager.Instance.Fader;  

        if (fader.FadeRoutine != null)
            StopCoroutine(fader.FadeRoutine);

        Coroutine fadeRoutine = StartCoroutine(fader.FadeOut());
        fader.FadeRoutine = fadeRoutine;
        yield return fadeRoutine;
        LoadScene(index);
    }
    
}
