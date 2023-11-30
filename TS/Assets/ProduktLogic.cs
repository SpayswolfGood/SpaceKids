using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProduktLogic : MonoBehaviour
{
    public GameObject pos;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            transform.position = pos.transform.position;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {

        }
    }
}
