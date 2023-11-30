using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DalyPodarock : MonoBehaviour
{
    public bool Podarock;// ������ �� �������
    public GameObject podarockUI;
    public CoinAlmaz coinAlmaz;
    void Start()
    {
        Time.timeScale = 1;
        ChackDaly();

    }

    public void GivePodarock()
    {
        if(Podarock == true)///���� �� ������
        {
            coinAlmaz.coin += Random.Range(20,100);
            coinAlmaz.almaz += Random.Range(0, 5);
            PlayerPrefs.SetInt("coin",coinAlmaz.coin);
            PlayerPrefs.SetInt("almaz",coinAlmaz.almaz);
            Podarock = false;
            podarockUI.SetActive(false);
            SaveDay();
            ChackDaly();
        }

    }

    public void ChackDaly()
    {

            System.DateTime lastVhod = System.DateTime.Parse(PlayerPrefs.GetString("LastVxod"));//����������� �������� ���������� �����
            if (lastVhod.Date < System.DateTime.Now.Date)//���� ���� ������ ������������
            {
                Podarock = true;
                podarockUI.SetActive(true);
            }
            else
            {
                Podarock = false;
                podarockUI.SetActive(false);
            }   
    }

    public void SaveDay()//��������� ���� 
    {
        PlayerPrefs.SetString("LastVxod", System.DateTime.Now.ToString());
    }
}
