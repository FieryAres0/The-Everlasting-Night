using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Changer : MonoBehaviour
{
    public Animator transition;
    public GameObject pauseTab;
    private Scene currentScene;

    public float transitionTime = 1f;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "MainGame")
        {
            pauseTab = GameObject.Find("PauseTab");
            pauseTab.SetActive(false);
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
    
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

    public void PauseGame()
    {
        pauseTab.SetActive(true);
        Time.timeScale = 0;
    }

    public void UnpauseGame()
    {
        pauseTab.SetActive(false);
        Time.timeScale = 1;
    }
}
