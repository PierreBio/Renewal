using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialog8 : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    string[] sentences;
    private int index;
    public float typingSpeed;

    public GameObject continueButton;
    public GameObject BackgroundText;

    bool isDisplayingText = false;

    public static Dialog8 Instance;

    bool eventDog = false;
    bool eventJacket = false;


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

            if (eventDog == true)
            {
                SceneManager.LoadScene("10");
            }
            if (eventJacket == true)
            {
                SceneManager.LoadScene("9");
            }
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
        "Margot : You’re my best friend Max. I know you can understand me!",
        "Max : Woof! Woof!",
        "Margot : Dad and mom think I’m too attached to you … But they’re wrong. You help me find a meaning to my life.",
        "Max : Woof!",
        "Margot: I have to go to school now….",
        "Max : Woof! Wait!",
        "Margot: No I can’t I have to….",
       " Margot : ….",
        "Margot : What? Did you just talk?",
        "Max : Woof!",
       " Margot : I must have imagined it…",
        "Margot : …..",
        "Margot : I can’t hide it anymore, dad and mom are really annoyed by your behaviour.",
        "Margot : They want to… they want to… abandon you…",
        "Margot : Mom especially… she gets weird sometimes...",
        "Max : (plaintive cry)",
       " Margot : I know you’re special. We have to decide on what to do."

};
    }

    public void dogEvent()
    {
        if (isDisplayingText == false)
        {
            eventDog = true;
            this.sentences = new string[] {
        "Margot : I think you’re hiding something from me Max.",
        "Max : Woof?",
        "Margot : Maybe you’re doing this for my safety…",
        "Margot : I’m convinced that you want me to be safe and happy…",
        "Margot : We will find a way to help you, together."
        };

            index = 0;
            StartCoroutine(Type());
            isDisplayingText = true;
        }
    }

    public void jacketEvent()
    {
        eventJacket = true;
        if (isDisplayingText == false)
        {
            this.sentences = new string[] {
       "Margot : I think you’re hiding something from me Max.",
        "Max : Woof?",
        "Margot : Maybe you’re doing this for my safety…",
       " Margot : I’m convinced that you want me to be safe and happy…",
        "Margot : We will find a way to help you, together."
        };

            index = 0;
            StartCoroutine(Type());
            isDisplayingText = true;
        }
    }

}
