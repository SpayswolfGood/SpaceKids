using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAsteroydErch : MonoBehaviour
{
    public float speed;
    public GameObject erch;
    private void Start()
    {
        speed = Random.Range(0.5f,3.5f);
        transform.localScale = new Vector3(Random.Range(1f, 3f), Random.Range(1f, 3f), Random.Range(1f, 3f));
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position ,erch.transform.position,speed * Time.deltaTime);
    }
}
