using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wish", fileName = "New Wish")]

public class Wishes : ScriptableObject
{
    [TextArea(2, 6)]
    [SerializeField] private string wish = "Enter enemy wish";
    [SerializeField] public string[] powerWords;

    public string GetWish()
    {
        return wish;
    }
    public string GetPowerWords(int index)
    {
        return powerWords[index];
    }
}

