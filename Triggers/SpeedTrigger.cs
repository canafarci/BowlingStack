using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedTrigger : MonoBehaviour
{
    [SerializeField] float _speedMultiplier, _lerpTime;
    float _baseSpeed;
    bool _triggered = false;

    public static event Action<float, float> OnSpeedChange;

    private void Awake()
    {
        _baseSpeed = GameManager.Instance.References.GameConfig.PlayerSpeed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!_triggered && other.CompareTag("Player"))
        {
            print(Time.time);
            _triggered = true;
            OnSpeedChange?.Invoke(_speedMultiplier * _baseSpeed, _lerpTime);
        }
    }


}
