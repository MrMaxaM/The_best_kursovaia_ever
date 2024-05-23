using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fade : MonoBehaviour
{
    public GameObject Camera1;
    public GameObject Camera2;
    public GameObject self;

    public float fadespeed;

    public void Fade() 
    {
        StartCoroutine(StartFade());
    }
    public IEnumerator StartFade()
    {

            Image fade_image = GetComponent<Image>();
            Color color = fade_image.color;

            while (color.a < 1f)
            {
                color.a += fadespeed * Time.fixedDeltaTime;
                fade_image.color = color;
                yield return new WaitForSeconds(0.01f);
            }

            yield return new WaitForSeconds(0.5f);

            if (Camera1.activeSelf == true)
            {
                Camera2.SetActive(true);
                Camera1.SetActive(false);
            }
            else
            {
                Camera1.SetActive(true);
                Camera2.SetActive(false);
            }

            while (color.a > 0)
            {
                color.a -= fadespeed * Time.fixedDeltaTime;
                fade_image.color = color;
                yield return new WaitForSeconds(0.01f);
            }

            self.SetActive(false);

        
    }

}
