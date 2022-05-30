using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    private static GameOverUI instance;

    private void Show()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    private void Hide()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public static void showStatic()
    {
        instance.Show();
    }
}
