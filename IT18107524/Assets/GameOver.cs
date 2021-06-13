using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
      private void Start() {
        Time.timeScale = 1;
  }
    public void MainMenu(){
            SceneManager.LoadScene(0);
    }

     public void Replay(){
        SceneManager.LoadScene(2);
    }
}
