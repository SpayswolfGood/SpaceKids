using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMatirialObjact : MonoBehaviour
{
    public Material[] matirials;
 
    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material = matirials[Random.Range(0,matirials.Length)] ;//Меняем матерьял объекта на рандомный
    }


}
