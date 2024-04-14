using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    [SerializeField]
    GameObject dialoguePanel;
    [SerializeField]
    TMPro.TMP_Text dialogueText;

    Action callbackOnClose = null;

    public static DialogueController instance
    {
        get
        {
            var gameObject = GameObject.FindWithTag(Tags.DialogueController);
            var dialogueController = gameObject?.GetComponent<DialogueController>();
            Debug.Assert(dialogueController != null, "Dialogue controller was not found in the scene");
            return dialogueController;
        }
    }

    public void ShowDialogue(string text, Action onClose)
    {
        dialogueText.text = text;
        dialoguePanel.SetActive(true);
        callbackOnClose = onClose;
    }

    void CloseDialogue()
    {
        dialoguePanel.SetActive(false);
        if (callbackOnClose != null)
        {
            callbackOnClose();
            callbackOnClose = null;
        }
    }

    void Update()
    {
        if (dialoguePanel.activeInHierarchy)
        {
            if (Input.anyKey)
            {
                CloseDialogue();
            }
        }
    }
}
