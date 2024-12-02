using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    float endTime;
    [SerializeField] float hopTime = 2f;

    
    void Start(){
        endTime = Time.time + hopTime;
    }

    void Update(){
        if (Time.time > endTime){
            ReloadLevel();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Player jumped, resetting timer.");
            // isInContactWithFriendly = false;
            endTime = Time.time + hopTime;
        }
    }
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


        // Detecting collisions from the first person perspective
     private void OnControllerColliderHit(ControllerColliderHit hit) {
        switch(hit.gameObject.tag){
            case "Next":
            // Checking the normal to see if the normal is pointing upwards.
            // When the player is on top of the cube, the normal will point in the opposite direction of gravity
            if(Vector3.Dot(hit.normal, Vector3.up) > 0.5f)
            ReloadNextLevel();
            break;            
            case "Friendly":
            Debug.Log("Friendly");
            endTime = Time.time + hopTime;
            break;
            case "Finish":
            GetComponent<EndGame>().EndGameHandler();
            //ReloadNextLevel();
            break;
            case "Respawn":
            //Debug.Log("The collision is friendly");
            ReloadLevel();
            break;
        }
    }
}