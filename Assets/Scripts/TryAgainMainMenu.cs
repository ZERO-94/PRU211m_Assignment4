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
        SceneManager.LoadScene(GameManager.levelList.GetValueOrDefault(GameManager.currentLevel));
    }
    
    public void StartGame()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void NextLevel()
    {
        int nextLevel = GameManager.currentLevel + 1;
        string loadScene = (GameManager.currentLevel >= GameManager.levelList.Count) ? "MainMenu" : GameManager.levelList.GetValueOrDefault(nextLevel);
        GameManager.currentLevel = nextLevel;
        SceneManager.LoadScene(loadScene);
    }

    public void StartHardModeGame()
    {
        //i dont know this could be a scene for hard mode i guess
        SceneManager.LoadScene("GameHardModeScene");
    }
}
