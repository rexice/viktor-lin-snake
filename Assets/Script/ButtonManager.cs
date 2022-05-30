using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    //Manage all the button function
    public void reStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void startGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void quitGame()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
