using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class upgradeMenuScript : MonoBehaviour
{
    [SerializeField] private Text damageTextP1;
    [SerializeField] private Text damageTextP2;
    [SerializeField] private Text damageTextP3;
    [SerializeField] private Text cellBalance;

    public P02Attack P02;
     public P03Attack P03;
      public P04Attack P04;

    private cellUiScript cellCountRef;
    public Counter counter; //get the cell count from counter script

    private float damageP1 = 10f; //asigned this same value for all player damages
    private float damageP2 = 20f;
    private float damageP3 = 30f;
    private float damageMultiplier = 1.3f;
    private int upgradeCost = 20;
    private int cellCount = 0; //otherwise thiss will be null

    private void Start()
    {
         P02.SetDamage(damageP1);
          P03.SetDamage(damageP2);
        P04.SetDamage(damageP3);
        //cellCountRef = FindObjectOfType<cellUiScript>();
        //cellCount = cellCountRef.tempCellCount;
        cellCount = counter.GetCellCount();
        if (cellCount == 0)
        {
            Debug.Log("cellCount == 0");
        }
        else
        {
            Debug.Log("cellCount != 0");
        }
    }
    


    private void OnEnable()
    {
        //cellCount = cellCountRef.tempCellCount;
        cellCount = counter.GetCellCount();
        updateValues();
        Debug.Log(cellCount);
    }
    private void updateValues()
    {
        cellBalance.text = "Cells: " + cellCount;
        damageTextP1.text = "Current Damage : " + damageP1.ToString();
        damageTextP2.text = "Current Damage : " + damageP2.ToString();
        damageTextP3.text = "Current Damage : " + damageP3.ToString();
        
        //cellCountRef.tempCellCount = cellCount; //change the cellUiScript cell count to current latest cell count
    }

    public void upgradeFunctionP1()
    {
        Debug.Log("btn preesed");
        if (cellReducer())
        {
            damageP1 = (int)(damageP1 * damageMultiplier);
            updateValues();
            P02.SetDamage(damageP1);
            
        }
    }

    public void upgradeFunctionP2()
    {
        Debug.Log("btn preesed");
        if (cellReducer())
        {
            damageP2 = (int)(damageP2 * damageMultiplier);
            updateValues();
             P03.SetDamage(damageP2);
            
        }
    }

    public void upgradeFunctionP3()
    {
        Debug.Log("btn preesed");
        if (cellReducer())
        {
            damageP3 = (int)(damageP3 * damageMultiplier);
            updateValues();
            P04.SetDamage(damageP3);
      
        }
    }

    private bool cellReducer()
    {
        Debug.Log("at cell reducer");
        if (cellCount < upgradeCost)
        {
            return false;
        }
        else
        {
            cellCount -= upgradeCost;
            upgradeCost += 5;
            counter.SetCellCount(cellCount);
            return true;
        }
    }
}
