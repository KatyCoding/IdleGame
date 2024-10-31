using UnityEngine;
using System.Collections.Generic;


public class TestCurrencyMath : MonoBehaviour
{
   
   private void Awake()
   {
      List<Currency> tests = new List<Currency>();
      for (int i = 0; i < 10; i++)
      {
            tests.Add(new Currency(Random.Range(0, 100), Random.Range(0, 10)));
         
      }
      foreach (Currency test in tests)
      {
          foreach (var c in tests )
          {
              
              var result = test + c;
              Debug.Log(test.baseVal + "," +test.exponent + " plus " + c.baseVal + "," + c.exponent + " RESULT: " + result.baseVal + "," + result.exponent);
          }
      }
      
         Debug.Break();
         
   }
   
}
