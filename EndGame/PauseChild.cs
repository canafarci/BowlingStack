using FluffyUnderware.Curvy.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseChild : MonoBehaviour
{

    SplineController _follower;
    Animator _animator;

    private void Awake()
    {
        _follower = GetComponent<SplineController>();
        _animator = GetComponentInChildren<Animator>();
    }

    public void PauseMovement()
    {
        _animator.Play("Idle");
        _follower.Speed = 0f;
    }

    public void ContinueMovement()
    {
        _animator.Play("Walk");
        _follower.Speed = GameManager.Instance.References.GameConfig.EndGameSpeed;
    }
}
