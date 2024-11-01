using System;
using UnityEngine;

public class MoneyTracker : MonoBehaviour
{
    
    private static MoneyTracker instance;
    private static Currency money;
    
    
    
    public static void AddMoney(Currency toAdd)
    {
        money += toAdd;

    }

    public static void SubtractMoney(Currency toSubtract)
    {
        money -= toSubtract;
    }

    public static Currency GetCurrentAmount()
    {
        return new Currency(money);
    }
    private void Awake()
    {
        if (instance == null)
        {
            money = new Currency(1, 0);
            instance = this;
            return;
        }
        DestroyImmediate(this);

    }

    private void Update()
    {
        //Debug.Log(money.baseVal.ToString());
    }
}
