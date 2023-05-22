using DG.Tweening;
using FluffyUnderware.Curvy.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyObstacle : Obstacle
{
    protected override void OnPlayerEnterObstacle(Collider other)
    {
        base.OnPlayerEnterObstacle(other);

        Stacker stacker = FindObjectOfType<Stacker>();
        List<StackableBall> eggList = stacker.BallList;

        for (int i = 0; i < eggList.Count; i++)
        {
            SplineController follower = eggList[i].transform.GetComponentInParent<SplineController>();
            StartCoroutine(SpeedChangeRoutine(follower));

        }

        SplineController baseFollower = stacker.transform.GetComponent<SplineController>();
        StartCoroutine(SpeedChangeRoutine(baseFollower));
    }

    IEnumerator SpeedChangeRoutine(SplineController follower)
    {
        float defaultSpeed = GameManager.Instance.References.GameConfig.PlayerSpeed;

        Tween tween1 = DOTween.To(() => follower.Speed, x => follower.Speed = x, (0f), 0.1f);
        yield return tween1.WaitForCompletion();

        follower.MovementDirection = MovementDirection.Backward;
        Tween tween2 = DOTween.To(() => follower.Speed, x => follower.Speed = x, (-4f * defaultSpeed), 0.15f);
        yield return tween2.WaitForCompletion();

        Tween tween3 = DOTween.To(() => follower.Speed, x => follower.Speed = x, (0f), 0.25f);
        yield return tween3.WaitForCompletion();

        follower.MovementDirection = MovementDirection.Forward;
        Tween tween4 = DOTween.To(() => follower.Speed, x => follower.Speed = x, (defaultSpeed), 1f);
    }
}