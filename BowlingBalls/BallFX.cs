using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFX : MonoBehaviour
{
    public void PlayDestructionFX(GameObject destructionFX)
    {
        GameObject fx = Instantiate(destructionFX, transform.position, destructionFX.transform.rotation);
        Destroy(fx, 2f);
    }
}
