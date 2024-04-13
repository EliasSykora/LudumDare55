using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
using Unity.VisualScripting;


public class CardController : MonoBehaviour, IEndDragHandler
{
    
    [SerializeField] int CardCost = 2;
    [SerializeField] string CardName = "Card name";
    [SerializeField] TextMeshProUGUI CardNameField;
    [SerializeField] TextMeshProUGUI CardCostField;
    Collider2D myCollider;
    GameObject enemyTarget;
    string PowerWord; 

    void Start()
    {
        CardNameField.text = CardName;
        CardCostField.text = CardCost.ToString();
        myCollider = GetComponent<Collider2D>();
        PowerWord = CardName;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        // Debug.Log("Dropped");
        if (enemyTarget != null) enemyTarget.GetComponent<EnemyController>().WordCheck(CardName);
       // enemyTarget.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("Triggered");
        if (other.tag == "Enemy") enemyTarget = other.gameObject;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Enemy") enemyTarget = null; 
    }

    public string GetPowerWord(int index)
    {
        return PowerWord;
    }
}
