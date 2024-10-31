using UnityEngine;
using System.Collections.Generic;
[System.Serializable]
public class TrackedStat
{
    
    public int baseValue;
    public int currentValue
    {
        get { return CurrentValue(); }
    }
    public List<Modifier> modifiers = new List<Modifier>();

    public void AddModifier(Modifier mod)
    {
        modifiers.Add(mod);
    }

    private int CurrentValue()
    {
        int val = baseValue;
        foreach (var mod in modifiers)
        {
            val += mod.modValue;
        }

        return val;
    }
}

