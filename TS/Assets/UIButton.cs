using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
public class UIButton : MonoBehaviour
{
    public string vk;
    public string youtube;
    public GameObject menu;
    public GameObject promocode;
    [SerializeField]
    private List<string> Promo;
    [SerializeField]
    private InputField promo;
    public CoinAlmaz coinAlmaz;
    [SerializeField]
    private InputField InputName;

    public Text Name;
    private void Start()
    {
        Name.text = PlayerPrefs.GetString("InputName");
        Promo = PlayerPrefsExtra.GetList<string>("Promo", new List<string>());
        if (Name.text == "")
        {
            Name.text = "Name";
        }
    }

    #region Button
    public void PromocodeButton()
    {
        for (int i = 0; i < Promo.Count; i++)
        {
            if (promo.text == Promo[i])
            {
                coinAlmaz.coin += 10000;
                promo.text = "";
                PlayerPrefs.SetInt("coin", coinAlmaz.coin);
                Promo.RemoveAt(i);
                PlayerPrefsExtra.SetList("Promo", Promo);
                promocode.SetActive(false);
            }
        }
    }
    public void YearButton()
    {
        if(menu.activeSelf == true)
        {
            menu.SetActive(false);
        }
        else
        {
            menu.SetActive(true);
        }
    }
    public void CloseMenu()
    {
        menu.SetActive(false);
    }

    public void Promocode()
    {
        promocode.SetActive(true);
    }

    public void ClosePromocode()
    {
        promocode.SetActive(false);
    } 

    public void Settings()
    {

    }

    public void Shop()
    {

    }

    public void VK()
    {
        Application.OpenURL(vk);
    }

    public void YouTube()
    {
        Application.OpenURL(youtube);
    }

    public void NameInput()
    {
        PlayerPrefs.SetString("InputName",InputName.text);
    }
    #endregion
}
