using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenerLoader : MonoBehaviour
{
    public void ReloadGame(){
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void Quit(){
        Application.Quit();
    }
}
