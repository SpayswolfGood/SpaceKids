using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DeadZone : MonoBehaviour
{
    public GameObject Dead;//UI окно после смерти
    private void Start()
    {
        Dead.SetActive(false);
        Time.timeScale = 1;
    }
    private void OnCollisionEnter(Collision collision)
    {
      
        if(collision.gameObject.tag == "Sdvig")
        {
            Dead.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
