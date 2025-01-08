using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // if(PlayerPrefs.HasKey("lastSceneName"))
        // {
        //     SceneManager.LoadScene(PlayerPrefs.GetString("lastSceneName"));
        // }else
        // {
        //     SceneManager.LoadScene("LevelSelect");
        // }
        UIController.instance.LoadSceneWithLoading("LevelSelect");
    }
}
