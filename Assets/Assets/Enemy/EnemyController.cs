using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] int Soul = 0;
    // [SerializeField] string Wish = "Wish";
    [SerializeField] TextMeshProUGUI SoulField;
    [SerializeField] TextMeshProUGUI WishField;
    [SerializeField] Wishes wish;

    [SerializeField] EnemyState[] states;
    int maxWishes;
    int currentWish = 0;

    void Start()
    {
        WishField.text = wish.GetWish();
        maxWishes = wish.powerWords.Length;
    }

    // Update is called once per frame
    void Update()
    {
        SoulField.text = Soul.ToString();

    }

    public void WordCheck(string CardName)
    {
       
       if (wish.GetPowerWords(currentWish).Contains(CardName))
        {
            Debug.Log("Ano");
            Soul += 5;
        } else
        {
            Debug.Log("Ne");
            Soul -= 5;
        }
        currentWish++;

        if (currentWish >= maxWishes)
        {
            gameObject.SetActive(false);
        }
    }
}
