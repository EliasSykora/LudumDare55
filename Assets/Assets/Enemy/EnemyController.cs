using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] int Soul = 0;
    [SerializeField] string Wish = "Wish";
    [SerializeField] TextMeshProUGUI SoulField;
    [SerializeField] TextMeshProUGUI WishField;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SoulField.text = Soul.ToString();
        WishField.text = Wish;
    }
}
