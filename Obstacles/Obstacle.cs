using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public ParticleSystem FX;
    protected Stacker _stacker;
    public static event Action<int> OnEggHitObstacle;

    protected virtual void Awake() => _stacker = FindObjectOfType<Stacker>();
    protected virtual  void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StackableBall ball = other.transform.GetComponent<StackableBall>();
            if (ball != null && !ball.IsInStack) return;
            else if (ball == null && other.gameObject.name != "Player") return;

            OnPlayerEnterObstacle(other);
        }
    }

    protected virtual void OnPlayerEnterObstacle(Collider other)
    {
        StackableBall stackableBall = other.transform.GetComponent<StackableBall>();
        if (stackableBall == null)
        {
            PlayFX();
            return;
        }


        _stacker.RemoveEggFromStack(stackableBall);
        OnEggHitObstacle?.Invoke(stackableBall.PositionAtStack);
        PlayFX();
        //GetComponent<Collider>().enabled = false;
    }

    void PlayFX()
    {
        if (FX != null && FX.gameObject.activeSelf == false)
            FX.gameObject.SetActive(true);
        else
            FX.Play();
    }
}