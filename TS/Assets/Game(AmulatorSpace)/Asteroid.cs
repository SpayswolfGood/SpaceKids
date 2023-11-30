using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    public float speed;
    void Start()
    {
        speed = Random.Range(3,15);
    }

    void Update()
    {
        transform.Translate(-Vector3.forward * speed * Time.deltaTime); 
        if(transform.position.z <= -10)
        {
            Destroy(gameObject);
        }
    }
}
