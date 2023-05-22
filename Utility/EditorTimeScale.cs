using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorTimeScale : MonoBehaviour
{
    [Range(1f, 20f)]
    public float timeScale;

    private void Update()
    {
        Time.timeScale = timeScale;
    }
}
