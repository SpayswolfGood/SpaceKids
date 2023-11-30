using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManeger : MonoBehaviour
{
    [SerializeField]
    private string tags;
    public int score;
    public AudioSource app;
    private void OnCollisionEnter(Collision collision)
    {
            if (collision.gameObject.name == tags)
            {               
                score+= 20;
                app.Play();
            }          
    }
}
