using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text cellCount;
    public Text medallionCount;



    public int cell = 0;
    public int medallion;

    void Start()
    {
        cellCount.text = "Cell : 0";
        medallionCount.text = "Medallion : 0";
    }

    public void AddCellCount(int Count)
    {
        cell += Count;
        cellCount.text = "Cell - " + cell.ToString();
    }

    public void SetCellCount(int Count)
    {
        cell = Count;
        cellCount.text = "Cell - " + cell.ToString();
    }

    public void SetMedallionCount(int Count)
    {
        medallion += Count;
        medallionCount.text = "Medallion - " + medallion.ToString();
    }

    //funtions for set and get cellcount
    public int GetCellCount()
    {
        return cell;
    }
    public void SetCellCountForPublic(int CellCount)
    {
        cell = CellCount;
    }

    public int GetGateCount(){
        return medallion;
    }
}
