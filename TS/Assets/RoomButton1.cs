using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomButton : MonoBehaviour
{
    public GameObject[] room;
    public GameObject[] roomUI;
    public int id;
    public GameObject Sun;

    public Animator[] player;

    public Potrebnosty potrebnosty;
    private void Start()
    {
        room[id].SetActive(true);
        roomUI[id].SetActive(true);
    }
    public void ActeveRoom()
    {
        if (Sun.activeSelf == false)
        {
            Sun.SetActive(true);
        }
        roomUI[id].SetActive(false);
        room[id].SetActive(false);
        id = 0;
        room[id].SetActive(true);
        roomUI[id].SetActive(true);
        player[0].SetBool("IsSUN", true);
        player[1].SetBool("IsSUN", true);
    }
    public void BadRoom()
    {
        room[id].SetActive(false);
        roomUI[id].SetActive(false);
        id = 1;
        room[id].SetActive(true);
        roomUI[id].SetActive(true);

        player[0].SetBool("IsSUN", false);
        player[1].SetBool("IsSUN", false);

    }

    public void Kitchan()
    {
        if (Sun.activeSelf == false)
        {
            Sun.SetActive(true);
        }
        room[id].SetActive(false);
        roomUI[id].SetActive(false);
        id = 2;
        room[id].SetActive(true);
        roomUI[id].SetActive(true);
        player[0].SetBool("IsSUN", true);
        player[1].SetBool("IsSUN", true);
    }

    public void TooaletRoom()
    {
        if (Sun.activeSelf == false)
        {
            Sun.SetActive(true);
        }
        room[id].SetActive(false);
        roomUI[id].SetActive(false);
        id = 3;
        room[id].SetActive(true);

    }

    private void Update()
    {
        if(id == 1)
        {
            player[0].Play("Sleep");
            player[1].Play("Sleep");
        }
        if (id == 3)
        {
            potrebnosty.isTooalet = true;
            player[0].gameObject.transform.position = new Vector3(-0.430999994f, 0f, -2.37299991f);
            player[0].gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            player[1].gameObject.transform.position = new Vector3(-0.430999994f, 0f, -2.37299991f);
            player[1].gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            potrebnosty.isTooalet = false;
            player[0].gameObject.transform.position = new Vector3(0, 0, -2.189697f);
            player[0].gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            player[1].gameObject.transform.position = new Vector3(0, 0, -2.189697f);
            player[1].gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

}
