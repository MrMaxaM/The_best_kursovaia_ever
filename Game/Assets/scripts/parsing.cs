using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class parsing : MonoBehaviour
{
    static private string [] mods = {"WPN_AKM_magazine", "AKM_Shompol", "AKM_Cevie", "AKM_Cover", "AKM_Pruzhina", "AKM_Rukoyat", "AKM_Priklad"};
    
    static Dictionary <string, bool> moved_before = new Dictionary<string, bool>();
    static int i_current_mod = 0;
    static bool parsing_turn = true;
    static bool assembling_turn = false;


    private float INACCURACY = 0.3f;
    bool queue_parsing = false;
    bool queue_assembling = false;


    public Vector3 original_position;


    private int i = 0;
    
    Vector3 mouse_position_old;
    Vector3 mouse_position;
    
    /*
    private bool less_eq(Vector3 a, Vector3 b)
    {
        if ((a.x <= b.x) && (a.y <= b.y) && (a.z <= b.z)) return true;
        else return false;
    }
    private bool More_eq(Vector3 a, Vector3 b)
    {
        if ((a.x >= b.x) && (a.y >= b.y) && (a.z >= b.z)) return true;
        else return false;
    }

    */

    private bool Is_inaccuracy_zone(Vector3 dot, Vector3 start, float inaccuracy)
    {
        if( (start.y + inaccuracy >= dot.y) && (start.z + inaccuracy >= dot.z) && (start.y - inaccuracy <= dot.y) && (start.z - inaccuracy <= dot.z)) return true;
        else return false;
    }


    private void Start() 
    {
        original_position = transform.position;    
    }

    private void OnMouseDown() 
    {

        
        if (i_current_mod < 7 && parsing_turn) //parsing
        {
            i = 0;
            bool temp;
            if(name ==  mods[i_current_mod] && !(moved_before.TryGetValue(name, out temp))) queue_parsing = true;
            else
            {
                Debug.Log("  CURRENT:   " + name + "   WAITING FOR:   " + mods[i_current_mod] + "  возможность перемещать:   " + queue_parsing);
            }
        }

        if (i_current_mod >= 0 && assembling_turn) //assembling
        {
            i = 0;
            bool temp;
            if(name ==  mods[i_current_mod] && !(moved_before.TryGetValue(name, out temp))) queue_assembling = true;
            else
            {
                queue_assembling = false;
                Debug.Log("  CURRENT:   " + name + "   WAITING FOR:   " + mods[i_current_mod] + "  возможность перемещать:   " + queue_assembling);
            }
        }
    }


    private void OnMouseDrag() 
    {
        if(i_current_mod < 7 && queue_parsing && parsing_turn) //parsing
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

        if(i_current_mod >= 0 && (queue_assembling) && assembling_turn) //assembling
        {
            if(queue_assembling)
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
    }


    private void OnMouseUp() 
    {
        
        if (i_current_mod >= 0 && queue_assembling && assembling_turn) //assembling
        {
            bool temp;
            if ((queue_assembling) && !(moved_before.TryGetValue(name, out temp)))
            {
                if (Is_inaccuracy_zone(GetComponent<Transform>().position, original_position, INACCURACY))
                {
                    transform.position = original_position;
                    i_current_mod--;
                    if (!moved_before.ContainsKey(name))
                    {
                    moved_before.Add(name, true);
                    }  
                } 
            }
        }

        if (i_current_mod < 7 && queue_parsing && parsing_turn)  //parsing
        {
            bool temp;
            if (queue_parsing && !(moved_before.TryGetValue(name, out temp)))
            {
                i_current_mod++;
                if (!moved_before.ContainsKey(name)) moved_before.Add(name, true);
                if(i_current_mod == 7)
                {
                    i_current_mod = 6;
                    parsing_turn = false;
                    assembling_turn = true;
                    moved_before.Clear();
                }
            }
        }
    }
}