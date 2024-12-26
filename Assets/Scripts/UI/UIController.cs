using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    public bool shouldFadeToBlack = false;
    public bool shouldUnfade = false;
    public float fadeDuration = 0;

    public Image fadePanel;

    private void Awake() 
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else
        {
            Destroy(this.gameObject);
        }
    }
    public void FadeToBlack(string _sceneToLoad)
    {
        StartCoroutine(fade(_sceneToLoad));
    }
    public void Unfade(string _sceneToLoad)
    {
        StartCoroutine(deFade(_sceneToLoad));
    }
    IEnumerator fade(string _theSceneToLoad)
    {
        yield return new WaitForSeconds(fadeDuration);
        SceneManager.LoadScene(_theSceneToLoad);
    }
    IEnumerator deFade(string _theSceneToLoad)
    {
        yield return new WaitForSeconds(fadeDuration);
        SceneManager.LoadScene(_theSceneToLoad);
    }
}
