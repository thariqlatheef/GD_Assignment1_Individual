using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedallionCollector : MonoBehaviour
{
   public int MedallionCount = 0;
   public Counter  Count;
    private void OnTriggerEnter2D(Collider2D other) {

        if(other.transform.tag == "Player"){
            MedallionCount ++;
             Count.SetMedallionCount(1);
            Destroy(this.gameObject);
        }
        
    }

     public int GetMedallionCount(){
        return MedallionCount;
    }
}
