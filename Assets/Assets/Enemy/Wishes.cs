using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wish", fileName = "New Wish")]

public class Wishes : ScriptableObject
{
    [TextArea(2, 6)]
    [SerializeField] private string wish = "Enter enemy wish";
    [SerializeField] public string[] powerWords;

    [TextArea(2, 6)]
    [SerializeField] private string successResponse = "Enter enemy success response";

    [TextArea(2, 6)]
    [SerializeField] private string failResponse = "Enter enemy wish";

    public string GetWish()
    {
        return wish;
    }
    public string GetPowerWords(int index)
    {
        return powerWords[index];
    }
   public string GetFailResponse()
    {
        return failResponse;
    }

     public string GetSuccessResponse()
    {
        return successResponse;
    }
}

