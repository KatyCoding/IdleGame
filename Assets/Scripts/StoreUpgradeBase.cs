using UnityEngine;

public abstract class StoreUpgradeBase : ScriptableObject
{
    public string Name;
    public string Description;
}

public class StoreUpgradeSpecificProducer : StoreUpgradeBase
{
    public MoneyProducer ProducerReference;
}
[CreateAssetMenu(fileName = "StoreUpgradeMoneyMultiplier",menuName = "Store Upgrades/Store Upgrade Money Multiplier")]
public class StoreUpgradeMoneyMultiplier : StoreUpgradeSpecificProducer
{
    public int Multiplier;
}
[CreateAssetMenu(fileName = "StoreUpgradeMoneyMultiplier",menuName = "Store Upgrades/Store Upgrade Time Reducer")]
public class StoreUpgradeTimeReducer : StoreUpgradeSpecificProducer
{
    public float Reduction;
}