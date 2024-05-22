using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class close_inventory : MonoBehaviour
{
    public GameObject inventory_panel;
    public void Close()
    {
        inventory_panel.SetActive(false);
    }
}
