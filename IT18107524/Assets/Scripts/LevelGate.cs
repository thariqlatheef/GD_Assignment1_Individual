using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGate : MonoBehaviour
{

    public GameObject Gate01;
    public GameObject  Gate02;

    public Counter GateKey;

    

    // Update is called once per frame
    void Update()
    {
        
        if(GateKey.GetGateCount() == 1){

            Gate01.SetActive(false);

        }else if (GateKey.GetGateCount() == 2)
        {
            Gate02.SetActive(false);
        }

    }
}
