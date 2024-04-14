using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : ScriptableObject
{
    public string stateName;

    public string wishText;

    public WeightedText[] thoughtTexts;

    public WordsResponse[] responses;
}
