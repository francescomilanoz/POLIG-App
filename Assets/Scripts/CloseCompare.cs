﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseCompare : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(closeUI);
    }


    private void closeUI()
    {
        Debug.Log("Eseguitoooo");
        GameObject.Find("ArtworkUI").GetComponent<Canvas>().enabled = true;
        GameObject.Find("CompareUI").GetComponent<Canvas>().enabled = false;
        GameObject.Find("ImageToCompare").GetComponent<Canvas>().enabled = false;


    }


    // Update is called once per frame
    void Update()
    {

    }
}


