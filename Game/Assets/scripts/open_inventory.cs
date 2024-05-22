using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open_inventory : MonoBehaviour
{
    public GameObject panel;

    private void Start() 
    {
        panel.SetActive(false);
    }
    private void OnMouseUp() 
    {
        panel.SetActive(true);
    }
}
