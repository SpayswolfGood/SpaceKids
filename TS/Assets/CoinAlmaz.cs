using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CoinAlmaz : MonoBehaviour
{
    public float opit;
    public int opitUP = 1;//Возраст игрока
    public int coin;
    public int almaz;
    public Text cointText;
    public Text almazText;
    public Text Vozrast;

    public Image VozrastSlider;

    [SerializeField]
    private GameObject[] close;

    [SerializeField]
    private GameObject[] player;
    private void Start()
    {
        //Присваивание сохронения
        #region Prisvaevsnie Save 
        coin = PlayerPrefs.GetInt("coin");
        almaz = PlayerPrefs.GetInt("almaz");
        opit = PlayerPrefs.GetFloat("Opit");
        opitUP = PlayerPrefs.GetInt("OpitUP");
        #endregion
        Vozrast.text = opitUP.ToString();
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            OpenClose();
        }
    }

    private void Update()
    {
        cointText.text = coin.ToString();
        almazText.text = almaz.ToString();
        VozrastSlider.fillAmount = opit / opitUP;//Выделяем целую часть
        if(opit >= opitUP)
        {
            coin += 200;
            PlayerPrefs.SetInt("coin", coin);
            opitUP += 1;
            PlayerPrefs.SetInt("OpitUP",opitUP);
            Vozrast.text = opitUP.ToString();
            OpenClose();
        }
    }

    private void OpenClose()
    {

        //Что происходит после преодолевания разных возростов
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (opitUP >= 7) close[0].SetActive(false);
            if (opitUP >= 14) close[1].SetActive(false);
            if (opitUP >= 21) close[2].SetActive(false);         
            if (opitUP < 4)
            {
                player[0].SetActive(true);
                player[1].SetActive(false);
            }
            else if (opitUP >= 4 && opitUP <= 6)
            {
                player[0].transform.localScale = new Vector3(1, 1, 1);
                player[0].SetActive(true);
                player[1].SetActive(false);
            }
            else if (opitUP >= 6 && opitUP <= 9)
            {
                player[0].transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
                player[0].SetActive(true);
                player[1].SetActive(false);
            }
            else if (opitUP >= 10 && opitUP <= 18)
            {
                player[0].SetActive(false);
                player[1].SetActive(true);
            }
            else if ( opitUP > 18)
            {
                player[0].SetActive(false);
                player[1].SetActive(true);
            }
        }
    }
}
