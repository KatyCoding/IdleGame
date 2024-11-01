using UnityEngine;
using System.Collections.Generic;
[System.Serializable]
public class TrackedStat
{
    
    public float baseValue;
    public float currentValue
    {
        get { return CurrentValue(); }
    }
    public List<Modifier> modifiers = new List<Modifier>();

    public void AddModifier(Modifier mod)
    {
        modifiers.Add(mod);
    }

    private float CurrentValue()
    {
        float val = baseValue;
        foreach (var mod in modifiers)
        {
            val *= mod.modValue;
        }
        return val;
    }
}

