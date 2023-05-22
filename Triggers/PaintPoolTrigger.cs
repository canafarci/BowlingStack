using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PaintPoolTrigger : MonoBehaviour
{
    [SerializeField] float _duration, _maxDepth;
    [SerializeField] Color _color;
    [SerializeField] GameObject _fx;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !other.GetComponent<Collider>().isTrigger)
        {
            other.GetComponent<ITweener>().TweenY(_maxDepth, _duration);

            Renderer renderer = other.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Renderer>();

            Material[] mats = renderer.materials;
            Material mat = mats[0];
            mat.DOColor(_color, 0.2f);

            renderer.materials = mats;

            GameObject fx = Instantiate(_fx, other.transform.position, _fx.transform.rotation);
            Destroy(fx, 2f);
        }
    }
}
