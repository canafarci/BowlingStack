using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    [SerializeField] RectTransform _fadeRect;
    public Coroutine FadeRoutine;

    private void OnEnable() => SceneManager.sceneLoaded += OnSceneLoad;
    private void OnDisable() => SceneManager.sceneLoaded -= OnSceneLoad;
    private void OnSceneLoad(Scene arg0, LoadSceneMode arg1)
    {
        if (_fadeRect == null) return;

        if (FadeRoutine != null)
            StopCoroutine(FadeRoutine);

        FadeRoutine = StartCoroutine(FadeIn());
    }

    public IEnumerator FadeOut()
    {
        while (_fadeRect.offsetMin.y > 0 )
        {
            yield return new WaitForSeconds(0.01f);
            float bottom = _fadeRect.offsetMin.y;
            float top = _fadeRect.offsetMax.y;

            bottom -= 15f;
            top -= 15f;

            _fadeRect.offsetMin = new Vector2(0f, bottom);
            _fadeRect.offsetMax = new Vector2(0f, top);

        }
    }

    public IEnumerator FadeIn()
    {
        while (_fadeRect.offsetMin.y < 1920)
        {
            yield return new WaitForSeconds(0.01f);
            float bottom = _fadeRect.offsetMin.y;
            float top = _fadeRect.offsetMax.y;

            bottom += 15f;
            top += 15f;

            _fadeRect.offsetMin = new Vector2(0f, bottom);
            _fadeRect.offsetMax = new Vector2(0f, top);

        }
    }
}
