using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PinTrigger : MonoBehaviour
{
    [SerializeField] GameObject _fx;
    StartEndGame _endGameStarter;
    PinDamage _damager;

    public static event Action OnPinHit;

    private void Awake()
    {
        _endGameStarter = FindObjectOfType<StartEndGame>();
    }

    private void OnEnable()
    {
        _endGameStarter.OnEndGameStart += OnEndGameStart;
        _endGameStarter.OnEndGamePinReferences += OnEndReference;
    }

    private void OnEndReference(PinDamage damager)
    {
        _damager = damager;
    }

    private void OnDisable()
    {
        if (_endGameStarter != null)
        {
            _endGameStarter.OnEndGameStart -= OnEndGameStart;
            _endGameStarter.OnEndGamePinReferences -= OnEndReference;
        }

    }

    private void OnEndGameStart()
    {
        if (gameObject.layer != LayerMask.NameToLayer("ENDGAME PINS"))
            Destroy(gameObject);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !collision.transform.GetComponent<Collider>().isTrigger)
        {
            GetComponent<Collider>().enabled = false;
            GameObject fx = Instantiate(_fx, transform.position, _fx.transform.rotation);
            OnPinHit?.Invoke();

            Destroy(fx, 1f);
            Destroy(gameObject, 1.2f);


            if (_damager != null)
            {
                _damager.OnHit();
            }
        }
    }
}
