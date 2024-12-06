using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        if(PlayerPrefs.HasKey("lastSceneName"))
        {
            SceneManager.LoadScene(PlayerPrefs.GetString("lastSceneName"));
        }else
        {
            SceneManager.LoadScene("SchoolMorning");
        }
    }
}
