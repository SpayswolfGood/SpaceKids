using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rot : MonoBehaviour
{
    public Potrebnosty potrebnosty;
    public KitchenRoom kitchenRoom;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Sdvig")
        {
            kitchenRoom.eats[kitchenRoom.i].number--;//���� ����� ������� �� ���������� �����������
            if (kitchenRoom.eats[kitchenRoom.i].number<=0)
            {
                //���� ���������� ��� ������ ���������� �������� ����
                kitchenRoom.eats[kitchenRoom.i].eat.SetActive(false);
                kitchenRoom.eats.RemoveAt(kitchenRoom.i);
                PlayerPrefsExtra.SetList("Kitchen", kitchenRoom.eats);
                if (kitchenRoom.eats.Count != 0)
                {
                    kitchenRoom.i = 0;
                    kitchenRoom.eats[kitchenRoom.i].eat.SetActive(true);
                }
            }
            potrebnosty.eat += Random.Range(0.2f,0.5f);//���������� ��� ���������
        } 
    }
}
