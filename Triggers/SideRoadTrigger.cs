using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SideRoadTrigger : MonoBehaviour
{
    [SerializeField] bool _isOnLeftSide, _isEnterTrigger;
    [SerializeField] float _enterPosZ, _exitPosZ;
    [SerializeField] Transform _tube;
    Stacker _stacker;
    MoveHorizontal _followRoad;
    StackMover _stackMover;

    Vector3 scale;
    
    private void Awake()
    {
        _stacker = FindObjectOfType<Stacker>();
        _stackMover = FindObjectOfType<StackMover>();
        _followRoad = FindObjectOfType<MoveHorizontal>();
        scale = _tube.transform.localScale;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StackableBall stackableBall = other.GetComponent<StackableBall>();

            if (stackableBall != null)
                if (!stackableBall.IsInStack || stackableBall.PositionAtStack != _stacker.BallList.Count - 1) return;

            if (stackableBall == null && _stacker.BallList.Count != 0) return;
            _followRoad.RemoveControl();
            

            if (stackableBall != null)
            {
                _stackMover.AlternativeMove();
                StartCoroutine(StartSideRoad());
            }
                
            else
                SideTrack(other);

            // string cameraName = _isOnLeftSide == true ? CameraStrings.LeftSideCamera : CameraStrings.RightSideCamera;
            // GameManager.Instance.CameraController.ActivateCamera(cameraName);

        }
    }

    IEnumerator StartSideRoad()
    {
        int count = _stacker.BallList.Count;
        var list = _stacker.BallList;

        for (int i = count - 1; i >= 0; i--)
        {
            SideTrack(list[i].GetComponent<Collider>());
            yield return new WaitForSeconds(0.05f);
        }
        SideTrack(GameObject.Find("Player").transform.GetComponent<Collider>());
    }

    private void SideTrack(Collider other)
    {
        StartCoroutine(DelayedResetStatus());

        Sequence sequence = DOTween.Sequence();

        

        sequence.Append(_tube.DOScale(new Vector3(scale.x  * 1.5f, scale.y *  1.5f, scale.z *  1.5f), 0.075f));
        sequence.Append(_tube.DOScale(new Vector3(scale.x, scale.y, scale.z), 0.075f));


        ITweener tweener = other.GetComponent<ITweener>();

        if (_isEnterTrigger)
        {
            float posZ  = _isOnLeftSide == true ? _enterPosZ : -1f * _enterPosZ;
            tweener.TweenZY(posZ, -0.45f, 0.12f, 0.2f);

            

            
          
        }
        else
        {
            float posZ = _isOnLeftSide == true ? _exitPosZ : -1f * _exitPosZ;
            tweener.TweenZY(posZ, 0f, 0.12f, 0.2f);

            if (other.gameObject.name == "Player")
            {
                StartCoroutine(DelayedEnableControl(_followRoad, _stackMover));
                //GameManager.Instance.CameraController.ActivateCamera(CameraStrings.FirstCamera);
            }
        }
    }

    IEnumerator DelayedResetStatus()
    {

        yield return new WaitForSeconds(7f);
    }

    IEnumerator DelayedEnableControl(MoveHorizontal followRoad, StackMover stackMover)
    {
        yield return new WaitForSeconds(.2f);
        followRoad.EnableControl();
        stackMover.NormalizeMove();

        foreach (BallTween bt in FindObjectsOfType<BallTween>())
        {
            bt.ResetY();
        }
    }
}
