using FluffyUnderware.Curvy.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveHorizontal : MonoBehaviour
{
    [SerializeField] float _smoothingFactor, _xBounds = 5.71f;
    InputReader _inputReader;
    Transform _childTransform;
    bool _controlRemoved = false;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _childTransform = transform.GetChild(0);
        _smoothingFactor = 6f;

    }

    private void Update()
    {
        if (_controlRemoved) return;

        Vector3 localPos = transform.localPosition;

        localPos.z -= _inputReader.XChange;

        localPos.z = Mathf.Clamp(localPos.z, -_xBounds, _xBounds);

        transform.localPosition = Vector3.Lerp(transform.localPosition, localPos, _smoothingFactor);
    }

    public void RemoveControlAndAdjustPosition(Vector3 position)
    {
        _controlRemoved = true;
        float localX = transform.InverseTransformPoint(position).x;

        _childTransform.DOLocalMoveX(localX, 0.3f);

    }

    public void RemoveControl() => _controlRemoved = true;
    public void EnableControl() => _controlRemoved = false;
    public void ChangeController(SplineController follower, Transform followTransform)
    {
        _childTransform = followTransform;
    }
}