using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StackFX : MonoBehaviour
{
    [SerializeField] float _scaleTweenDuration = 0.075f;
    Stacker _stacker;

    Coroutine _fxCoroutine = null;
    private void Awake() => _stacker = GetComponent<Stacker>();
    private void OnEnable() => _stacker.OnBallListChanged += OnEggListChanged;
    private void OnDisable() => _stacker.OnBallListChanged -= OnEggListChanged;


    private void OnEggListChanged(List<StackableBall> list, bool addedToList)
    {
        if (!addedToList && _fxCoroutine != null)
        {
            StopCoroutine(_fxCoroutine);
        }
        else
        {
            _fxCoroutine = StartCoroutine(StackRoutine(list));
        }
    }

    IEnumerator StackRoutine(List<StackableBall> list)
    {
        

        for (int i = list.Count - 1; i >= 0; i--)
        {
            if (list.Count == 0) { yield break; }
            if (list[i] == null) {  break; }
            Sequence sequence = DOTween.Sequence();
            sequence.Append(list[i].transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), _scaleTweenDuration));
            sequence.Append(list[i].transform.DOScale(new Vector3(1f, 1f, 1f), _scaleTweenDuration));

            yield return new WaitForSeconds(_scaleTweenDuration * 2f / 3f);
        }
        
        Sequence sequence1 = DOTween.Sequence();
        sequence1.Append(transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), _scaleTweenDuration));
        sequence1.Append(transform.DOScale(new Vector3(1f, 1f, 1f), _scaleTweenDuration));
    }
}
