using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    [SerializeField]
    DialogueController.DialogueEntry[] tutorialDialogue;

    GameObject hand;
    GameObject soulCounter;
    GameObject cardHolder;
  

    public void RunTutorialSequence()
    {
        // DialogueController.instance.PlayDialogue(TutorialSequence(), null);
        DialogueController.instance.PlayDialogue(tutorialDialogue, null);
    }

    public void ShowHand()
    {
        hand.SetActive(true);
    }

    public void ShowSoulCounter()
    {
        soulCounter.SetActive(true);
    }

    public void ShowCardHolder()
    {
        cardHolder.SetActive(true);
    }

    void Awake()
    {
        hand = GameController.instance.hand;
        Debug.Assert(hand != null, "The hand was not found in the scene");

        soulCounter = GameController.instance.soulCounter;
        Debug.Assert(soulCounter != null, "The soul counter was not found in the scene");

        cardHolder = GameController.instance.cardHolder;
        Debug.Assert(cardHolder != null, "The card holder was not found in the scene");
    }

    void Start()
    {
        cardHolder.SetActive(false);
        hand.SetActive(false);
        soulCounter.SetActive(false);
    }
}
