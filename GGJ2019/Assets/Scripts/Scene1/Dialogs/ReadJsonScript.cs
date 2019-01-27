using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ReadJsonScript : MonoBehaviour
{
    public string path;
    string jsonString;

    // Start is called before the first frame update
    void Start()
    {
        jsonString = File.ReadAllText(path);
        Dialog text = JsonUtility.FromJson<Dialog>(jsonString);
        Debug.Log(text.dialog);
    }

    [System.Serializable]
 public class Dialog
    {
        public string name;
        public string dialog;
    }

}
