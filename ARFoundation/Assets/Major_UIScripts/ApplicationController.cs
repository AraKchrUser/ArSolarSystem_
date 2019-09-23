using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplicationController : MonoBehaviour
{
    public void OnApplicationQuit()
    {
        Application.Quit();
    }

    public void OnApplicationRestart()
    {
        SceneManager.LoadScene("Scene/Space");
    }
}
