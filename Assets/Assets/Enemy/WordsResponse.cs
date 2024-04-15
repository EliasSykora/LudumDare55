using UnityEngine;

[CreateAssetMenu(menuName = "PowerWords", fileName = "New PowerWord")]

public class WordsResponse : ScriptableObject
{
    public string[] words;

    public WeightedText[] stateChange;

    public float reputationChange;

    [TextArea(2, 6)]
    public string[] dialogue;
}