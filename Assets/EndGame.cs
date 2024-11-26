using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
        gameOverCanvas.enabled = false;
    }

    // Update is called once per frame
    public void EndGameHandler()
    {
        gameOverCanvas.enabled = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
