using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class mouse_move : MonoBehaviour
    {
    Vector3 mouse_position_old;
    Vector3 mouse_position;

    private int i = 0;
    void OnMouseDrag() 
        {
            if(i == 0) mouse_position_old = Input.mousePosition;
            float start_x = GetComponent<Transform>().position.x;
            float start_z = GetComponent<Transform>().position.z;
            mouse_position = Input.mousePosition;
            start_x += 0.01525f * (mouse_position.x - mouse_position_old.x);
            start_z += 0.01525f * (mouse_position.y - mouse_position_old.y);
            mouse_position_old = mouse_position;
            transform.position = new Vector3(start_x, GetComponent<Transform>().position.y, start_z);
            i++;
        }

        void OnMouseDown() 
        {
            i = 0;
        }
    
   



    



    
    }
