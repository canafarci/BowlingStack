using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTrigger : MonoBehaviour
{
    [SerializeField] bool _isRemoveControlTrigger;
    bool _triggered = false;
    private void OnTriggerEnter(Collider other)
    {
        if (!_triggered && other.CompareTag("Player") && _isRemoveControlTrigger)
        {
            _triggered = true;
            MoveHorizontal follower = FindObjectOfType<MoveHorizontal>();
            follower.RemoveControlAndAdjustPosition(transform.position);
        }

        else if (!_triggered && other.CompareTag("Player") && other.transform.parent.parent.parent.name == "Player Parent")
        {
            MoveHorizontal follower = FindObjectOfType<MoveHorizontal>();
            follower.EnableControl();
        }
               
    }
}
