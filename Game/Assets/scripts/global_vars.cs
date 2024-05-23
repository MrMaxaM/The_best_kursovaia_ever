using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class global_vars : MonoBehaviour
{
    static private string [] mods = {"WPN_AKM_magazine", "AKM_Shompol", "AKM_Cevie", "AKM_Cover", "AKM_Pruzhina", "AKM_Rukoyat", "AKM_Priklad"};
    static int i_current_mod = 0;


    bool can_take = false;
    bool moved = false;


    private int i = 0;
    

    Vector3 mouse_position_old;
    Vector3 mouse_position;


    private void OnMouseDown() 
    {
        i = 0;
        if(name ==  mods[i_current_mod]) can_take = true;
        else Debug.Log("name: " + name + "mods[i_current_mod].name: " + mods[i_current_mod]);   
    }


    private void OnMouseDrag() 
    {
        if(can_take)
        {
            if(i == 0) mouse_position_old = Input.mousePosition;
            float start_x = GetComponent<Transform>().position.x;;
            float start_z = GetComponent<Transform>().position.z;
            mouse_position = Input.mousePosition;
            start_x += 0.01525f * (mouse_position.x - mouse_position_old.x);
            start_z += 0.01525f * (mouse_position.y - mouse_position_old.y);
            mouse_position_old = mouse_position;
            transform.position = new Vector3(start_x, GetComponent<Transform>().position.y, start_z);
            i++;
            moved = true;
        }
    }

    private void OnMouseUp() 
    {
        if(moved && can_take) i_current_mod++;
    }
}