using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMouseObjact : MonoBehaviour
{
    public Camera Cam;
    [SerializeField]
    private float enter;//��������� �� ������ �� �������
    public GameObject sdvig;

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {

            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, enter);
            Vector3 cursor = Cam.ScreenToWorldPoint(mousePosition);
            if (sdvig != null)
            {
                sdvig.transform.position = cursor;//������ ������� �� ��������
            }
            RaycastHit hit;
            Ray ray = Cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 30))
            {
                if (hit.collider.tag == "Sdvig")//������ ������� ������������
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
