using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class repair : MonoBehaviour
{
    public GameObject locker;
    public Material new_material;

    private void Start()
    {
        ;
    }
    void Update()
    {
        if (Math.Abs(transform.position.x - locker.transform.position.x) < 3 && 
            Math.Abs(transform.position.z - locker.transform.position.z) < 3)
        {
            GetComponent<MeshRenderer>().material = new_material;
            Debug.Log("Столкновение");
        }
    }
}
