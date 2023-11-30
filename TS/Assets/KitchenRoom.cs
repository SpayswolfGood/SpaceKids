using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenRoom : MonoBehaviour
{

    public List<EatNumber> eats;
    public int i;
    private int index;
    public GameObject productMenu;
    public Product[] product;
    public GameObject[] productEat;
    public CoinAlmaz coinAlmaz;
    private  int count = -1;

    public TextMesh Col;

    [SerializeField]
    private int[] cena;
    private void Start()
    {
        Col.text = " ";
        eats = PlayerPrefsExtra.GetList<EatNumber>("Kitchen", new List<EatNumber>());
        if (eats.Count != 0)
        {
            for (int i = 1; i < eats.Count; i++)
            {
                eats[i].eat.SetActive(false);
            }
            eats[0].eat.SetActive(true);
            Col.text = eats[0].number.ToString();
        }
    }

    private void LateUpdate()
    {
        if(eats.Count != 0)
        {
            Col.text = eats[i].number.ToString();
        }
        else if(eats.Count == 0)
        {
            Col.text = " ";
        }
    }
    public void Left()
    {
        i--;
        if(i < 0)
        {
            i = 0;
        }
        else
        {
            eats[i].eat.SetActive(true);
            Col.text = eats[i].number.ToString();
            eats[i + 1].eat.SetActive(false);
        }

    }

    public void Right()
    {
        i++;
        if (i > eats.Count -1)
        {
            i = eats.Count-1;
        }
        else
        {
            eats[i].eat.SetActive(true);
            Col.text = eats[i].number.ToString();
            eats[i - 1].eat.SetActive(false);
        }
    }

    public void ProductMenu()
    {
        productMenu.SetActive(true);
    }

    public void BackProductMenu()
    {
        productMenu.SetActive(false);
    }

    public void PokupkaProduct(int id)
    {
        if(coinAlmaz.coin >= cena[id])
        {
            for (int i = 0; i < eats.Count; i++)
            {
                if (eats[i].Product.id == id)
                {
                    count = id;
                    index = i;
                    break;
                }
            }

            if (count < 0)
            {
                eats.Insert(eats.Count, new EatNumber());
                eats[eats.Count - 1].number = 1;
                eats[eats.Count - 1].Product = product[id];
                eats[eats.Count - 1].eat = productEat[id];
                coinAlmaz.coin -=  cena[id];
                PlayerPrefs.SetInt("coin", coinAlmaz.coin);
                eats[0].eat.SetActive(true);
                count = -1;
            }
            else
            {
                eats[index].number++;
                coinAlmaz.coin -= cena[id];
                PlayerPrefs.SetInt("coin", coinAlmaz.coin);
                eats[0].eat.SetActive(true);
                count = -1;
            }
            PlayerPrefsExtra.SetList("Kitchen", eats);

        }

    }
}
[System.Serializable]
 public class EatNumber 
{
    public int number;
    public GameObject eat;
    public Product Product;
}
