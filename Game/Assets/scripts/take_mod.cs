using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeMod : MonoBehaviour
{
    public GameObject mod;
    public void AddSilencer()
    {
        mod.SetActive(true);
    }
}
