using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class test_1 : MonoBehaviour
{
    public GameObject akm;
    private float[] akm_position = new float[3];
  
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            akm_position[0] = akm.GetComponent<Transform>().position.x;
            akm_position[1] = akm.GetComponent<Transform>().position.y;
            akm_position[2] = akm.GetComponent<Transform>().position.z;
            GetComponent<Transform>().position = new Vector3(akm_position[0]-4.458f, akm_position[1] -0.092f, akm_position[2] + 0f);
        }
    }
}