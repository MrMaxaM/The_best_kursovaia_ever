using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NewBehaviourScript : MonoBehaviour

{
    bool MS = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
            transform.Rotate(0, -2.0F * Input.GetAxis("Mouse X"), -2.0F * Input.GetAxis("Mouse Y"));
    }
}
