using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rift : MonoBehaviour
{
        private void OnTriggerEnter2D(Collider2D other) {
         if (other.transform.tag == "Player")
        {
    
        SceneManager.LoadScene(3);

        }


    }

}
