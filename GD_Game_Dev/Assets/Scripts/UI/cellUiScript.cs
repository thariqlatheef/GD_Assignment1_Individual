using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[RequireComponent(typeof(Text))]
public class cellUiScript : MonoBehaviour
{
    private Text cellText;

    public int tempCellCount = 50;

    void Awake()
    {
        cellText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        cellText.text = "Cells: " + tempCellCount.ToString(); //add the masterclass cell count
    }
}
