using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialog", menuName = "ScriptableObjects/DialogSO")]
public class DialogSO : ScriptableObject
{
    [Header("Character Datas")]
    public CharacterData characterData;
    
    [Header("Dialog")]

    [TextArea(15,20)]
    public string Dialog;

    [Header("Narator Dialog")]
    public bool isNarator = false;

    [Header("Scenes")]
    public bool shouldChangeScene = false;
    public string nextSceneName;

    [Header("Expresion")]
    public bool isSpeaker1 = false;
    [Tooltip("Dialog Expression index (0 = angry, 1 = annoyed, 2 = delighted, 3 = normal, 4 = sad, 5 = shocked, 6 = smile, 7 = smile2, 8 = smug)")]
    public int dialogExpressionIndex = 0;

    [Header("Sound Effects")]
    public bool shouldPlaySound = false;
    
    public AudioClip dialogSound;
    //public bool haveOption = false;
    //public DialogSO[] possibleNextDialogs;
}
