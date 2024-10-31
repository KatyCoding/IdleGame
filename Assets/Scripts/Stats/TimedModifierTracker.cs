using System.Collections.Generic;
using UnityEngine;

public class TimedModifierTracker : MonoBehaviour
{
    public static TimedModifierTracker Instance;
    private List<Modifier> timedMods = new List<Modifier>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }
        DestroyImmediate(this);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Modifier mod in timedMods)
        {
            mod.timeLeft -= Time.deltaTime;
            
        }
        
    }

    public void AddModifier(Modifier mod)
    {
        timedMods.Add(mod);
    }
    
}
