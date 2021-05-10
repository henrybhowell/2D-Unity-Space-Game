using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void playGame() {
        SceneManager.LoadScene("main");
    }

    public void options() {
        SceneManager.LoadScene("Instructions");
    }

    public void exitGame() {
        Application.Quit();
    }
}