using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "ScriptableObjects/CharacterData")]
public class CharacterData : ScriptableObject
{
    public string characterName;
    public Sprite[] characterExpressions;
}
