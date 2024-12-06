using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class DialogController : MonoBehaviour
{
    public static DialogController instance;
    public Image speaker1;
    public Image speaker2;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogText;
    public GameObject pressEObject;
    public List<DialogSO> dialogLines = new List<DialogSO>();
    public int currentLine;
    public float wordSpeed;
    private bool justStarted;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialogText.text = "";

        CheckSpeaker();
        
        StartCoroutine(Typing());
    }

    // Update is called once per frame
    void Update()
    {
        if(pressEObject.activeInHierarchy)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                ContinueDialog();
                CheckSpeaker();
            }
        }
    }
    IEnumerator Typing()
    {
        foreach(char letter in dialogLines[currentLine].Dialog.ToCharArray())
        {  
            dialogText.text += letter;
            //AudioManager.instance.PlaySFX(8);
            yield return new WaitForSeconds(wordSpeed);
        }

        if(dialogText.text == dialogLines[currentLine].Dialog)
        {   
            if(pressEObject.activeInHierarchy == false)
            {
                pressEObject.SetActive(true);
            }
            if(dialogLines[currentLine].shouldChangeScene)
            {
                SaveManager.instance.Save(dialogLines[currentLine].nextSceneName);
                SceneManager.LoadScene(dialogLines[currentLine].nextSceneName);
            }
        }
    }
    public void CheckSpeaker()
    {
        if(dialogLines[currentLine].isSpeaker1)
        {
            speaker1.sprite = dialogLines[currentLine].characterData.characterExpressions[dialogLines[currentLine].dialogExpressionIndex];
        }else
        {   
            speaker2.sprite = dialogLines[currentLine].characterData.characterExpressions[dialogLines[currentLine].dialogExpressionIndex];
        }
        if(dialogLines[currentLine].shouldPlaySound)
        {
            if(dialogLines[currentLine].isSpeaker1)
            {
                AudioManager.instance.sfxSRC1.Stop();
                AudioManager.instance.sfxSRC1.clip = dialogLines[currentLine].dialogSound;
                AudioManager.instance.sfxSRC1.Play();       
            }
            else
            {
                AudioManager.instance.sfxSRC2.Stop();
                AudioManager.instance.sfxSRC2.clip = dialogLines[currentLine].dialogSound;
                AudioManager.instance.sfxSRC2.Play();
            }
        }
    }

    public void ContinueDialog()
    {
        if(pressEObject.activeInHierarchy == true)
        {
           pressEObject.SetActive(false);
        }
        
        if (currentLine < dialogLines.Count - 1)
        {
            currentLine++;
            dialogText.text = "";
            StartCoroutine(Typing());
        }
        
        nameText.text = dialogLines[currentLine].characterData.characterName;
        
        if(dialogLines[currentLine].isSpeaker1)
        {
            speaker1.sprite = dialogLines[currentLine].characterData.characterExpressions[dialogLines[currentLine].dialogExpressionIndex];
        }else
        {   
            speaker2.sprite = dialogLines[currentLine].characterData.characterExpressions[dialogLines[currentLine].dialogExpressionIndex];
        }
    }
}
