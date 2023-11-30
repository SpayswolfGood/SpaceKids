using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
public class LoadingScene : MonoBehaviour
{
    public Slider slider;
    public GameObject buttonStart;
    private void Start()
    {
        slider.gameObject.active = false;
    }
    public void LoadLevel()
    {
        StartCoroutine(Load());
    }

    IEnumerator Load()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(1);
        slider.gameObject.active = true;
        buttonStart.SetActive(false);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return null;
        }
    }
}
