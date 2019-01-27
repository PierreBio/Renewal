using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deplacement3 : MonoBehaviour
{
    public GameObject mainCharacter;
    public bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving == true)
        {
            if (mainCharacter.transform.position.x < gameObject.transform.position.x - 2)
            {
                mainCharacter.transform.Translate(Time.deltaTime, 0, 0);

            }
            else if (mainCharacter.transform.position.x > gameObject.transform.position.x + 2)
            {
                mainCharacter.transform.Translate(-Time.deltaTime, 0, 0);
            }

            if (Mathf.Abs(mainCharacter.transform.position.x - gameObject.transform.position.x) < 2)
            {
                isMoving = false;
            }
        }
    }

    void OnMouseDown()
    {
        isMoving = true;

        if (gameObject.name == "awards2Collider")
        {
            Debug.Log("Ok");
            Dialog3.Instance.AwardsEvent();
        }
    }
}
