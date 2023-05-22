using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using FluffyUnderware.Curvy.Controllers;
using System;
using Random = UnityEngine.Random;
using AmazingAssets.CurvedWorld.Example;

public class StackableBall : MonoBehaviour
{
    public int PositionAtStack;

    Collider _collider;
    Stacker _stacker;
    public bool IsInStack = false;

    private void Awake()
    {
        _stacker = FindObjectOfType<Stacker>();
        _collider = GetComponent<Collider>();
    }

    private void OnEnable()
    {
        Obstacle.OnEggHitObstacle += OnEggHitObstacle;
        FindObjectOfType<StartEndGame>().OnEndGameStart += OnEndGameStart;
    }



    private void OnDisable()
    {
        Obstacle.OnEggHitObstacle -= OnEggHitObstacle;
        StartEndGame seg = FindObjectOfType<StartEndGame>();
        if (seg != null)
            seg.OnEndGameStart -= OnEndGameStart;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!IsInStack && other.gameObject.CompareTag("Player") && !other.GetComponent<Collider>().isTrigger)
        {
            AddToStack();
        }
    }

    public void AddToStack()
    {
        IsInStack = true;
        _collider.isTrigger = false;

        PositionAtStack = _stacker.AddEggToStack(this);
        GetComponentInChildren<Animator>().enabled = true;

        PositionBall();
    }

    void PositionBall()
    {
        GetComponent<RunnerCar>().moveDirection = Vector3.zero;
    }


    private void OnEggHitObstacle(int hitIndex)
    {
        if (PositionAtStack > hitIndex)
        {           
            StartCoroutine(OnHitObstacle());
        }
    }

    private void OnEndGameStart()
    {
        if (!IsInStack)
            Destroy(gameObject);
    }

    IEnumerator OnHitObstacle()
    {
        yield return null;
        //Destroy(gameObject);

        GetComponent<RunnerCar>().moveDirection = new Vector3(-1, 0, 0);

        transform.DOLocalMoveZ(Random.Range(-5f, 5f), .5f);
        transform.DOLocalMoveX(Random.Range(4f, 15f), .5f);

        Sequence sequence = DOTween.Sequence();

        sequence.Append(transform.DOLocalMoveY(Random.Range(2f, 4f), .25f));
        sequence.Append(transform.DOLocalMoveY(0.6f, .25f));
        yield return new WaitForSeconds(.5f);

        _collider.isTrigger = true;
        IsInStack = false;


    }
}
