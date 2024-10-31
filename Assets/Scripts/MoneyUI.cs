using System;
using TMPro;
using UnityEngine;
using System.Collections;
public class MoneyUI : MonoBehaviour
{
    public TMPro.TextMeshProUGUI text;

    private void Start()
    {
        StartCoroutine(UpdateText());
    }

    IEnumerator UpdateText()
    {
        while (true)
        {
            yield return new WaitForSeconds(.2f);
            var currentMoney = MoneyTracker.GetCurrentAmount();
            text.text = currentMoney.ToString();
        }
    }

}
