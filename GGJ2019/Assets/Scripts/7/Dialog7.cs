using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class Dialog7 : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    string[] sentences;
    private int index;
    public float typingSpeed;

    public GameObject continueButton;
    public GameObject BackgroundText;

    bool isDisplayingText = false;

    public static Dialog7 Instance;


    // Start is called before the first frame update
    void Start()
    {
        FirstText();
        BackgroundText.SetActive(true);
        continueButton.SetActive(false);
        if (isDisplayingText == false)
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
            BackgroundText.SetActive(false);
            SceneManager.LoadScene("Credits");
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            BackgroundText.SetActive(true);
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
            Debug.LogError("Multiple instances of Dialog2!");
        }
        Instance = this;
    }

    void FirstText()
    {
        this.sentences = new string[] {
            "Aurélie : A member of parliament, I knew it, the investigation stopped too early for it to because of a lack of evidence.",
            "Jérôme : This fight will be tough but we have to do it for margot.",
            "Aurélie : We have to be heard but who can we turn to ? We are nothing compared to him… Why did it have to be someone like him!",
            "Policeman : STOP",
            "Jérôme : Yes, what do you want to say?",
            "Policeman : It’s not because the murderer is highly placed that you have to stop your fight.I think that you have to at least try.",
            "Policeman: They can contact newspapers or journalists to be heard.Or present evidence to a lot of people.",
            "Jérôme: True, in this situation the worse you can be is alone, you feel like nobody will believe you.",
            "Policeman : Yes, like what was said before, you can create groups and manifest in the street, manifestations have already succeeded, but you will never have to stop.",
            "Policeman : I don’t know if it’s great to hang on to this fight.If you don’t win, you will always think about it.",
            "Policeman : Yeah, but it’s better than doing nothing, and in this case you will never know if the member of parliament will be punished one day.",
            "Aurélie: Thank you for your reactions, this situation is rare but it can happened.You don’t have to be alone, talking to a lot of people and newspaper is a great idea to be heard!",
        };
    }


}
