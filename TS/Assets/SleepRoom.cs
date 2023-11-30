using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepRoom : MonoBehaviour
{
    public GameObject SUN;
    public void Lamp()
    {
        if (SUN.active)
        {
            SUN.SetActive(false);
        }
        else
        {
            SUN.SetActive(true);
        }
       
    }
}
