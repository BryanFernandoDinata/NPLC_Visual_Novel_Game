using UnityEngine;

public enum completionStatus
{
    none,
    win,
    draw,
    lose
}
public class LevelSelectorManager : MonoBehaviour
{
    public completionStatus completionStatus;
    public LevelSelectionItem[] levelSelectionItems;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
