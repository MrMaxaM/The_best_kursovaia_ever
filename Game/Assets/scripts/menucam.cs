using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;

public class menucam : MonoBehaviour
{
    public Vector3 startpos;
    public Vector3 endpos;
    public float startangel;
    public float endangel;
    public float speed = 1f;
    public bool toend;

    private void Update()
    {
        if (toend)
        {
            transform.position = Vector3.Lerp(transform.position, endpos, speed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, endangel, 0), speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, startpos, speed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, startangel, 0), speed * Time.deltaTime);
        }
    }

    public void Changepos()
    {
        toend = !toend;
    }
}
