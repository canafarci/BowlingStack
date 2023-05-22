using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCounter
{
    DateTime _startTime;
    public TimeCounter()
    {
        StartCounting();
    }

    public void StartCounting()
    {
        _startTime = DateTime.Now;
    }

    public float EndCounting()
    {
        DateTime endTime = DateTime.Now;
        float playDuration = (float)((endTime - _startTime).TotalSeconds);


        return playDuration;
    }
}
