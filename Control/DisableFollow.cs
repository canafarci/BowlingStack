using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using AmazingAssets.CurvedWorld.Example;

public class DisableFollow : MonoBehaviour
{
    [SerializeField] bool _isSecondEnding;
    private void OnTriggerEnter(Collider other)
    {
        if (_isSecondEnding)
        {
            if (other.gameObject.CompareTag("Player") && other.gameObject.name == "Player")
            {
                CinemachineVirtualCamera cam = GameManager.Instance.CameraController.ActivateCamera(CameraStrings.FirstCamera).GetComponent<CinemachineVirtualCamera>();
                cam.m_Follow = null;
                cam.m_LookAt = null;
                Rigidbody rb = cam.gameObject.AddComponent<Rigidbody>();
                rb.isKinematic = true;
                RunnerCar camRunner = cam.gameObject.AddComponent<RunnerCar>();
                camRunner.movingSpeed = 30f;
                camRunner.moveDirection = new Vector3(-1, 0, 0);

            }
        }
        else
        {
            if (other.gameObject.CompareTag("Player"))
            {
                CinemachineVirtualCamera cam = GameManager.Instance.CameraController.ActivateCamera(CameraStrings.FirstCamera).GetComponent<CinemachineVirtualCamera>();
                cam.m_Follow = null;
                cam.m_LookAt = null;

            }
        }
        
    }
}
