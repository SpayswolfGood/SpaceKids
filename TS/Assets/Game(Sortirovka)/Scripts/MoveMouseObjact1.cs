using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMouseObjact1 : MonoBehaviour
{
    public Camera Cam;
    [SerializeField]
    private float enter;//Растояние от камеры до объекта
    private GameObject sdvig;//Объект который имеет тег Sdvig
    void Start()
    {
        Cam.GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {

            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, enter);
            Vector3 cursor = Cam.ScreenToWorldPoint(mousePosition);
            if (sdvig != null)
            {
                sdvig.transform.position = cursor;//можно использовать fingerPos
            }
            RaycastHit hit;
            Ray ray = Cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 30))
            {
                if (hit.collider.tag == "Sdvig")//Объект который перемещается
                {
                    sdvig = hit.collider.gameObject;
                }
            }
        }
        else
        {
            sdvig = null;
        }
    }
}
