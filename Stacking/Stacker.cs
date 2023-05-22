using FluffyUnderware.Curvy.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;

public class Stacker : MonoBehaviour
{
    public List<StackableBall> BallList { get { return _ballList;}}

    List<StackableBall> _ballList = new List<StackableBall>();
    public event Action<List<StackableBall>, bool> OnBallListChanged;

    private void OnEnable() => SpeedTrigger.OnSpeedChange += OnSpeedChange;
    private void OnDisable() => SpeedTrigger.OnSpeedChange -= OnSpeedChange;
    public int AddEggToStack(StackableBall ball)
    {
        _ballList.Add(ball);

        OnBallListChanged.Invoke(_ballList, true);
        _ballList = _ballList.Distinct().ToList();
        return _ballList.IndexOf(ball);
    }

    public void RemoveEggFromStack(StackableBall ball)
    {
        int hitIndex = ball.PositionAtStack;

        for (int i = _ballList.Count - 1; i >= 0; i--)
        {
            if (hitIndex <= i)
            {
                _ballList.RemoveAt(i);
                //Destroy(ball2.gameObject);
            }
        }

        //egg.GetComponent<BallFX>().PlayDestructionFX(fx);
        Destroy(ball.transform.gameObject);
        OnBallListChanged.Invoke(_ballList, false);
    }

    private void OnSpeedChange(float speed, float time)
    {
        for (int i = 0; i < _ballList.Count; i++)
        {
            SplineController follower = _ballList[i].transform.GetComponentInParent<SplineController>();
            DOTween.To(() => follower.Speed, x => follower.Speed = x, speed, time);
        }

        SplineController thisFollower = transform.GetComponent<SplineController>();
        DOTween.To(() => thisFollower.Speed, x => thisFollower.Speed = x, speed, time);
    }

    
}
