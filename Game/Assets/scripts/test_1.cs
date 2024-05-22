using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class test_1 : MonoBehaviour
{
    public GameObject akm;
    public GameObject silencer;
    public RectTransform line;
    public GameObject scale;

    private float SPEED = 1.5f;
    private float SPEED_LINE = 1.5f * 49f;

    private bool flag = false;
    private int direction = 1;
    private int count = 0;
    private float[] akm_position = new float[3];

    private void Start()
    {
        scale.SetActive(false);
    }
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            akm_position[0] = akm.GetComponent<Transform>().position.x;
            akm_position[1] = akm.GetComponent<Transform>().position.y;
            akm_position[2] = akm.GetComponent<Transform>().position.z;
            silencer.GetComponent<Transform>().position = new Vector3(akm_position[0]-4.458f, 7.5f, akm_position[2] - 0f);
            scale.SetActive(true);
        }
        
        if(Input.GetKeyDown(KeyCode.A)) flag = !flag;

        if(flag)
        {
            float cord_y = silencer.GetComponent<Transform>().position.y;
            if(cord_y >= 12.218 | cord_y <= 7.5) direction *= -1;
            silencer.GetComponent<Transform>().Translate(new Vector3(0, direction, 0) * SPEED * Time.deltaTime);
            line.GetComponent<RectTransform>().Translate(new Vector3(0, direction, 0) * SPEED_LINE * Time.deltaTime);
        }
        
    }
}