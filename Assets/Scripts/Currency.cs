using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public class Currency
{
    public Currency(float baseValue, int power)
    {
        while (baseValue >= 1000)
        {
            power++;
            baseValue*=.001f;
        }
        baseVal = baseValue;
        exponent = power;
        
    }

    public Currency(Currency currency)
    {
        var tempHidden = currency.baseVal;
        var tempExponent = currency.exponent;
        while (tempHidden >= 1000)
        {
            tempHidden *= .001f;
            tempExponent++;
        }

        baseVal = tempHidden;
        exponent = tempExponent;
    }
    //[HideInInspector]
    //public int baseVal = 1;
    public int exponent = 1;
    [FormerlySerializedAs("hiddenBaseVal")] [SerializeField]
    public float baseVal = 1;


    public float GetHiddenValue()
    {
        return baseVal;
    }
    
    public static Currency operator +(Currency a, Currency b)
    {
        if(a.exponent == b.exponent)
            return new Currency(a.baseVal + b.baseVal, a.exponent);
        else
        {
            var larger = (a.exponent>b.exponent) ? a : b;
            var smaller = (larger == a) ? b : a;
            var dif = larger.exponent - smaller.exponent;
            var adjustedVal = smaller.baseVal * (1f / (100f * dif));
            larger.baseVal+=adjustedVal;
            
            if (larger.baseVal >= 1000)
            {
                larger.baseVal -=1000f;
                
                larger.exponent++;
            }

            return larger;
        }
    }
    public static Currency operator -(Currency a, Currency b)
    {
        Debug.Log(a.ToString() + " - " + b.ToString());
        if (a.exponent == b.exponent)
        {
            var val = a.baseVal - b.baseVal;
            if (val >=1)
            {
                return new Currency(val, a.exponent);
            }

            val *= 1000;
            return new Currency(val,a.exponent-1);
        }
        else
        {
            if (b.exponent > a.exponent)
                return new Currency(0, 0);
            var dif = a.exponent - b.exponent;
            if (dif > 4)
                return a;
            var adjustedVal = b.baseVal * (1f / (Mathf.Pow(1000,dif)));
            var newVal  = a.baseVal -adjustedVal;
            var newExp = a.exponent;
            if (newVal < 1)
            {
                newVal *= 1000;
                newExp--;
            }
            return new Currency(newVal,newExp);
        }
    }
    public static Currency operator *(Currency a, float b)
    {
        var c = new Currency(0, 0);
        c.baseVal = a.baseVal * b;
        c.exponent = a.exponent;
        while (c.baseVal >= 1000)
        {
            c.baseVal *= .001f;
            c.exponent++;
        }
        
        return c;
    }
    public static Currency operator *(Currency a, int b)
    {
        return a * (float)b;
    }
    public static bool operator ==(Currency a, Currency b)
    {
        if (a.exponent != b.exponent)
            return false;
        if (a.baseVal != b.baseVal)
            return false;
        if (a.baseVal != b.baseVal)
            return false;
        return true;
    }
    public static bool operator !=(Currency a, Currency b)
    {
        if (a == b)
            return false;
        return true;
    }
    public static bool operator >(Currency a, Currency b)
    {
        if (a.exponent > b.exponent)
            return true;
        if (a.exponent < b.exponent)
            return false;
        if (a.baseVal > b.baseVal)
            return true;
        return false;
    }
    public static bool operator < (Currency a, Currency b)
    {
        return b > a;
    }

    private string ExponentString()
    {
        if (exponent == 0)
            return "";
        var first = (exponent / 27)+65;
        string exp =""+ (char)first;
        exp += (char)((exponent % 27) + 64);
        return exp;
        //exp += 
    }
    public override string ToString()
    {
        string rep = ((int)baseVal).ToString();
        rep += "." + ((int)((baseVal - (int)baseVal) * 100)).ToString();
        rep += " " + ExponentString();
        return rep;
    }
    /*
    public static Currency operator >(Currency a, Currency b)
    {
        
    }
    public static Currency operator <(Currency a, Currency b)
    {
        
    }
    private void []
    */
    
}
