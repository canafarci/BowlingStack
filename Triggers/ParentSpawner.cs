using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentSpawner : MonoBehaviour
{
    public void StartSpawn() => StartCoroutine(Spawn());
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(3f);

        GameObject prefab = Instantiate(Resources.Load<GameObject>("Shatterable Wall"), transform);

        GetComponent<Obstacle>().FX = prefab.transform.GetComponentInChildren<ParticleSystem>(true);
    }
}
