using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    public string[] dialogue;
    [Min(0)] public int index = 0;

    public TextMeshProUGUI text;
    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue() 
    {
        sentences = new Queue<string>();
        sentences.Clear();

	    foreach(string sentence in dialogue)
        {
            sentences.Enqueue(sentence);
        }
	    NextDialogue();
    }

    public void NextDialogue()
    {
        if(index == dialogue.Length - 1 && sentences.Count == 0) 
        {
            GetComponent<AudioSource>().enabled = false;
            SceneManager.LoadScene("Titres");
        }

        if (index < dialogue.Length - 1) 
        {
            index++;
            StopAllCoroutines();
            StartCoroutine(Typesentence(dialogue[index]));
        }
    }
    public IEnumerator Typesentence(string sentence)
    {
        text.text = "";
	
        foreach(char letter in sentence.ToCharArray())
        {
            text.text += letter;
            yield return null;

        }
        yield return new WaitForSeconds(1f);
        NextDialogue();
    }
    public void PreviousDialogNPS() 
    {
        if (index > 0)
        {
            index--;
            StopAllCoroutines();
            StartCoroutine(Typesentence(dialogue[index]));
        }
    }
}

/*
string sentence = sentences.Dequeue();
StopAllCoroutines();
StartCoroutine(Typesentence(dialog[index]));
*/