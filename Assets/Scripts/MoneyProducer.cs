using System;
using System.Collections;
using UnityEngine;

public class MoneyProducer : MonoBehaviour
{
    
    [SerializeField]
    private Currency baseProductionAmount;
    private Currency currentProductionAmount;
    public TrackedStat Cooldown;
    private int numberOwned = 0;
    public bool autoRun = false;
    //Modify each one so that the starting cost isn't 0 and the curves are all different. Maybe leave the end cost the same though.
    [SerializeField] private AnimationCurve BuyingCost;
    
    //need to figure out the best way to use Animation Curve for Currency or do it another way 
    private float timer = 0;
    
    public void Start()
    {
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
    private void Buy(int amount, Currency price)
    {
        MoneyTracker.SubtractMoney(price);
        numberOwned += amount;
        
    }
    [ContextMenu("Buy 1")]
    public void TEMPBuy()
    {
        AttemptBuy();
    }
    
    public void AddUpgrade(Currency upgrade)
    {
        
    }
    private void StartProduction()
    {
        
        StartCoroutine(RunToProduce());
    }

    private IEnumerator RunToProduce()
    {
        timer = Cooldown.currentValue;
        while (timer > 0)
        {
            timer -= Time.deltaTime;
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

    private Currency GetCost(int amountToBuy)
    {
        //TEMP
        //return new Currency( 750,0);
        float val = BuyingCost.Evaluate(numberOwned + amountToBuy);
        int exponent = (int)val;
        val -= (int)val;
        val *= 1000;
        return new Currency(val,exponent) + new Currency(200,0);
    }
}
  