using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyObstacleEnterArea : MonoBehaviour
{
    [SerializeField] Animator _animator;
    bool _enabled = false;
    private void OnTriggerEnter(Collider other)
    {
        if (!_enabled && other.CompareTag("Player"))
        {
            _enabled = true;
            _animator.enabled = true;
        }
    }
}
