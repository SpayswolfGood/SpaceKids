using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private bool isDownLeft;
    private bool isDownRight;
    public GameObject deadZone;
    public ScoreManegerAmulatorSpace scoreManeger;
    private void Start()
    {
        deadZone.SetActive(false);
        Time.timeScale = 1;
    }

    public void LeftButton()
    {
        isDownLeft = true;
    }

    public void LeftButtonUp()
    {
        isDownLeft = false;
    }

    public void RightButton()
    {
        isDownRight = true;
    }

    public void RightButtonFalse()
    {
        isDownRight = false;
    }

    private void Update()
    {
        if (isDownLeft) player.transform.Rotate(player.transform.rotation.x, player.transform.rotation.y, speed * Time.deltaTime);
        if (isDownRight) player.transform.Rotate(player.transform.rotation.x, player.transform.rotation.y, -speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sdvig")
        {
            scoreManeger.Smert();
            deadZone.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
