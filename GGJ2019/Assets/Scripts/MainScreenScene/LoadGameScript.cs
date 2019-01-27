using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LoadGameScript : MonoBehaviour
{
        public Button playButton;


    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(loadGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void loadGame()
    {
        SceneManager.LoadScene("1");
    }
}
