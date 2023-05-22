using AmazingAssets.CurvedWorld.Example;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGameTrigger : MonoBehaviour
{
    GameObject _fx;

    private void Start()
    {
        _fx = FindObjectOfType<FXReference>(true).gameObject;
    }
    [SerializeField] bool _isSecondEnding;
    private void OnTriggerEnter(Collider other)
    {
        if (_isSecondEnding)
        {
            if (other.gameObject.CompareTag("Player") && other.gameObject.name == "Player")
            {
                SecondEnding();
            }
        }
        else
        {
            if (other.gameObject.CompareTag("Player"))
            {
                FirstEnding(other);
            }
        }


    }

    public void FirstEnding(Collider other)
    {
        other.gameObject.SetActive(false);

        //OTHER LOGIC
        _fx.SetActive(true);
        StartCoroutine(DelayedLoadScene(1));
        
    }

    public void SecondEnding()
    {
        FindObjectOfType<ChunkSpawner>().movingSpeed = 0;

        _fx.SetActive(true);
        RunnerCar runner = _fx.transform.parent.GetComponent<RunnerCar>();
        if (runner != null)
            runner.moveDirection = Vector3.zero;
        MoveHorizontal mover = FindObjectOfType<MoveHorizontal>();
        mover.RemoveControl();
        mover.transform.GetComponentInChildren<Animator>().enabled = false;
        StartCoroutine(DelayedLoadScene(0));
    }

    IEnumerator DelayedLoadScene(int index)
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(index);
    }
}
