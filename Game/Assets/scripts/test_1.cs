using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;


public class test_1 : MonoBehaviour
{
    public GameObject akm;
    private float[] akm_position = new float[3];
    private float SPEED = 1f;

    private bool flag = false;
    private int direction = 1;
    private int count = 0;
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            akm_position[0] = akm.GetComponent<Transform>().position.x;
            akm_position[1] = akm.GetComponent<Transform>().position.y;
            akm_position[2] = akm.GetComponent<Transform>().position.z;
            GetComponent<Transform>().position = new Vector3(akm_position[0]-4.458f, 8.5f, akm_position[2] - 0f);
        }
        
        if(Input.GetKeyDown(KeyCode.A)) flag = !flag;

        if(flag)
        {
            float cord_y = GetComponent<Transform>().position.y;
            if(cord_y >= 11.218 | cord_y <= 8.5) direction *= -1;
            GetComponent<Transform>().Translate(new Vector3(0, direction, 0) * SPEED * Time.deltaTime);   
        }
        
    }
}