using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement_Trigger : MonoBehaviour
{
    public DialogueTrigger dTrigger;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            dTrigger.TriggerDialogue();
            Debug.Log("Player Enterd");
            Destroy(this.gameObject);
        }
    }
}
