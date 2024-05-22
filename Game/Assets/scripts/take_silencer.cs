using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class take_silencer : MonoBehaviour
{
    public int count;
    private void Start() 
    {
        count = 0;  
    }

    public void but_click()
    {
        count ++;
        Debug.Log(count);
    }
}
