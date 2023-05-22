using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PinText : MonoBehaviour
{
    public int PinCount { get { return _score; } }
    TextMeshProUGUI _text;
    int _score = 0;

    private void Awake() => _text = GetComponent<TextMeshProUGUI>();
    private void OnEnable() => PinTrigger.OnPinHit += OnPinHit;
    private void OnDisable() => PinTrigger.OnPinHit -= OnPinHit;

    private void OnPinHit()
    {
        _score++;
        _text.text = _score.ToString();
    }
}
