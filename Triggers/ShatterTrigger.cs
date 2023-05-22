using RayFire;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatterTrigger : Obstacle
{
    RayfireGun _gun;

    protected override void Awake()
    {
        base.Awake();
        _gun = FindObjectOfType<RayfireGun>();
    }
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (other.gameObject.CompareTag("Player"))
        {
            StackableBall ball = other.GetComponent<StackableBall>();

            if (ball != null && !ball.IsInStack) return;

            GetComponent<Collider>().enabled = false;

            OnPlayerEnterObstacle(other);

            //_gun.target = transform.GetChild(0);
            _gun.Shoot();

            StartCoroutine(DelayedDestroyAndSpawn());
        }
    }


    IEnumerator DelayedDestroyAndSpawn()
    {
        yield return new WaitForSeconds(3f);

        GetComponent<ParentSpawner>().StartSpawn();
        Destroy(transform.GetChild(0).gameObject);
        GetComponent<Collider>().enabled = true;

    }
}
