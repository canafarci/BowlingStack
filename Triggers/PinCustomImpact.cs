using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinCustomImpact : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Vector3 impactVector = new Vector3(Random.Range(-50f, 50f), Random.Range(50f, 200.5f), Random.Range(-50f, 50f));
            GetComponent<Rigidbody>().AddForce(impactVector, ForceMode.Impulse);
        }
    }
}
