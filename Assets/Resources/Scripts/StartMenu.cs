using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    public void StartButton()
    {
        SceneManager.LoadScene("LvL-One");
        Debug.Log("Going-To-Level-One");
    }

    public void MenuButton()
    {
        Debug.Log("Going-To-The-Menus");
    }

    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Exiting Game");
    }
}
