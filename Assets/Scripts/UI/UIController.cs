using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour 
{

    public static UIController instance;

    public Image fadeScreen;
    public float fadeSpeed;
    public bool shouldFadeToBlack;
    public bool shouldFadeFromBlack;

	// Use this for initialization
	void Start () 
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () 
    {

        if (shouldFadeToBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));

            if(fadeScreen.color.a == 1f)
            {
                shouldFadeToBlack = false;
            }
        }

        if (shouldFadeFromBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));

            if (fadeScreen.color.a == 0f)
            {
                shouldFadeFromBlack = false;
            }
        }
    }

    public void FadeToBlack()
    {
        shouldFadeToBlack = true;
        shouldFadeFromBlack = false;
    }

    public void FadeFromBlack()
    {
        shouldFadeToBlack = false;
        shouldFadeFromBlack = true;
    }
    public void LoadSceneWithLoading(string _sceneToLoad)
    {
        StartCoroutine(LoadScene(_sceneToLoad));
    }
    IEnumerator LoadScene(string _theSceneToLoad)
    {
        FadeToBlack();
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene(_theSceneToLoad);
        FadeFromBlack();
    }
}
