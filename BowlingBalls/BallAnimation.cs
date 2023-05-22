using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAnimation : MonoBehaviour
{
    Animator _animator;
    private void Awake() => _animator = GetComponent<Animator>();

    public void ChangeAnimation(bool addedToStack)
    {
        if (addedToStack)
            _animator.Play("DefaultMoving");
        else
            _animator.Play("Static");
    }
}
