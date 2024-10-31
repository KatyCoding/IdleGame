using System;
using UnityEngine;

[System.Serializable]
public class Modifier
{
    public Modifier(int value, TimeSpan totalTime)
    {
        if (totalTime.TotalMilliseconds == 0)
            timeLeft = float.MinValue;
        else
        {
            TimedModifierTracker.Instance.AddModifier(this);
        }

    }
    public int modValue;
    public float timeLeft = -1;//in seconds
    private TimeSpan modifierTimer; // if 0  is perma mod.
       
}
