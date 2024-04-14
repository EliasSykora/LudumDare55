using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy State", fileName = "New State")]

public class EnemyState : ScriptableObject
{
    public string stateName;
    [TextArea(2, 6)]
    public string wishText;

    [SerializeField] Sprite EnemySprite;

    public WeightedText[] thoughtTexts;

    public WordsResponse[] responses;
}
