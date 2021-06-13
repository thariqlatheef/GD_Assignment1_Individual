using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;
    public Image charactorImage;

    public Animator animator;


    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {

        sentences =  new Queue<string>();
        
    }

    public void StartDialogue( Dialogue dialogue){

        // Debug.Log("Conversation Start" + dialogue.name);

        animator.SetBool("IsOpen",true);
        nameText.text = dialogue.name;
        charactorImage.sprite = dialogue.sprite;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

    }

    public void DisplayNextSentence(){

        if(sentences.Count == 0){
            EndDialogue();
            return;
        }

        string sentence =  sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        // dialogueText.text = sentence;
        // Debug.Log(sentence);

    }

    IEnumerator TypeSentence (string sentence){
            dialogueText.text = "";
            foreach (char letter in sentence.ToCharArray())
            {
                dialogueText.text += letter;
                yield return null;
            }
    }

    void EndDialogue(){
        // Debug.Log("End of Conversation");
        animator.SetBool("IsOpen",false);
    }

}
