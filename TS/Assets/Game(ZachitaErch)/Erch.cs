using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Erch : MonoBehaviour
{
    public float speed;
    public GameObject Deadpanel;
    private void Start()
    {
        Time.timeScale = 1;
        Deadpanel.SetActive(false);
    }
    void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Respawn")
        {
            Deadpanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
