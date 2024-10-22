using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneManager : MonoBehaviour
{
    public void GoToGame()
    {
        SceneManager.LoadScene("01_Game");
    }

    public void ExitGame()
    {
        Application.Quit(5);
    }
}
