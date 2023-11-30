using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DestroyAsteroyd : MonoBehaviour
{
    private int score;
    private int BestScore;
    public Text scoreText;
    public Text recordScoreText;
    public ParticleSystem particle;
    public CoinAlmaz coinAlmaz;
    public AudioSource deadAsteroyd;
    void Start()
    {
        deadAsteroyd.Stop();
        BestScore = PlayerPrefs.GetInt("ScoreZachitaErch");
        scoreText.text = score.ToString("Score: 0");
        recordScoreText.text = BestScore.ToString("Record Score: 0");
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 30))
            {
                if (hit.collider.tag == "Respawn")
                {
                    Instantiate(particle,hit.collider.gameObject.transform.position,Quaternion.identity);//—павним партикл
                    Destroy(hit.collider.gameObject);
                    deadAsteroyd.Play();
                    score += 20;
                    coinAlmaz.opit += (score / 200) * 0.01f;//расчитываем получение опыта
                    PlayerPrefs.SetFloat("Opit", coinAlmaz.opit);
                    scoreText.text = score.ToString("Score: 0");
                    if (score > BestScore)
                    {
                        BestScore = score;
                        recordScoreText.text = BestScore.ToString("Record Score: 0");
                        PlayerPrefs.SetInt("ScoreZachitaErch", BestScore);
                    }
                }
            }
        }
    }
}
