using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushTrigger : MonoBehaviour
{
    [SerializeField] GameObject _fX;
    [SerializeField] Material _brushMaterial;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !other.GetComponent<Collider>().isTrigger)
        {
            Renderer renderer = other.transform.GetComponentInChildren<Renderer>();
            renderer.material = _brushMaterial;

            if (_fX == null) { return; }

            GameObject fx = Instantiate(_fX, other.transform.position, _fX.transform.rotation);
            Destroy(fx, 2f);
        }
    }
}
