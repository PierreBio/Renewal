using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogScene1 : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public GameObject continueButton;
    bool isDisplayingText = false;

    public static DialogScene1 Instance;


    // Start is called before the first frame update
    void Start()
    {
        continueButton.SetActive(false);
        if(isDisplayingText == false)
        {
           StartCoroutine(Type());
            isDisplayingText = true;
        }
    }

    IEnumerator Type()
    {
        continueButton.SetActive(false);


        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            SoundsEffects.Instance.MakeTypingSound();
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NexSentence()
    {
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            if (isDisplayingText == true)
            {
            StartCoroutine(Type());
            }
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
            isDisplayingText = false;
        }
    }


    // Update is called once per frame
    void Update()
    {

        if (textDisplay.text ==sentences[index])
        {
            continueButton.SetActive(true);
        }
        else
        {
            continueButton.SetActive(false);
        }

    }

    //Events which can happened
    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of DialogScene1!");
        }
        Instance = this;
    }

    public void MomEvent()
    {
        if (isDisplayingText == false)
        {
            this.sentences = new string[] { "Matt", "Joanne", "Robert" };
            index = 0;
            StartCoroutine(Type());
            isDisplayingText = true;
        }
    }

}
