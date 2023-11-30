using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PianinoLogic : MonoBehaviour
{
    [SerializeField]
    private PianinoId[] klavishK;

    public string DownKlavishCode; 

    private string k;

    private int code;

    private string codeK;

    private bool isClavish;

    [SerializeField]
    private Material[] DownKlavish; 

    [SerializeField]
    private PianinoId klavish;


    [SerializeField]
    private GameObject DeadPanel;

    [SerializeField]
    private int score;

    [SerializeField]
    private int BestScore;

    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private Text BestScoreText;

    public CoinAlmaz coinAlmaz;

    public AudioSource[] pianoSound;

    void Start()
    {
        k = Random.Range(0, 4).ToString();
        StartCoroutine(StartGame());
    }
    void Update()
    {
        Piano();
        if (isClavish)
        {
            StartCoroutine(StartGame());
            isClavish = false;
        }    
    }
    public void Piano()//Логика нажатия на клавишу
    {
        if (DownKlavishCode.Length != k.Length)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 30))
                {
                    if (hit.collider.tag == "Piano")//Клавиша
                    {
                        klavish = hit.collider.GetComponent<PianinoId>();
                        pianoSound[klavish.id].Play();
                        DownKlavishCode = DownKlavishCode.ToString() + klavish.id;
                        StartCoroutine(StartTimer());
                    }
                }
            }
        }
    }
    

    public void Proverka()//Сравнение 2 переменнных
    {

        if (DownKlavishCode.Length == k.Length)
        {

            if (DownKlavishCode == k)
            {
                k = k.ToString() + Random.Range(0, 4);
                DownKlavishCode = "";
                score++;
                scoreText.text = score.ToString("Score: 0");
                if(score > BestScore)
                {
                    PlayerPrefs.SetInt("BestScore",score);
                    BestScoreText.text = BestScore.ToString("Best Score: 0");
                }
            }
            else
            {
                coinAlmaz.opit += score / 10;
                PlayerPrefs.SetFloat("Opit", coinAlmaz.opit);
                DeadPanel.SetActive(true);
            }
            isClavish = true;
        }
    }
    private IEnumerator StartTimer()//Подсветка клавиши при нажатии на нее
    {
        klavish.GetComponent<MeshRenderer>().material = klavish.down;
        yield return new WaitForSeconds(0.3f);
        klavish.GetComponent<MeshRenderer>().material = klavish.defolt;
        Proverka();
    }

    private IEnumerator SvetKlavish()//Подсветка клавишь в порядке написаном в k
    {   
        for(int z = k.Length; z > 0; z--)
        {
            codeK = k[k.Length-z].ToString();
            code = int.Parse(codeK);
            klavishK[code].GetComponent<MeshRenderer>().material = klavishK[code].down;
            pianoSound[code].Play();
            yield return new WaitForSeconds(0.3f);
            klavishK[code].GetComponent<MeshRenderer>().material = klavishK[code].defolt;
            yield return new WaitForSeconds(0.3f);
        }

    }

    private IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1f);
        StartCoroutine( SvetKlavish());
        isClavish = false;
    }

}
