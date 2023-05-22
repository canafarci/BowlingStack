using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class EndGameCamera : MonoBehaviour
{
    CinemachineVirtualCamera _cam;
    CinemachineFramingTransposer _transposer;

    private void Awake()
    {
        _cam = GetComponent<CinemachineVirtualCamera>();
        _transposer = _cam.GetCinemachineComponent<CinemachineFramingTransposer>();
    }
    public void ScaleCamera()
    {
        float distance = _transposer.m_CameraDistance;
        distance *= 1.15f;
        _transposer.m_CameraDistance = distance;
    }
}
