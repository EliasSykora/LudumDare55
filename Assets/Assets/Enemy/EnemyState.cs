using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy State", fileName = "New State")]

public class EnemyState : ScriptableObject
{
    public string stateName;

    public string wishText;

    public WeightedText[] thoughtTexts;

    public WordsResponse[] responses;
}
