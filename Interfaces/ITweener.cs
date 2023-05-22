using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITweener
{
    void TweenY(float value, float duration);
    void TweenZY(float valueZ, float valueY, float durationZ, float durationY);
    void ResetY();

}
