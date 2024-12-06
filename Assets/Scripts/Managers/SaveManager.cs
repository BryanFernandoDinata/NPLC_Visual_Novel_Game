using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
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
    public void Save(string lastSceneName)
    {
        PlayerPrefs.SetString("lastSceneName", lastSceneName);
    }
}
