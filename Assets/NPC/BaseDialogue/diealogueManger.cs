using UnityEngine; 
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class diealogueManger : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public GameObject dialogueUI;

    private DialogueData currentDialogue;
    private int dialogueIndex = 0;

    public void StartDialogue(DialogueData data)
    {
        currentDialogue = data;
        dialogueIndex = 0;
        dialogueUI.SetActive(true);
        ShowNextLine();
    }
    public void OnNextMsg(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("OnNextMsg");
            ShowNextLine();
        }
    }
    public void ShowNextLine()
    {
        if (dialogueIndex >= currentDialogue.lines.Length)
        {
            EndDialogue();
            return;
        }

        DialogueLine line = currentDialogue.lines[dialogueIndex];
        nameText.text = line.speakerName;
        dialogueText.text = line.text;

        dialogueIndex++;
    }

    public void EndDialogue()
    {
        dialogueUI.SetActive(false);
    }
}
