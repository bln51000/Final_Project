using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        Debug.Log(other.gameObject.tag);
        switch(other.gameObject.tag){
            case "Friendly":
            Debug.Log("This is friendly");
            break;
            case "Respawn":
            //Debug.Log("The collision is friendly");
            ReloadLevel();
            break;
            case "Finish":
            GetComponent<EndGame>().EndGameHandler();
            ReloadNextLevel();
            break;
            case "Next":
            ReloadNextLevel();
            break;
            default:
            Debug.Log("This is default");
            Invoke("ReloadLevel", 3f);
            break;
        }
    }//player death is only hitting white GameObject in middle

    private void ReloadNextLevel(){
        Scene scene = SceneManager.GetActiveScene();
        int nextSceneIndex = scene.buildIndex + 1;
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)//what is this number?
        {
            nextSceneIndex = 0;//restarts game at level 0
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    private void ReloadLevel()
    {
        Scene sceneManager = SceneManager.GetActiveScene();
        int currentIndex = sceneManager.buildIndex;
        SceneManager.LoadScene(currentIndex);
    }
}
