using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAnimator : MonoBehaviour
{
    private void OnEnable() => GameStart.OnGameStart += OnGameStart;
    private void OnDisable() => GameStart.OnGameStart -= OnGameStart;

    private void OnGameStart()
    {
        GetComponent<Animator>().enabled = true;
    }
}
