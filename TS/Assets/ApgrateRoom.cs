using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ApgrateRoom : MonoBehaviour
{
    public GameObject panelGame;
    public Potrebnosty potrebnosty;
    public void Avtomat()
    {
        panelGame.SetActive(true);
    }

    public void CloseGamePanel()
    {
        panelGame.SetActive(false);
    }

    public void Game(int i)
    {
        potrebnosty.active += 0.7f;
        SceneManager.LoadScene(i);
    }
}
