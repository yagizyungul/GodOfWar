using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject SettingMenu;


    public void SceneOpen(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void SettingsMenu(bool select)
    {
        if (select)
        {
            SettingMenu.SetActive(true);//for open setting button
        }
        else
        {
            SettingMenu.SetActive(false);//for close settings button
        }
    }


    public void QuitApp()
    {
        Application.Quit();
    }
}
