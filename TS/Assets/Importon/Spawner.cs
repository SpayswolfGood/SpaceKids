using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] figurs;
    [SerializeField]
    private float timeRestart;
    [SerializeField]
    private float minTime;
    [SerializeField]
    private Vector3 spawnPos0;
    [SerializeField]
    private Vector3 spawnPos1;

    void Start()
    {

        StartCoroutine(StartTimer());
    }
    public void Timer()//Рестарт таймера
    {
        timeRestart -= 0.005f;
        if (timeRestart <= minTime) timeRestart = minTime;
        StartCoroutine(StartTimer());
    }
    private IEnumerator StartTimer()//Таймер 
    {
        yield return new WaitForSeconds(timeRestart);
        Instantiate(figurs[Random.Range(0, figurs.Length)].gameObject, new Vector3(Random.Range(spawnPos0.x, spawnPos1.x), Random.Range(spawnPos0.y, spawnPos1.y), Random.Range(spawnPos0.z, spawnPos1.z)), transform.rotation);
        Timer();
    }
}
