using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;


public class CardController : MonoBehaviour
{
    
    [SerializeField] int CardCost = 2;
    [SerializeField] string CardName = "Card name";
    [SerializeField] TextMeshProUGUI CardNameField;
    [SerializeField] TextMeshProUGUI CardCostField;
    

    void Start()
    {
        CardNameField.text = CardName;
        CardCostField.text = CardCost.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
