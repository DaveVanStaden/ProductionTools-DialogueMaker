using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddSentenceToManager : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_Text TextFieldSentence;
    public DialogueManager dialogueManager;
    private string previousSentence;
    private string newSentence;

    private void Start()
    {
        TextFieldSentence.overflowMode = TextOverflowModes.Overflow; 
        TextFieldSentence.enableWordWrapping = true; 
        inputField.onEndEdit.AddListener(OnEndEdit);
        dialogueManager = GetComponentInParent<DialogueManager>();
        
        inputField.onSelect.AddListener(dialogueManager.OnInputFieldClicked);
        inputField.onEndEdit.AddListener(dialogueManager.OnInputFieldEndEdit);
    }

    private void OnEndEdit(string text)
    {
        //dialogueManager.AddSentence(inputField.text);
        newSentence = inputField.text;
        dialogueManager.ModifySentenceByText(previousSentence,newSentence);
        previousSentence = inputField.text;
    }
}
