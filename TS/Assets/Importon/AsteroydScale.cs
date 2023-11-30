using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroydScale : MonoBehaviour
{
    public float min;
    public float max;
    void Start()
    {
        transform.localScale = new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max));
    }

}
