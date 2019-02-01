using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialog1 : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    string[] sentences;
    private int index;
    public float typingSpeed;

    public GameObject continueButton;
    public GameObject BackgroundText;

    bool isDisplayingText = false;

    bool eventDoor = false;
    bool eventSofa = false;
    bool eventPresent = false;
    

    public GameObject door;
    public GameObject present;
    

    public static Dialog1 Instance;

    //Animations
    Animator anim;
    Animator anim2;


    // Start is called before the first frame update
    void Start()
    {
        BackgroundText.SetActive(true);
        FirstText();
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

            if(eventPresent == true)
            {
                SceneManager.LoadScene("8");
            }
            if (eventDoor== true)
            {
                SceneManager.LoadScene("5");
            }
            if (eventSofa == true)
            {
                SceneManager.LoadScene("2");
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
        anim = door.GetComponent<Animator>();
        anim2 = present.GetComponent<Animator>();
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of DialogScene1!");
        }
        Instance = this;
    }
    
    void FirstText()
    {
        this.sentences = new string[] {
        "Jérôme (father) : 12 years! Time passes with such speed, it is disconcerting…",
        "Aurélie (mother) : And no sooner than yesterday I gave born to a beautiful little girl.",
        "Margot : Mom, dad, Suzy invited me Saturday to celebrate my birthday, can I go?" ,
        "Aurélie : Of course you can, and if something happens, call and we will come get you.",
        "Margot : I’m gonna be fine, you worry too much!",
        "Jérôme : Not a long time ago, I remember a certain obstacle course where you had to jump from furnitures " +
        "to furnitures. And a cupboard kindly rewarded you with a cast for your first place.",
        "Margot : We call it a baptism of fire dad!",
        "Aurélie : Any way, if by any chance an issue like this one comes up, " +
        "I want you to know that you can rely on us.We will always be there for you.",
         "Margot : ...Thanks."};

    }

    public void PresentEvent()
    {
        if (isDisplayingText == false)
        {
        anim2.SetBool("openPresent", true);
        this.sentences = new string[] {
        "Margot : A puppy?!",
        "Aurélie : Happy Birthday Margot!",
        "Jérôme : I present to you the new member of our family! What’s his name?" ,
        "Margot : Max",
        "Aurélie : Welcome home Max!"
        };

        eventPresent = true;
        index = 0;
        StartCoroutine(Type());
        isDisplayingText = true;
        }
    }

    public void doorEvent()
    {
        if (isDisplayingText == false)
        {
            anim.SetBool("openTheDoor", true);
            this.sentences = new string[] {
                "(Margot thinking : I'll try to see my friend Tifanie)",
                "(Margot thinking :I just have to reach the door)"
                };
            index = 0;
            eventDoor = true;
            StartCoroutine(Type());
            isDisplayingText = true;
        }
    }

    public void sofaEvent()
    {
        if (isDisplayingText == false)
        {
            this.sentences = new string[] {
        "(watch tv)",
        "Commentator : Now let’s get ready to rumble",
        "Commentator : He starts with a really offensive move...",
        "Commentator : ...dodges his uppercut...",
        "Commentator : ...deviates a knee to feint and oOoh a straight punch combine with a hook - punch and this is a K.OOO!!",
         "Margot : Uncle is amazing!"
        };
            eventSofa = true;
            index = 0;
            StartCoroutine(Type());
            isDisplayingText = true;
        }
    }

}
