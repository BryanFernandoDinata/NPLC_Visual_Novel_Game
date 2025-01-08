using UnityEngine;
using UnityEngine.UI;
public class LevelSelectionItem : MonoBehaviour 
{
    public string sceneToLoad;
    public bool isUnlocked = false;
    public Image LevelImage;
    public Image lockImage;
    private void Start() 
    {
        if(isUnlocked)
        {
            lockImage.gameObject.SetActive(false);
        }
    }

    private void OnEnable() 
    {
        if(isUnlocked)
        {
            lockImage.gameObject.SetActive(false);
        }
    }
    public void Select()
    {
        UIController.instance.LoadSceneWithLoading(sceneToLoad);
    }
    public void OnHover()
    {
        if(isUnlocked)
        {
            LevelImage.color = new Color(LevelImage.color.r, LevelImage.color.g, LevelImage.color.b, 1f);
        }
    }
    public void OnExitHover()
    {
        if(isUnlocked)
        {
            LevelImage.color = new Color(LevelImage.color.r, LevelImage.color.g, LevelImage.color.b, 0.5f);
        }
    }

}
