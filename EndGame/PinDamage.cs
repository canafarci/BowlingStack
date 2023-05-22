using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PinDamage : MonoBehaviour
{
    public bool IsSecondEnding;

    BallTween _ballTween;
    FinishGameTrigger _finishGameTrigger;
    Stacker _stacker;
    int _hitCount = 0;


    private void Awake()
    {
        _ballTween = GetComponent<BallTween>();
        _finishGameTrigger = FindObjectOfType<FinishGameTrigger>();
        _stacker = GetComponent<Stacker>();
    }

    public void OnHit()
    {
        if (IsSecondEnding)
        {
            _hitCount++;
            if (_hitCount >= 6 && _stacker.BallList.Count > 0)
            {
               _stacker.RemoveEggFromStack(_stacker.BallList.OrderBy(x => x.PositionAtStack).Last());
                _hitCount = 0;
            }
            else if (_hitCount >= 6 && _stacker.BallList.Count <= 0)
            {
                _finishGameTrigger.SecondEnding();
            }
        }
        else
        {
            FirstEnding();
        }
    }

    private void FirstEnding()
    {
        if (transform.localScale.x > 1f)
        {
            _ballTween.DownScale();
        }
        else
        {
            _finishGameTrigger.FirstEnding(GetComponent<Collider>());
        }
    }
}
