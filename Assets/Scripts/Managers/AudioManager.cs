using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource sfxSRC1, sfxSRC2;
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
}