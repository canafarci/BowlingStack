using AmazingAssets.CurvedWorld.Example;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMovingItemSpeed : MonoBehaviour
{
    private void OnEnable() => GameStart.OnGameStart += OnGameStart;
    private void OnDisable() => GameStart.OnGameStart -= OnGameStart;

    private void OnGameStart()
    {
        GetComponent<CarSpawner>().enabled = true;
    }
}
