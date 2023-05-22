using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;
using System;

public class CameraController : MonoBehaviour
{
    public List<GameObject> Cameras = new List<GameObject>();

    private void OnEnable() => SceneManager.activeSceneChanged += OnSceneChange;
    private void OnDisable() => SceneManager.activeSceneChanged -= OnSceneChange;

    private void OnSceneChange(Scene arg0, Scene arg1)
    {
        AddCamerasToList();
    }

    private void AddCamerasToList()
    {
        Cameras = new List<GameObject>();

        foreach (CinemachineVirtualCamera cam in FindObjectsOfType<CinemachineVirtualCamera>(true))
        {
            Cameras.Add(cam.gameObject);
        }
    }

    public GameObject ActivateCamera(string objectName)
    {
        GameObject returnObject = null;
        for (int i = 0; i < Cameras.Count; i++)
        {
            if (Cameras[i].name == objectName)
            {
                Cameras[i].SetActive(true);
                returnObject =  Cameras[i];
            }
                
            else
                Cameras[i].SetActive(false);
        }
        return returnObject;
    }
}