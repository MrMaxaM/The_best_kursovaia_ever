using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class parsing : MonoBehaviour
{
    static private string [] mods = {"WPN_AKM_magazine", "AKM_Shompol", "AKM_Cevie", "AKM_Cover", "AKM_Pruzhina", "AKM_Rukoyat", "AKM_Priklad"};
    static Dictionary <string, bool> moved_before = new Dictionary<string, bool>();
    static int i_current_mod = 0;


    bool queue = false;


    private int i = 0;
    

    Vector3 mouse_position_old;
    Vector3 mouse_position;

    
    private void OnMouseDown() 
    {
        if (i_current_mod < 7)
        {
            i = 0;
            bool temp;
            if(name ==  mods[i_current_mod] && !(moved_before.TryGetValue(name, out temp))) queue = true;
            else
            {
                Debug.Log("  CURRENT:   " + name + "   WAITING FOR:   " + mods[i_current_mod] + "  возможность перемещать:   " + queue);
            }
        }
    }


    private void OnMouseDrag() 
    {
        if(i_current_mod < 7 && queue)
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
        }
    }


    private void OnMouseUp() 
    {
        if (i_current_mod < 7)
        {
            bool temp;
            if (queue && !(moved_before.TryGetValue(name, out temp)))
            {
                i_current_mod++;
                if (!moved_before.ContainsKey(name)) moved_before.Add(name, true);
            }
         }
    }
}