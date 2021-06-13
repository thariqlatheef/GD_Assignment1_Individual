using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellCollector : MonoBehaviour
{
    public int cellCount = 0;

    public int cellvalue;
    public Counter Count;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.transform.tag == "Player")
        {
            Destroy(this.gameObject);
            cellCount++;
            Count.AddCellCount(cellvalue);

        }

    }

    public int GetCellCount()
    {
        return cellCount;
    }
    public void SetCellCount(int CellCount)
    {
        cellCount = CellCount;
    }
}
