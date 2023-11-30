using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Potrebnosty : MonoBehaviour
{
    [SerializeField] private GameObject SUN;
    [SerializeField] private float speedTime;
    public float active;
    public float sleep;
    public float eat;
    public float toalet;

    public Image acteveImage;
    public Image sleepImage;
    public Image eatImage;
    public Image toaletImage;

    public Animator[] player;
    public bool isTooalet;

    void Start()
    {
        //присваиванье
        active = PlayerPrefs.GetFloat("active");
        sleep = PlayerPrefs.GetFloat("sleep");
        eat = PlayerPrefs.GetFloat("eat");
        toalet = PlayerPrefs.GetFloat("toalet");
    }

    void Update()
    {
        UpdateNeeds();
        CheckSun();
        Save();
        Animation();
    }

    private void UpdateNeeds()//Пределы и трата сил
    {
        active -= Time.deltaTime * speedTime;
        sleep -= Time.deltaTime * speedTime;
        eat -= Time.deltaTime * speedTime;
        toalet -= Time.deltaTime * speedTime;

        if (isTooalet)
        {
            toalet += Time.deltaTime * speedTime * 16;
            isTooalet = toalet < 0.98f;
        }

        active = Mathf.Max(active, 0);
        sleep = Mathf.Max(sleep, 0);
        eat = Mathf.Max(eat, 0);
        toalet = Mathf.Max(toalet, 0);

        active = Mathf.Min(active, 1);
        sleep = Mathf.Min(sleep, 1);
        eat = Mathf.Min(eat, 1);
        toalet = Mathf.Min(toalet, 1);
    }

    private void CheckSun()//Проверка включен ли свет
    {
        if (!SUN.activeSelf)//Если выключен повышаем покозатель
        {
            sleep += Time.deltaTime * speedTime * 16;
        }
    }

    private void Save()//сохронения
    {
        PlayerPrefs.SetFloat("active", active);
        PlayerPrefs.SetFloat("sleep", sleep);
        PlayerPrefs.SetFloat("eat", eat);
        PlayerPrefs.SetFloat("toalet", toalet);
    }

    private void Animation()
    {
        for(int i =0;i < player.Length; i++)
        {
            player[i].SetBool("Playing", active >= 0.3f);
            player[i].SetBool("Sleeping", sleep >= 0.3f);
            player[i].SetBool("Eating", eat >= 0.3f);
            player[i].SetBool("Toalet", toalet >= 0.3f);
        }
    }

    private void LateUpdate()
    {
        acteveImage.fillAmount = active;
        sleepImage.fillAmount = sleep;
        eatImage.fillAmount = eat;
        toaletImage.fillAmount = toalet;
    }
}

