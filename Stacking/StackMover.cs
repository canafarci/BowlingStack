using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackMover : MonoBehaviour
{
    List<StackableBall> _ballList;
    [SerializeField] float _smoothingFactor, _stackForwardSpacing;
    Transform _mainBallTransform;
    Stacker _stacker;
    bool _paused, _sideTracked = false;

    private void Awake()
    {
        _mainBallTransform  = transform;
        _ballList = new List<StackableBall>();
        _stacker =  GetComponent<Stacker>();
    }

    private void OnEnable() => _stacker.OnBallListChanged += OnBallListChanged;
    private void OnDisable() => _stacker.OnBallListChanged -= OnBallListChanged;

    private void Update()
    {
        if (_paused) return;
        if (_ballList.Count <= 0) return;

        if (_sideTracked)
        {
            SideStackMove();
        }
        else
        {
            StackMove();
        }

    }

    private void StackMove()
    {
        for (int i = 0; i < _ballList.Count; i++)
        {
            if (i == 0)
            {
                _ballList[i].transform.localPosition = Vector3.Lerp(_ballList[i].transform.localPosition,
                new Vector3(_mainBallTransform.localPosition.x + _stackForwardSpacing, _mainBallTransform.localPosition.y, _mainBallTransform.localPosition.z),
                _smoothingFactor * Time.smoothDeltaTime);
            }
            else
            {
                _ballList[i].transform.localPosition = Vector3.Lerp(_ballList[i].transform.localPosition,
                new Vector3(_mainBallTransform.localPosition.x + ((_ballList[i].PositionAtStack + 1) * _stackForwardSpacing), _mainBallTransform.localPosition.y, _ballList[i - 1].transform.localPosition.z),
                _smoothingFactor * Time.smoothDeltaTime);
            }
        }
    }

    private void SideStackMove()
    {
        for (int i = 0; i < _ballList.Count; i++)
        {
            _ballList[i].transform.localPosition = Vector3.Lerp(_ballList[i].transform.localPosition,
                new Vector3(_mainBallTransform.localPosition.x + ((i + 1) * _stackForwardSpacing), _ballList[i].transform.localPosition.y, _ballList[i].transform.localPosition.z),
                _smoothingFactor * Time.smoothDeltaTime);
        }
    }

    private void OnBallListChanged(List<StackableBall> list, bool addedToList) => _ballList = list;
    public void EmptyStack() => _ballList.Clear();
    public void PauseStacker() => _paused = true;
    public void ResumeNormalMovement() => _paused = false;
    public void AlternativeMove() => _sideTracked = true;
    public void NormalizeMove() => _sideTracked = false;
}

