using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ProducerUI : MonoBehaviour
{
    public MoneyProducer producerRef;
    public TMPro.TextMeshProUGUI NumberOwnedText;
    public TMPro.TextMeshProUGUI ProductionAmountText;
    public Slider ProductionProgress;
    public TMPro.TextMeshProUGUI BuyCostText;
    public void UpdateUI()
    {
        NumberOwnedText.text = producerRef.numberOwned.ToString();
        ProductionAmountText.text = producerRef.GetCurrentProductionAmount().ToString();
        ProductionProgress.value = producerRef.GetProductionProgress();
        Debug.Log(ProductionProgress.value);
        BuyCostText.text = producerRef.GetCost(1).ToString();
    }

    private void Update()
    {
        //temp
        UpdateUI();
    }

    private void Start()
    {
        //StartCoroutine(UIUpdate());
    }

    private IEnumerator UIUpdate()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            UpdateUI();
        }
        
    }
}
