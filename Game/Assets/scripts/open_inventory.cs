using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open_inventory : MonoBehaviour
{
    public GameObject inventory_panel;

    private void Start() 
    {
        inventory_panel.SetActive(false);
    }

    private void OnMouseDown() 
    {
       inventory_panel.SetActive(true); 
    }
}
