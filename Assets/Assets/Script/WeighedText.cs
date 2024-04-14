using System.Collections.Generic;
using UnityEngine;

public class WeightedText : ScriptableObject
{
    [TextArea(2, 6)]
    public string text;
    public float weight;

    public static string GetRandomText(IList<WeightedText> texts)
    {
        float sumWeights = 0.0f;
        foreach (var text in texts)
        {
            sumWeights += text.weight;
        }
        float choice = Random.Range(0, sumWeights);
        float cumulativeWeights = 0.0f;
        foreach (var text in texts)
        {
            cumulativeWeights += text.weight;
            if (choice <= cumulativeWeights)
            {
                return text.text;
            }
        }
        throw new System.InvalidOperationException("Whoa, this should never happen");
    }
}