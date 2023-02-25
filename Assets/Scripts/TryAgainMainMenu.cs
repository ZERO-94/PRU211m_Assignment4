using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TryAgainMainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RetryGame()     
    {
        SceneManager.LoadScene("GameScene");
    }
    public void StartGame()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
    public void StartHardModeGame()
    {
        //i dont know this could be a scene for hard mode i guess
        SceneManager.LoadScene("GameHardModeScene");
        
    }
}
