using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog9 : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    string[] sentences;
    private int index;
    public float typingSpeed;

    public GameObject continueButton;
    public GameObject BackgroundText;

    public GameObject pandry;
    Animator anim;

    bool isDisplayingText = false;

    public static Dialog9 Instance;


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
                if(index == 14)
                {
                    anim.SetBool("openPandry", true);
                }
                StartCoroutine(Type());
            }
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
            isDisplayingText = false;
            BackgroundText.SetActive(false);
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
        anim = pandry.GetComponent<Animator>();
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of Dialog2!");
        }
        Instance = this;
    }

    void FirstText()
    {
        this.sentences = new string[] {
        "M : Oh Max! How are you? I’m back to home sooner than I expected..",
        "Max : Wouarf! Wouarf!",
        "M : Do you know where Dad and Mom are?.........",
        "M : What is this thing in your jaw? Is it...?" ,
        "Max : Wouarf! Wouarf! ",
        "M : It’s weird!",
        "M : Oh Dad looks! ",
        "M : Max found something!",
        "Dad : Oh Max, you have something in your…. An underpant????????????????????",
        "M : It’s strange daddy! Mom seems to be not here.",
        "Dad : Humph, it’s nothing I think!...",
        "M : Dad, I feel that someone is hidden somewhere…",
        "M : Oh Max, you smell something close to the wardrobe??",
        "Max : Wouarf! Wouarf!Wouarf!Wouaf!",
        "(Wardrobe is opened, lovers are discovered)",
         " Dad : Oh my God! My own wife! I can’t believe it.",
         "Mother : It’s not what you think honey!",
         "Dad : Oh I see! I...",
         "Lover : Yes it’s not what you think!",
         "Dad : Be quiet! You! You!You……",
         "Dad : You betrayed me!!",
         "Mother : You betrayed me the first! Don’t you remember?",
         "Mother : When you bought this dog for your daughter! It was a way to speak with the beautiful seller of the pet shop!",
         "Dad : I…..I ….",
         "Lover : If I can, I would like to say that...",
         "Dad : Be quiet fool! ",
         "Dad : Listen honey, I love you. That seller was just a detail…",
         "Lover : This “detail” as you say is MY WIFE!",
         "Mother : What? That crazy woman! Out of my sight!!!!"
        };
    }


}
