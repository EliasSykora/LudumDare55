using UnityEngine;
using UnityEngine.Events;

public class SummoningController : MonoBehaviour
{
    [SerializeField]
    private DialogueController.DialogueEntry[] introTexts;

    [SerializeField]
    private UnityEvent introCompleted;

    public void PlayIntroTexts()
    {
        DialogueController.instance.PlayDialogue(introTexts, () =>
        {
            introCompleted?.Invoke();
        });
    }

    void Start()
    {
        PlayIntroTexts();
    }
}
