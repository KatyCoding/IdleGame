using UnityEngine;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour
{
    private Button UIButton;

    [SerializeField] private MoneyProducer producerReference;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (UIButton == null)
        {
            UIButton = GetComponent<Button>();
        }
        
    }
    
    private void Clicked()
    {
        producerReference.AttemptBuy(1);
    }

}
