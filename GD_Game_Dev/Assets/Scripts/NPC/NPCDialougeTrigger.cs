using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialougeTrigger : MonoBehaviour
{

    public DialogueTrigger diagogueTrigger;

      private void OnTriggerEnter2D(Collider2D other) {

        if(other.transform.tag == "Player"){
            diagogueTrigger.TriggerDialogue();
            Debug.Log("Player Enterd");
             Destroy(this.gameObject);
        }
        
    }
}
