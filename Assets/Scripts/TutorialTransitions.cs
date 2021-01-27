using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTransitions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.Find("Welcome").GetComponent<Canvas>().enabled)
        {
            GetComponent<Canvas>().enabled = true;
        }
    }
}
