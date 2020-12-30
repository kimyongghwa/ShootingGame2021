using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
   public void GameStart()
    {
        SceneManager.LoadScene(1);
    }
    public void Ranking()
    {
        PlayerPrefs.SetInt("nowPlayerScore", -100);
        SceneManager.LoadScene(3);
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
