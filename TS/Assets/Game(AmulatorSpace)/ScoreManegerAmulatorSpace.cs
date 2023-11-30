using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManegerAmulatorSpace : MonoBehaviour
{
    private float Score;
    private float RecordScore;
    public Text scoreText;
    public Text recordScoreText;
    public CoinAlmaz coinAlmaz;
    void Start()
    {
        // ����������� ����������� ��������
        RecordScore = PlayerPrefs.GetFloat("ScoreAmulatorSpace");
        recordScoreText.text = RecordScore.ToString("Record Score: 0");
    }

    void Update()
    {
        Score += Time.deltaTime;
        coinAlmaz.opit += (Score / 50)* 0.000002f;//������ ���������� �����
    }

    public void Smert()//���������� ����� ������ ������
    {
        PlayerPrefs.SetFloat("Opit", coinAlmaz.opit);
        scoreText.text = Score.ToString("Score: 0");
        if (Score >= RecordScore)
        {
            RecordScore = Score;
            recordScoreText.text = RecordScore.ToString("Record Score: 0");
            PlayerPrefs.SetFloat("ScoreAmulatorSpace", RecordScore);
        }
    }
}
