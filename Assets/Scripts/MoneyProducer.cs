using System;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
public class MoneyProducer : MonoBehaviour
{
    [SerializeField]
    private Currency baseProductionAmount;
    private Currency currentProductionAmount;
    public TrackedStat Cooldown;
    [HideInInspector] public int numberOwned = 0;
    public bool autoRun = false;
    [SerializeField] private ProducerUpgradeProgression upgradeProgression;
    //Modify each one so that the starting cost isn't 0 and the curves are all different. Maybe leave the end cost the same though.
    [SerializeField] private AnimationCurve BuyingCost;
    private List<SerializedUpgrade> upgradesList;
    private float timer = 0;
    
    public void Start()
    {
        //change to reset instead of starting the game
        upgradesList = upgradeProgression.GetAllUpgrades();
        currentProductionAmount= new Currency(baseProductionAmount);
        if(autoRun)
            StartProduction();
    }

    public void AttemptBuy(int amount = 1)
    {
        var price = GetCost(amount);
        if (MoneyTracker.GetCurrentAmount() > price)
        {
            Buy(amount, price);
        }
    }

    public Currency GetCurrentProductionAmount()
    {
        return new Currency(currentProductionAmount * numberOwned);
    }

    public float GetProductionProgress()
    {
        return timer / Cooldown.currentValue;
    }
    public Currency GetCost(int amountToBuy)
    {
        float val = BuyingCost.Evaluate(numberOwned + amountToBuy);
        int exponent = (int)val;
        val -= (int)val;
        val *= 1000;
        return new Currency(val,exponent) + new Currency(.5f,0);
    }
    
    private void Buy(int amount, Currency price)
    {
        MoneyTracker.SubtractMoney(price);
        numberOwned += amount;
        CheckAndApplyUpgrades();
    }
    [ContextMenu("Buy 1")]
    public void TEMPBuy()
    {
        AttemptBuy();
    }

    
    private void StartProduction()
    {
        StartCoroutine(RunToProduce());
    }

    private void CheckAndApplyUpgrades()
    {
        var nextUpgrade = upgradesList[0];
        while (numberOwned >= nextUpgrade.AmountNeeded)
        {
            if(nextUpgrade.MultiplierToAdd>1)
                currentProductionAmount *= nextUpgrade.MultiplierToAdd;
            if(nextUpgrade.CooldownMultiplier>0)
                Cooldown.AddModifier(new Modifier(nextUpgrade.CooldownMultiplier));
            upgradesList.RemoveAt(0);
            nextUpgrade = upgradesList[0];
        }
    }
    private IEnumerator RunToProduce()
    {
        timer = 0;
        while (timer < Cooldown.currentValue)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        
        Produce();
        yield return null;
        if (autoRun)
            StartProduction();
    }
[ContextMenu("Produce")]
    private void Produce()
    {
        MoneyTracker.AddMoney(currentProductionAmount * numberOwned);
    }

    
}
  