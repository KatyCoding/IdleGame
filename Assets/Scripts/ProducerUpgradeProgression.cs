using UnityEngine;
using System.Collections.Generic;
[CreateAssetMenu(fileName = "ProducerUpgradeProgression", menuName = "Scriptable Objects/ProducerUpgradeProgression")]
public class ProducerUpgradeProgression : ScriptableObject
{
    [SerializeField]
    private List<SerializedUpgrade> upgrades = new List<SerializedUpgrade>();

    public List<SerializedUpgrade> GetAllUpgrades()
    {
        return new List<SerializedUpgrade>(upgrades);
    }
    
}
[System.Serializable]
public class SerializedUpgrade
{
    public int AmountNeeded;
    public float MultiplierToAdd;
    public float CooldownMultiplier; 
}