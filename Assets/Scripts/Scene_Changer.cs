using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Changer : MonoBehaviour
{
    public Animator transition;
    public GameObject pauseTab;
    public GameObject ShopUI;
    private Scene currentScene;

    public float transitionTime = 1f;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "MainGame")
        {
            pauseTab = GameObject.Find("PauseTab");
            pauseTab.SetActive(false);
            ShopUI = GameObject.Find("Shop");
            ShopUI.SetActive(false);
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
    
    //Transition from scene to scene
    IEnumerator ChangeSceneWTransition(string sceneName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneName);
    }

    public void ChangeScene(string sceneName)
    {
        Time.timeScale = 1;
        StartCoroutine(ChangeSceneWTransition(sceneName));
    }

    //Pause and unpause game
    public void PauseGame()
    {
        if (!pauseTab.activeInHierarchy)
        {
            pauseTab.SetActive(true);
            Time.timeScale = 0;
        } else if (pauseTab.activeInHierarchy)
        {
            pauseTab.SetActive(false);
        Time.timeScale = 1;
        }  
    }

    //Open up shop menu
    public void ToggleShop()
    {
        if (!ShopUI.activeInHierarchy)
        {
            ShopUI.SetActive(true);
            Time.timeScale = 0;
        } else if (ShopUI.activeInHierarchy)
        {
            ShopUI.SetActive(false);
        Time.timeScale = 1;
        }  
    }
}
