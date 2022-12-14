using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void StartGame(){
        SceneManager.LoadScene("Scene1");
    }

    public void Credit(){
        SceneManager.LoadScene("Credit");
    }

    public void Quit(){
        Application.Quit();
    }

    public void Scene2(){
        SceneManager.LoadScene("Scene2");
    }

    public void Menu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void GameOver(){
        SceneManager.LoadScene("GameOver");
    }
}
