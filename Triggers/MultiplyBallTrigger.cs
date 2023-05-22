using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplyBallTrigger : MonoBehaviour
{
    bool _addedBalls = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!_addedBalls)

            {
                _addedBalls = true;

                for (int i = 0; i < 3; i++)
                {
                    GameObject ball = Instantiate(GameManager.Instance.References.GameConfig.Ball, transform.position, Quaternion.identity);
                    ball.GetComponent<StackableBall>().AddToStack();
                }
            }
        }
    }

}
