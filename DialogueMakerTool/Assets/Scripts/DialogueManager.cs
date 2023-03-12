using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public bool inputFieldActive = false;
    public string[] dialogueLines;
    public GameObject newSentence;

    public List<GameObject> dialogueHolder;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !inputFieldActive)
        {
            Instantiate(newSentence, gameObject.transform.position, Quaternion.identity, gameObject.transform);
        }
    }

    public void AddSentence(string newSentence)
    {
        if (dialogueLines == null)
        {
            dialogueLines = new string[1];
            dialogueLines[0] = newSentence;
        }
        else
        {
            Array.Resize(ref dialogueLines, dialogueLines.Length + 1);
            dialogueLines[dialogueLines.Length - 1] = newSentence;
        }
    }
    public void ModifySentenceByText(string originalSentence, string newSentence)
    {
        int indexToModify = -1;
        for (int i = 0; i < dialogueLines.Length; i++)
        {
            if (dialogueLines[i] == originalSentence)
            {
                indexToModify = i;
                break;
            }
        }

        if (indexToModify >= 0)
        {
            dialogueLines[indexToModify] = newSentence;
        }
        else
        {
            AddSentence(newSentence);
        }
    }
    public void OnInputFieldClicked(string text)
    {
        inputFieldActive = true;
    }

    public void OnInputFieldEndEdit(string text)
    {
        inputFieldActive = false;
    }
}
