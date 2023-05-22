using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFXPlayer : MonoBehaviour
{
    [SerializeField] GameObject[] _fxs;

    private void OnEnable()
    {
        PinTrigger.OnPinHit += PlayRandomFX;
    }

    private void OnDisable()
    {
        PinTrigger.OnPinHit -= PlayRandomFX;
    }

    public void PlayRandomFX()
    {
        int randInt = Random.Range(0, _fxs.Length);

        GameObject fx = Instantiate(_fxs[randInt], transform);
        fx.SetActive(true);

    }
}
