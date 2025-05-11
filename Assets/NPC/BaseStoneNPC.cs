using UnityEngine;

public class BaseStoneNPC : MonoBehaviour
{
    public bool isStone;
    public DialogueData dialogueToPlay;
    private diealogueManger dialogueManager;

    private bool hasPlayed = false;
    void Start()
    {
        dialogueManager = FindFirstObjectByType<diealogueManger>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("lightProJ"))
            isStone = false;
        if (other.CompareTag("Player") && !hasPlayed)
        {
            dialogueManager.StartDialogue(dialogueToPlay);
            hasPlayed = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogueManager.EndDialogue();
            hasPlayed = false;
        }
    }
}
