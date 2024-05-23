using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repair_start_sets : MonoBehaviour
{
    public GameObject [] set_inactive;

    private void Start() 
    {
        for (int i = 0; i < set_inactive.Length; i++) set_inactive[i].SetActive(false);   
    }
}
