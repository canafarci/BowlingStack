using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameMover : MonoBehaviour
{
    [SerializeField] float _speed = 25f;
    bool _enabled = true;

    private void Update()
    {
        if (!_enabled) { return; }
        Vector3 pos = transform.position;
        pos.x += _speed * Time.deltaTime;
        transform.position = pos;
    }

    public void EnableMover() => _enabled = true;
    public void DisableMover() => _enabled = false;
}
