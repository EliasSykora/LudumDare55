using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueController : MonoBehaviour
{
    [Serializable]
    public struct DialogueEntry
    {
        [TextArea(2, 6)]
        public string text;
        public UnityEvent onOpen;
        public UnityEvent onClose;
    }

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

    public void PlayDialogue(IEnumerable<string> items, Action onLastClosed)
    {
        Action showNextItem = null;
        var enumerator = items.GetEnumerator();
        showNextItem = () =>
        {
            if (!enumerator.MoveNext()) 
            {
                onLastClosed?.Invoke();
                return;
            }
            ShowDialogue(enumerator.Current, showNextItem);
        };
        showNextItem();
    }

    public void PlayDialogue(IEnumerable<DialogueEntry> entries, Action onLastClosed)
    {
        Action showNextItem = null;
        var enumerator = entries.GetEnumerator();
        UnityEvent onClosePrevious = null;
        showNextItem = () =>
        {
            onClosePrevious?.Invoke();
            if (!enumerator.MoveNext()) 
            {
                onLastClosed?.Invoke();
                return;
            }
            onClosePrevious = enumerator.Current.onClose;
            enumerator.Current.onOpen?.Invoke();
            ShowDialogue(enumerator.Current.text, showNextItem);
        };
        showNextItem();
    }

    void CloseDialogue()
    {
        dialoguePanel.SetActive(false);
        if (callbackOnClose != null)
        {
            var callback = callbackOnClose;
            // The callback may open a new dialogue window. Any resetting of the
            // callback must be done before actually calling it, so that we don't
            // destroy any new parameters set up by the callback.
            callbackOnClose = null;
            callback();
        }
    }

    void Update()
    {
        if (dialoguePanel.activeInHierarchy)
        {
            if (Input.anyKeyDown)
            {
                CloseDialogue();
            }
        }
    }
}
