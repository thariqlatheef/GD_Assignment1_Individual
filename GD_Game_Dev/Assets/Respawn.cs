using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Vector3 position;
    public PlayerHelth helth;


    private void OnTriggerEnter2D(Collider2D other) {
         if (other.transform.tag == "Player")
        {
        
         position = this.transform.position;
         helth.SetLocation(position);
         Debug.Log(position);

        }


    }

    public Vector3 GetLocation(){
        return position;
    }
}
