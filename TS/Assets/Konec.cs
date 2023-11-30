using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Konec : MonoBehaviour
{
    public GameObject konec;
    public AudioSource fonMusic;
    public CoinAlmaz opit;
    public IEnumerator TheEnd()
    {
        if(opit.opitUP >= 25)
        {
            konec.SetActive(true);
            fonMusic.gameObject.SetActive(false);
            yield return new WaitForSeconds(10f);
            fonMusic.gameObject.SetActive(true);
            konec.SetActive(false);
        }
    }
}
