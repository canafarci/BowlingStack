using AmazingAssets.CurvedWorld.Example;
using FluffyUnderware.Curvy.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartMoveBall : MonoBehaviour
{
    ChunkSpawner _chunkSpawner;
    private void Awake() => _chunkSpawner = GetComponent<ChunkSpawner>();
    private void OnEnable() => GameStart.OnGameStart += OnGameStart;
    private void OnDisable() => GameStart.OnGameStart -= OnGameStart;

    private void OnGameStart()
    {
        _chunkSpawner.movingSpeed = GameManager.Instance.References.GameConfig.PlayerSpeed;

        foreach (CarSpawner cs in FindObjectsOfType<CarSpawner>(true))
        {
            cs.enabled = true;
        }
    }
}
