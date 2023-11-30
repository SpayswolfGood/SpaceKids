using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreRecord : MonoBehaviour
{

    private int Score;
    private int RecordScore;
    public Text scoreText;
    public Text recordScoreText;
    public ScoreManeger[] scoreManegers;
    public CoinAlmaz CoinAlmaz;

 
    void Start()
    {
        RecordScore = PlayerPrefs.GetInt("Score");
        recordScoreText.text = RecordScore.ToString("Record Score: 0");
    }

    void Update()
    {
        Score = scoreManegers[0].score + scoreManegers[1].score + scoreManegers[2].score;//Сумеруем очки из каждой корзинки
        scoreText.text = Score.ToString("Score: 0");

    }
    private void LateUpdate()
    {
            CoinAlmaz.opit += (Score / 5) * 0.01f;//расчитываем получение опыта
            PlayerPrefs.SetFloat("Opit", CoinAlmaz.opit);
       
        if (Score >= RecordScore)
        {
            RecordScore = Score;
            recordScoreText.text = RecordScore.ToString("Record Score: 0");
            PlayerPrefs.SetInt("Score", RecordScore);
        }
    }


}
