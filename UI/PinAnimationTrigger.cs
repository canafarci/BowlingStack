using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PinAnimationTrigger : MonoBehaviour
{
    public void __DotweenIcon()
    {
        GameObject icon = GameObject.Find("CurrencyIcon");

        icon.transform.DOScale(2f, 0.2f);
        icon.transform.DOScale(1f, 0.2f);

        Destroy(gameObject, .1f);

    }
}
