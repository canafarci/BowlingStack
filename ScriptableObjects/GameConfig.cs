using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Config/New Game Config", order = 0)]
public class GameConfig : ScriptableObject
{
    public float PlayerSpeed, EndGameSpeed;
    public int StartMoney;
    public Material BaseMaterial;
    public GameObject Ball;

    [Header("AUDIO")]

    public AudioConfig DragStartConfig;
}

[System.Serializable]
public class AudioConfig
{
    public AudioClip Audio;
    public float Volume;
}
