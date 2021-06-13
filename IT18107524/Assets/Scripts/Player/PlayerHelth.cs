using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class PlayerHelth : MonoBehaviour
{

    public Vector3 location;
    public CharactorSwap Swap;

    public Image Heart1;
    public Image Heart2;
    public Image Heart3;
    public Image Heart4;
    public Image Heart5;
    
    public Slider Helthslider;
    public GameObject PlayerManager;
    public GameObject  P02;
    public GameObject  P03;
    public GameObject  P04;

    public int maxhelthcount = 5;
    private float maxHelth = 100f;
    public float currentHelth = 0f;
    // Start is called before the first frame update
    void Start()
    {
       currentHelth = maxHelth;
    }

    // Update is called once per frame
    void Update()
    {

            if (Input.GetKeyDown(KeyCode.Return))
                TakeDamage(50f);

                if(maxhelthcount > 5){
                    maxhelthcount =5;
                }

                switch (maxhelthcount)
                {
                    case 5:
                        Heart1.gameObject.SetActive(true);
                        Heart2.gameObject.SetActive(true);
                        Heart3.gameObject.SetActive(true);
                        Heart4.gameObject.SetActive(true);
                        Heart5.gameObject.SetActive(true);
                        break;

                    case 4:
                        Heart1.gameObject.SetActive(true);
                        Heart2.gameObject.SetActive(true);
                        Heart3.gameObject.SetActive(true);
                        Heart4.gameObject.SetActive(true);
                        Heart5.gameObject.SetActive(false);
                        break;

                    case 3:
                        Heart1.gameObject.SetActive(true);
                        Heart2.gameObject.SetActive(true);
                        Heart3.gameObject.SetActive(true);
                        Heart4.gameObject.SetActive(false);
                        Heart5.gameObject.SetActive(false);
                        break;

                    case 2:
                        Heart1.gameObject.SetActive(true);
                        Heart2.gameObject.SetActive(true);
                        Heart3.gameObject.SetActive(false);
                        Heart4.gameObject.SetActive(false);
                        Heart5.gameObject.SetActive(false);
                        break;
                    
                    case 1:
                        Heart1.gameObject.SetActive(true);
                        Heart2.gameObject.SetActive(false);
                        Heart3.gameObject.SetActive(false);
                        Heart4.gameObject.SetActive(false);
                        Heart5.gameObject.SetActive(false);
                        break;

                    case 0:
                        Heart1.gameObject.SetActive(false);
                        Heart2.gameObject.SetActive(false);
                        Heart3.gameObject.SetActive(false);
                        Heart4.gameObject.SetActive(false);
                        Heart5.gameObject.SetActive(false);
                        
                        break;
                    
                  
                }
           
        
    }

    public void TakeDamage(float damage){

        if(currentHelth < 0.01f){
            LoseLife();
            
            // Debug.Log("PlayerDied");
            // this.GetComponentInChildren<Animator>().SetBool("Dead",true);
            // P02.GetComponent<Player02Movement>().enabled= false;
            // P03.GetComponent<Player03Movement>().enabled= false;
            // P04.GetComponent<Player04Movement>().enabled= false;
            //  P02.GetComponent<P02Attack>().enabled= false;
            // P03.GetComponent<P03Attack>().enabled= false;
            // P04.GetComponent<P04Attack>().enabled= false;
            // PlayerManager.GetComponent<CharactorSwap>().enabled = false;
            // this.enabled = false;
          
            
           
        }else{
                currentHelth  -= damage;
                Helthslider.value = currentHelth;
                // Debug.Log("TookDamage = "+ damage);
        }

    }


    public void LoseLife(){

            
            Swap.RespawnPlayer(location);
            Debug.Log("PlayerLoose 1 life");
            maxhelthcount -= 1;
            currentHelth = maxHelth;
            Helthslider.value = currentHelth;
            if(maxhelthcount <= 0){
                Die();
            }
    }


    public void Die(){
        Debug.Log("PlayerDied");
          SceneManager.LoadScene(4);
        Time.timeScale = 0;
    }

    public void SetLocation(Vector3 loc){
        location = loc;

    }
}
